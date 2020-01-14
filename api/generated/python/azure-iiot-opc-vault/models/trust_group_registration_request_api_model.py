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


class TrustGroupRegistrationRequestApiModel(Model):
    """Trust group registration request model.

    :param name: The new name of the trust group
    :type name: str
    :param parent_id: The identifer of the parent trust group.
    :type parent_id: str
    :param subject_name: The subject name of the group as distinguished name.
    :type subject_name: str
    :param issued_lifetime: The lifetime of certificates issued in the group.
    :type issued_lifetime: str
    :param issued_key_size: The issued certificate key size in bits.
    :type issued_key_size: int
    :param issued_signature_algorithm: Possible values include: 'Rsa256',
     'Rsa384', 'Rsa512', 'Rsa256Pss', 'Rsa384Pss', 'Rsa512Pss'
    :type issued_signature_algorithm: str or
     ~azure-iiot-opc-vault.models.SignatureAlgorithm
    """

    _validation = {
        'name': {'required': True},
        'parent_id': {'required': True},
        'subject_name': {'required': True},
    }

    _attribute_map = {
        'name': {'key': 'name', 'type': 'str'},
        'parent_id': {'key': 'parentId', 'type': 'str'},
        'subject_name': {'key': 'subjectName', 'type': 'str'},
        'issued_lifetime': {'key': 'issuedLifetime', 'type': 'str'},
        'issued_key_size': {'key': 'issuedKeySize', 'type': 'int'},
        'issued_signature_algorithm': {'key': 'issuedSignatureAlgorithm', 'type': 'SignatureAlgorithm'},
    }

    def __init__(self, name, parent_id, subject_name, issued_lifetime=None, issued_key_size=None, issued_signature_algorithm=None):
        super(TrustGroupRegistrationRequestApiModel, self).__init__()
        self.name = name
        self.parent_id = parent_id
        self.subject_name = subject_name
        self.issued_lifetime = issued_lifetime
        self.issued_key_size = issued_key_size
        self.issued_signature_algorithm = issued_signature_algorithm
