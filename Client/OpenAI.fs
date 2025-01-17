﻿namespace OpenAI

open OpenAI
open OpenAI.Models
open OpenAI.Completions
open OpenAI.Chat
open OpenAI.Edits
open OpenAI.Images
open OpenAI.Embeddings
open OpenAI.Audio
open OpenAI.Files
open OpenAI.FineTunes

type OpenAIComputed() =
    // Required - creates default "starting" values
    member _.Yield _ =
        Config({ Endpoint = ""; ApiKey = "" }, HttpRequester())

    [<CustomOperation "endPoint">]
    // Sets OpenAI end point
    member _.EndPoint(config: Config, endPoint: string) =
        Config(
            { Endpoint = endPoint
              ApiKey = config.ApiConfig.ApiKey },
            config.HttpRequester
        )

    [<CustomOperation "apiKey">]
    // Sets OpenAI API Key
    member _.ApiKey(config: Config, apiKey: string) =
        Config(
            { Endpoint = config.ApiConfig.Endpoint
              ApiKey = apiKey },
            config.HttpRequester
        )

    [<CustomOperation "models">]
    // Start OpenAI Models resource handling
    member _.Models(config: Config) = models config

    [<CustomOperation "list">]
    // Models List Endpoint
    member _.List(config: ConfigWithModelContext) : Models.ListModelsResponse = Models.list config

    [<CustomOperation "retrieve">]
    // Models List Endpoint
    member _.Retrieve(config: ConfigWithModelContext, modelName: string) : Models.ModelResponse =
        Models.retrieve modelName config

    [<CustomOperation "delete">]
    // Models Delete Endpoint
    member _.Delete(config: ConfigWithModelContext, modelId: string) : Models.DeleteModelResponse =
        Models.delete modelId config

    [<CustomOperation "completions">]
    // Start OpenAI Completions resource handling
    member _.Completions(config: Config) = completions config

    [<CustomOperation "create">]
    // Completions Create Endpoint
    member _.Create
        (
            config: ConfigWithCompletionContext,
            request: Completions.CreateRequest
        ) : Completions.CreateResponse =
        Completions.create request config

    [<CustomOperation "chat">]
    // Start OpenAI Chat resource handling
    member _.Chat(config: Config) = chat config

    [<CustomOperation "create">]
    // Chat Create Endpoint
    member _.Create(config: ConfigWithChatContext, request: Chat.CreateRequest) : Chat.CreateResponse =
        Chat.create request config

    [<CustomOperation "edits">]
    // Start OpenAI Edits resource handling
    member _.Edits(config: Config) = edits config

    [<CustomOperation "create">]
    // Edits Create Endpoint
    member _.Create(config: ConfigWithEditContext, request: Edits.CreateRequest) : Edits.CreateResponse =
        Edits.create request config

    [<CustomOperation "images">]
    // Start OpenAI Images resource handling
    member _.Images(config: Config) = images config

    [<CustomOperation "create">]
    // Images Create Endpoint
    member _.Create(config: ConfigWithImageContext, request: Images.CreateRequest) : Images.CreateResponse =
        Images.create request config

    [<CustomOperation "edit">]
    // Images Edit Endpoint
    member _.Edit(config: ConfigWithImageContext, request: Images.EditRequest) : Images.EditResponse =
        Images.edit request config

    [<CustomOperation "variation">]
    // Images Edit Endpoint
    member _.Variation(config: ConfigWithImageContext, request: Images.VariationRequest) : Images.VariationResponse =
        Images.variation request config

    [<CustomOperation "embeddings">]
    // Start OpenAI Embeddings resource handling
    member _.Embeddings(config: Config) = Embeddings.embeddings config

    [<CustomOperation "create">]
    // Embeddings Create Endpoint
    member _.Create(config: ConfigWithEmbeddingContext, request: Embeddings.CreateRequest) : Embeddings.CreateResponse =
        Embeddings.create request config

    [<CustomOperation "audio">]
    // Start OpenAI Audio resource handling
    member _.Audio(config: Config) = audio config

    [<CustomOperation "transcript">]
    // Audio Transcript Endpoint
    member _.Transcript(config: ConfigWithAudioContext, request: TranscriptRequest) : TranscriptResponse =
        transcript request config

    [<CustomOperation "translate">]
    // Audio Translate Endpoint
    member _.Translate(config: ConfigWithAudioContext, request: TranslateRequest) : TranslateResponse =
        translate request config

    [<CustomOperation "moderations">]
    // Start OpenAI Moderations resource handling
    member _.Moderations(config: Config) = Moderations.moderations config

    [<CustomOperation "create">]
    // Moderations Create Endpoint
    member _.Create
        (
            config: ConfigWithModerationContext,
            request: Moderations.CreateRequest
        ) : Moderations.CreateResponse =
        Moderations.create request config

    [<CustomOperation "files">]
    // Start OpenAI Files resource handling
    member _.Files(config: Config) = Files.files config

    [<CustomOperation "list">]
    // Files List Endpoint
    member _.List(config: ConfigWithFileContext) : Files.ListResponse = Files.list config

    [<CustomOperation "upload">]
    // Files Upload Endpoint
    member _.Upload(config: ConfigWithFileContext, request: Files.UploadRequest) : Files.UploadFileResponse =
        Files.upload request config

    [<CustomOperation "delete">]
    // Files Delete Endpoint
    member _.Delete(config: ConfigWithFileContext, fileId: string) : Files.DeleteResponse = Files.delete fileId config

    [<CustomOperation "retrieve">]
    // Files Retrieve Endpoint
    member _.Retrieve(config: ConfigWithFileContext, fileId: string) : Files.RetrieveFileResponse =
        Files.retrieve fileId config

    [<CustomOperation "download">]
    // Files Download Endpoint
    member _.Download(config: ConfigWithFileContext, fileId: string) : string = Files.download fileId config

    [<CustomOperation "fineTunes">]
    // Start OpenAI Fine-Tunes resource handling
    member _.FineTunes(config: Config) = FineTunes.fineTunes config

    [<CustomOperation "create">]
    // Fine-Tunes Create Endpoint
    member _.Create(config: ConfigWithFineTuneContext, request: FineTunes.CreateRequest) : FineTunes.CreateResponse =
        FineTunes.create request config

    [<CustomOperation "list">]
    // Fine-Tunes List Endpoint
    member _.List(config: ConfigWithFineTuneContext) : FineTunes.ListResponse = FineTunes.list config

    [<CustomOperation "retrieve">]
    // Fine-Tunes Retrieve Endpoint
    member _.Retrieve(config: ConfigWithFineTuneContext, fineTuneId: string) : FineTunes.RetrieveFineTuneResponse =
        FineTunes.retrieve fineTuneId config

    [<CustomOperation "cancel">]
    // Fine-Tunes Cancel Endpoint
    member _.Cancel(config: ConfigWithFineTuneContext, fineTuneId: string) : FineTunes.CancelFineTuneResponse =
        FineTunes.cancel fineTuneId config

    [<CustomOperation "listEvents">]
    // Fine-Tunes Cancel Endpoint
    member _.ListEvents(config: ConfigWithFineTuneContext, fineTuneId: string) : FineTunes.ListFineTuneEventsResponse =
        FineTunes.listEvents fineTuneId config

module Client =
    let sendRequest (config: Config) (data: (string * string) list) =
        config.HttpRequester.postRequest config.ApiConfig data

    let openAI = OpenAIComputed()
