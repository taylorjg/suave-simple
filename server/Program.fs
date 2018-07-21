open System
open System.IO
open Suave
open Suave.Filters
open Suave.Operators
open Suave.Successful

let app =
  choose
    [ 
        GET >=> Files.browseHome
        pathScan "/api/toUpper/%s" <| fun s -> OK(s.ToUpper())
    ]

let portEnvVar = Environment.GetEnvironmentVariable "PORT"
let port = if String.IsNullOrEmpty portEnvVar then 8080 else (int)portEnvVar

let config =
  { defaultConfig with
      bindings   = [ HttpBinding.createSimple HTTP "0.0.0.0" port ]
      homeFolder = Some (Path.GetFullPath "./client")
  }

[<EntryPoint>]
let main _ =
    startWebServer config app
    0
