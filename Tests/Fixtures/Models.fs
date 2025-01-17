﻿module Tests.Fixtures.Models


let listModelsResponse () =
    """
    {
        "object": "list",
        "data": [
            {
                "id": "babbage",
                "object": "model",
                "created": 1649358449,
                "owned_by": "openai",
                "permission": [
                    {
                        "id": "modelperm-49FUp5v084tBB49tC4z8LPH5",
                        "object": "model_permission",
                        "created": 1669085501,
                        "allow_create_engine": false,
                        "allow_sampling": true,
                        "allow_logprobs": true,
                        "allow_search_indices": false,
                        "allow_view": true,
                        "allow_fine_tuning": false,
                        "organization": "*",
                        "group": null,
                        "is_blocking": false
                    }
                ],
                "root": "babbage",
                "parent": null
            },
            {
                "id": "ada",
                "object": "model",
                "created": 1649357491,
                "owned_by": "openai",
                "permission": [
                    {
                        "id": "modelperm-xTOEYvDZGN7UDnQ65VpzRRHz",
                        "object": "model_permission",
                        "created": 1669087301,
                        "allow_create_engine": false,
                        "allow_sampling": true,
                        "allow_logprobs": true,
                        "allow_search_indices": false,
                        "allow_view": true,
                        "allow_fine_tuning": false,
                        "organization": "*",
                        "group": null,
                        "is_blocking": false
                    }
                ],
                "root": "ada",
                "parent": null
            },
            {
                "id": "davinci",
                "object": "model",
                "created": 1649359874,
                "owned_by": "openai",
                "permission": [
                    {
                        "id": "modelperm-U6ZwlyAd0LyMk4rcMdz33Yc3",
                        "object": "model_permission",
                        "created": 1669066355,
                        "allow_create_engine": false,
                        "allow_sampling": true,
                        "allow_logprobs": true,
                        "allow_search_indices": false,
                        "allow_view": true,
                        "allow_fine_tuning": false,
                        "organization": "*",
                        "group": null,
                        "is_blocking": false
                    }
                ],
                "root": "davinci",
                "parent": null
            }
        ]
    }
    """

let retrieveModelResponse () =
    """
    {
        "id": "text-davinci-003",
        "object": "model",
        "created": 1669599635,
        "owned_by": "openai-internal",
        "permission": [
            {
                "id": "modelperm-1bzc4d8WTSGdYnVUktUwKbQR",
                "object": "model_permission",
                "created": 1674963303,
                "allow_create_engine": false,
                "allow_sampling": true,
                "allow_logprobs": true,
                "allow_search_indices": false,
                "allow_view": true,
                "allow_fine_tuning": false,
                "organization": "*",
                "group": null,
                "is_blocking": false
            }
        ],
        "root": "text-davinci-003",
        "parent": null
    }
    """

let deleteModelResponse () =
    """
    {
      "id": "curie:ft-acmeco-2021-03-03-21-44-20",
      "object": "model",
      "deleted": true
    }
    """
