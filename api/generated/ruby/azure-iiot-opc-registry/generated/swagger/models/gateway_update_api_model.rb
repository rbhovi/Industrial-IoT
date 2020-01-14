# encoding: utf-8
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for
# license information.
#
# Code generated by Microsoft (R) AutoRest Code Generator 1.0.0.0
# Changes may cause incorrect behavior and will be lost if the code is
# regenerated.

module azure.iiot.opc.registry
  module Models
    #
    # Gateway registration update request
    #
    class GatewayUpdateApiModel
      # @return [String] Site of the Gateway
      attr_accessor :site_id


      #
      # Mapper for GatewayUpdateApiModel class as Ruby Hash.
      # This will be used for serialization/deserialization.
      #
      def self.mapper()
        {
          client_side_validation: true,
          required: false,
          serialized_name: 'GatewayUpdateApiModel',
          type: {
            name: 'Composite',
            class_name: 'GatewayUpdateApiModel',
            model_properties: {
              site_id: {
                client_side_validation: true,
                required: false,
                serialized_name: 'siteId',
                type: {
                  name: 'String'
                }
              }
            }
          }
        }
      end
    end
  end
end
