﻿// ------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
//  Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace IIoTPlatform_E2E_Tests.TestExtensions {
    using IIoTPlatform_E2E_Tests.Deploy;

    /// <summary>
    /// Test context to pass data between test cases for standalone tests.
    /// </summary>
    public class IIoTStandaloneTestContext : IIoTMultipleNodesTestContext {

        /// <summary>
        /// Deployment for edgeHub and edgeAgent so called "base deployment"
        /// </summary>
        public readonly IIoTHubEdgeDeployment IoTHubEdgeBaseDeployment;

        /// <summary>
        /// Deployment for OPC Publisher as standalone
        /// </summary>
        public readonly IIoTHubEdgeDeployment IoTHubPublisherDeployment;

        /// <summary>
        /// Constructor of test context.
        /// </summary>
        public IIoTStandaloneTestContext() {
            // Create deployments.
            IoTHubEdgeBaseDeployment = new IoTHubEdgeBaseDeployment(this);
            IoTHubPublisherDeployment = new IoTHubPublisherDeployment(this, MessagingMode.PubSub);
        }
    }
}
