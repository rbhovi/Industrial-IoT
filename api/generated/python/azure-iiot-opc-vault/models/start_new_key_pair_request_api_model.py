# coding=utf-8
# --------------------------------------------------------------------------
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for
# license information.
#
# Code generated by Microsoft (R) AutoRest Code Generator 2.3.33.0
# Changes may cause incorrect behavior and will be lost if the code is
# regenerated.
# --------------------------------------------------------------------------

from msrest.serialization import Model


class StartNewKeyPairRequestApiModel(Model):
    """New key pair request.

    :param entity_id: Entity id
    :type entity_id: str
    :param group_id: Certificate group
    :type group_id: str
    :param certificate_type: Possible values include:
     'ApplicationInstanceCertificate', 'HttpsCertificate',
     'UserCredentialCertificate'
    :type certificate_type: str or ~azure-iiot-opc-vault.models.TrustGroupType
    :param subject_name: Subject name
    :type subject_name: str
    :param domain_names: Domain names
    :type domain_names: list[str]
    """

    _validation = {
        'entity_id': {'required': True},
        'group_id': {'required': True},
        'certificate_type': {'required': True},
        'subject_name': {'required': True},
    }

    _attribute_map = {
        'entity_id': {'key': 'entityId', 'type': 'str'},
        'group_id': {'key': 'groupId', 'type': 'str'},
        'certificate_type': {'key': 'certificateType', 'type': 'TrustGroupType'},
        'subject_name': {'key': 'subjectName', 'type': 'str'},
        'domain_names': {'key': 'domainNames', 'type': '[str]'},
    }

    def __init__(self, entity_id, group_id, certificate_type, subject_name, domain_names=None):
        super(StartNewKeyPairRequestApiModel, self).__init__()
        self.entity_id = entity_id
        self.group_id = group_id
        self.certificate_type = certificate_type
        self.subject_name = subject_name
        self.domain_names = domain_names
