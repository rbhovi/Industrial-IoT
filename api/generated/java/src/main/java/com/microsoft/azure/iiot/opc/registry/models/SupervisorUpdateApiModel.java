/**
 * Copyright (c) Microsoft Corporation. All rights reserved.
 * Licensed under the MIT License. See License.txt in the project root for
 * license information.
 *
 * Code generated by Microsoft (R) AutoRest Code Generator 1.0.0.0
 * Changes may cause incorrect behavior and will be lost if the code is
 * regenerated.
 */

package com.microsoft.azure.iiot.opc.registry.models;

import com.fasterxml.jackson.annotation.JsonProperty;

/**
 * Supervisor registration update request.
 */
public class SupervisorUpdateApiModel {
    /**
     * Site of the supervisor.
     */
    @JsonProperty(value = "siteId")
    private String siteId;

    /**
     * Possible values include: 'Error', 'Information', 'Debug', 'Verbose'.
     */
    @JsonProperty(value = "logLevel")
    private TraceLogLevel logLevel;

    /**
     * Get site of the supervisor.
     *
     * @return the siteId value
     */
    public String siteId() {
        return this.siteId;
    }

    /**
     * Set site of the supervisor.
     *
     * @param siteId the siteId value to set
     * @return the SupervisorUpdateApiModel object itself.
     */
    public SupervisorUpdateApiModel withSiteId(String siteId) {
        this.siteId = siteId;
        return this;
    }

    /**
     * Get possible values include: 'Error', 'Information', 'Debug', 'Verbose'.
     *
     * @return the logLevel value
     */
    public TraceLogLevel logLevel() {
        return this.logLevel;
    }

    /**
     * Set possible values include: 'Error', 'Information', 'Debug', 'Verbose'.
     *
     * @param logLevel the logLevel value to set
     * @return the SupervisorUpdateApiModel object itself.
     */
    public SupervisorUpdateApiModel withLogLevel(TraceLogLevel logLevel) {
        this.logLevel = logLevel;
        return this;
    }

}
