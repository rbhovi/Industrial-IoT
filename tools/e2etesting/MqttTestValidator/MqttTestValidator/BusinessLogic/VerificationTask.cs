﻿namespace MqttTestValidator.BusinessLogic {
    using MQTTnet;
    using MQTTnet.Client;
    using MQTTnet.Client.Connecting;
    using MQTTnet.Client.Disconnecting;
    using MQTTnet.Client.Options;
    using MQTTnet.Client.Receiving;
    using MQTTnet.Client.Subscribing;
    using MQTTnet.Formatter;
    using MqttTestValidator.Interfaces;
    using MqttTestValidator.Models;
    using System.Text;

    internal sealed class VerificationTask : IVerificationTask, IMqttClientConnectedHandler, IMqttClientDisconnectedHandler, IMqttApplicationMessageReceivedHandler {
        private readonly string _mqttBroker;
        private readonly uint _mqttPort;
        private readonly string _mqttTopic;
        private readonly TimeSpan _startUpDelay;
        private readonly TimeSpan _observationTime;
        private readonly ILogger<IVerificationTask> _logger;
        private MqttVerificationDetailedResponse _result;
        private static object _lock = new object();
        private ulong _messageCounter;
        private uint _lowestMessageId;
        private uint _highestMessageId;

        public VerificationTask(ulong id, string mqttBroker, uint mqttPort, string mqttTopic, TimeSpan startUpDelay, TimeSpan observationTime, ILogger<IVerificationTask> logger) {
            Id = id;
            _mqttBroker = mqttBroker;
            _mqttPort = mqttPort;
            _mqttTopic = mqttTopic;
            _startUpDelay = startUpDelay;
            _observationTime = observationTime;
            _logger = logger;
            
            _result = new MqttVerificationDetailedResponse {
                IsFinished = false
            };
            _messageCounter = 0;
            _lowestMessageId = 0;
            _highestMessageId = 0;
        }

        public ulong Id { get; set; }

        public void Start()
        {
            var cts = new CancellationTokenSource(_startUpDelay + _observationTime);
            var unítOfWork = Task.Delay(_startUpDelay, cts.Token)
            .ContinueWith(t => {
                var mqttFactory = new MqttFactory();

                using (var mqttClient = mqttFactory.CreateMqttClient()) {

                    var clientId = $"{_mqttBroker}:{_mqttPort}";
                    var mqttClientOptions = new MqttClientOptionsBuilder()
                        .WithTcpServer(clientId)
                        .WithCleanSession(true)
                        .WithProtocolVersion(MqttProtocolVersion.V500)
                        .WithClientId($"validator_{Id}")
                        .Build();

                    mqttClient.ConnectedHandler = this;
                    mqttClient.DisconnectedHandler = this;
                    mqttClient.ApplicationMessageReceivedHandler = this;

                    _logger.LogInformation($"Connecting to {_mqttBroker} on port {_mqttPort} with {clientId} as clean session");
                    var connectionResult = mqttClient.ConnectAsync(mqttClientOptions, cts.Token).ConfigureAwait(false).GetAwaiter().GetResult();
                    if (connectionResult.ResultCode != MqttClientConnectResultCode.Success)  {
                        _logger.LogError($"Can't connect to MQTT broker: {connectionResult.ReasonString}: {connectionResult.ResultCode}");
                        throw new InvalidProgramException("Can't connect to MQTT Broker");
                    }
                    _logger.LogInformation("Connected!");
                       
                    var mqttSubscribeOptions = mqttFactory.CreateSubscribeOptionsBuilder()
                        .WithTopicFilter(f => { f.WithTopic(_mqttTopic).WithAtLeastOnceQoS(); })
                        .Build();

                    _logger.LogInformation($"Subscribing to topic {_mqttTopic} with QoS 1");
                    var subscriptionResult =  mqttClient.SubscribeAsync(mqttSubscribeOptions, cts.Token).ConfigureAwait(false).GetAwaiter().GetResult();
                    if (subscriptionResult.Items[0].ResultCode != MqttClientSubscribeResultCode.GrantedQoS1) {
                        _logger.LogError("Can't subscribe to topic: {subscriptionResult.Items[0].ResultCode}");
                        throw new InvalidProgramException("Can't subscribe to topic");
                    }
                    _logger.LogInformation($"Subscribed");
                }
            }, cts.Token)
            .ContinueWith(t => {
                lock (_lock) {
                    _result.IsFinished = true;
                    _result.HasFailed = !t.IsCompletedSuccessfully;
                    if (t.Exception != null) {
                        _result.Error = t.Exception.Flatten().Message;
                    }
                    _result.NumberOfMessages = _messageCounter;
                    _result.LowestMessageId = _lowestMessageId;
                    _result.HighestMessageId = _highestMessageId;
                }
            });
        }
        
        public MqttVerificationDetailedResponse GetResult()
        {
            lock(_lock)
            {
                return _result;
            }
        }

        public Task HandleConnectedAsync(MqttClientConnectedEventArgs eventArgs) {
            _logger.LogInformation($"Connected to MQTT Broker ({_mqttBroker} on {_mqttPort}): {eventArgs.ConnectResult.ReasonString}:{eventArgs.ConnectResult.ResultCode}");
            return Task.CompletedTask;
        }

        public Task HandleDisconnectedAsync(MqttClientDisconnectedEventArgs eventArgs) {
            _logger.LogInformation($"Disconnected from MQTT Broker ({_mqttBroker} on {_mqttPort}): {eventArgs.ConnectResult.ReasonString}:{eventArgs.ConnectResult.ResultCode}");
            //todo add reconnect logic
            return Task.CompletedTask;
        }

        public Task HandleApplicationMessageReceivedAsync(MqttApplicationMessageReceivedEventArgs eventArgs) {
            
            eventArgs.AutoAcknowledge = true;
            Interlocked.Increment(ref _messageCounter);
            
            try {
                var message = Encoding.UTF8.GetString(eventArgs.ApplicationMessage.Payload);
                _logger.LogTrace(message);
                //todo set min and max MessageId
            }
            catch (Exception ex) {
                _logger.LogError($"Error while processing MQTT message: {ex.Message}");
                new AggregateException("Internal error processing MQTT message", ex);
            }
            
            return Task.CompletedTask;
        }
    }
}
