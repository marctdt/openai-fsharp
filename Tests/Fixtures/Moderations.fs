﻿module Tests.Fixtures.Moderations

let createModerationResponse () =
    """
    {
        "id": "modr-6f5GyQl8uBCKcEqOQsdTS7elN9iAx",
        "model": "text-moderation-004",
        "results": [
            {
                "flagged": true,
                "categories": {
                    "sexual": false,
                    "hate": false,
                    "violence": true,
                    "self-harm": false,
                    "sexual/minors": false,
                    "hate/threatening": false,
                    "violence/graphic": false
                },
                "category_scores": {
                    "sexual": 9.69763732427964e-07,
                    "hate": 0.18252533674240112,
                    "violence": 0.8871539235115051,
                    "self-harm": 1.9077321944394043e-09,
                    "sexual/minors": 1.3826513267645169e-08,
                    "hate/threatening": 0.0032941880635917187,
                    "violence/graphic": 3.196241493697016e-08
                }
            }
        ]
    }
    """
