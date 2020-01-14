// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator 1.0.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.IIoT.Opc.Twin.Models
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Result of node browse continuation
    /// </summary>
    public partial class BrowsePathResponseApiModel
    {
        /// <summary>
        /// Initializes a new instance of the BrowsePathResponseApiModel class.
        /// </summary>
        public BrowsePathResponseApiModel()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the BrowsePathResponseApiModel class.
        /// </summary>
        /// <param name="targets">Targets</param>
        public BrowsePathResponseApiModel(IList<NodePathTargetApiModel> targets = default(IList<NodePathTargetApiModel>), ServiceResultApiModel errorInfo = default(ServiceResultApiModel))
        {
            Targets = targets;
            ErrorInfo = errorInfo;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets targets
        /// </summary>
        [JsonProperty(PropertyName = "targets")]
        public IList<NodePathTargetApiModel> Targets { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "errorInfo")]
        public ServiceResultApiModel ErrorInfo { get; set; }

    }
}
