﻿module Tests.Helpers

open System.Text.Json
open System.Threading
open Suave

type Route =
    { method: WebPart
      route: string
      handler: HttpRequest -> WebPart }

let url (s: string) = $"http://127.0.0.1:8080{s}"

let serve (app: WebPart) =
    let cts = new CancellationTokenSource()

    let conf =
        { defaultConfig with
            cancellationToken = cts.Token }

    let listening, server = startWebServerAsync conf app

    Async.Start(server, cts.Token)

    do
        listening
        |> Async.RunSynchronously
        |> Array.choose id
        |> Array.map (fun x -> x.binding |> string)
        |> String.concat "; "
        |> printfn "Server ready and listening on: %s"

    let dispose () =
        cts.Cancel()
        cts.Dispose()

    { new System.IDisposable with
        member this.Dispose() = dispose () }


let serialize<'T> (json: string) : 'T =
    JsonSerializer.Deserialize<'T>(json, JsonSerializerOptions(PropertyNameCaseInsensitive = true))
