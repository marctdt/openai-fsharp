module Tests.Files

open System.IO
open OpenAI
open OpenAI.Client
open OpenAI.Files
open Tests.Helpers
open Expecto
open Tests.Fixtures.Files

[<Tests>]
let tests =
    testList
        "files"
        [ test "files list test" {
              let response = listFilesResponse ()
              let responseObject = serialize<ListResponse> response

              let client = Config({ ApiKey = "apiKey"; Endpoint = url "" }, HttpRequester())

              let response = client |> files |> list

              Expect.equal response responseObject ""
          }

          test "files list test using computation expression" {
              let response = listFilesResponse ()
              let responseObject = serialize<ListResponse> response

              let response =
                  openAI {
                      endPoint (url "")
                      apiKey "apiKey"
                      files
                      list
                  }

              Expect.equal response responseObject ""
          }

          test "files upload test" {
              let response = uploadFileResponse ()
              let responseObject = serialize<File> response

              let client = Config({ ApiKey = "apiKey"; Endpoint = url "" }, HttpRequester())

              let response =
                  client
                  |> files
                  |> upload
                      { File = @"Fixtures/sample-json.txt"
                        Purpose = "fine-tune" }

              Expect.equal response responseObject ""
          }

          test "files upload test using computation expression" {
              let response = uploadFileResponse ()
              let responseObject = serialize<File> response

              let response =
                  openAI {
                      endPoint (url "")
                      apiKey "apiKey"
                      files
                      upload
                          { File = @"Fixtures/sample-json.txt"
                            Purpose = "fine-tune" }
                  }

              Expect.equal response responseObject ""
          }

          test "files delete test" {
              let response = deleteFileResponse ()
              let responseObject = serialize<DeleteResponse> response

              let client = Config({ ApiKey = "apiKey"; Endpoint = url "" }, HttpRequester())

              let response = client |> files |> delete "file-z9t9NWFy7hXP1H2w0wtsz8ei"

              Expect.equal response responseObject ""
          }

          test "files delete test using computation expression" {
              let response = deleteFileResponse ()
              let responseObject = serialize<DeleteResponse> response

              let response =
                  openAI {
                      endPoint (url "")
                      apiKey "apiKey"
                      files
                      delete "file-z9t9NWFy7hXP1H2w0wtsz8ei"
                  }

              Expect.equal response responseObject ""
          }

          test "files retrieve test" {
              let response = retrieveFileResponse ()
              let responseObject = serialize<File> response

              let client = Config({ ApiKey = "apiKey"; Endpoint = url "" }, HttpRequester())

              let response = client |> files |> retrieve "file-qtUwySute1Zf2yT6mWIGTCwq"

              Expect.equal response responseObject ""
          }

          test "files retrieve test using computation expression" {
              let response = retrieveFileResponse ()
              let responseObject = serialize<File> response

              let response =
                  openAI {
                      endPoint (url "")
                      apiKey "apiKey"
                      files
                      retrieve "file-qtUwySute1Zf2yT6mWIGTCwq"
                  }

              Expect.equal response responseObject ""
          }

          test "files download test" {
              let responseString = File.ReadAllText @"Fixtures/sample-json.txt"

              let client = Config({ ApiKey = "apiKey"; Endpoint = url "" }, HttpRequester())

              let response = client |> files |> download "file-qtUwySute1Zf2yT6mWIGTCwq"

              Expect.equal response responseString ""
          }

          test "files download test using computation expression" {
              let responseString = File.ReadAllText @"Fixtures/sample-json.txt"

              let response =
                  openAI {
                      endPoint (url "")
                      apiKey "apiKey"
                      files
                      download "file-qtUwySute1Zf2yT6mWIGTCwq"
                  }

              Expect.equal response responseString ""
          } ]
