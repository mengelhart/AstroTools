module Server

open FSharp.Data.Sql

open Fable.Remoting.Server
open Fable.Remoting.Giraffe
open Saturn

open Shared

module Storage =
    let [<Literal>] dbVendor = Common.DatabaseProviderTypes.POSTGRESQL
    let [<Literal>] connString = "Host=localhost;Database=astro_tools_local;Username=mengelhart;Password="
    let [<Literal>] connStringName = "DefaultConnectionString"
    let [<Literal>] resolutionPath = ""
    let [<Literal>] indivAmount = 1000
    let [<Literal>] useOptTypes  = true

    let [<Literal>] owner = "public, admin, references"


    type sql =        
        SqlDataProvider<
            dbVendor,
            connString,
            "",         //ConnectionNameString can be left empty 
            resolutionPath,
            indivAmount,
            FSharp.Data.Sql.Common.NullableColumnType.OPTION,
            owner>
    
    let todos = ResizeArray()
    let addTodo (todo: Todo) =        
        if Todo.isValid todo.Description then
            todos.Add todo
            Ok()
        else
            Error "Invalid todo"

    do
        addTodo (Todo.create "Create new SAFE project")
        |> ignore

        addTodo (Todo.create "Write your app") |> ignore
        addTodo (Todo.create "Ship it !!!") |> ignore

let todosApi =
    { getTodos = fun () -> async { return Storage.todos |> List.ofSeq }
      addTodo =
        fun todo ->
            async {
                return
                    match Storage.addTodo todo with
                    | Ok () -> todo
                    | Error e -> failwith e
            }
    }

let webApp =
    Remoting.createApi ()
    |> Remoting.withRouteBuilder Route.builder
    |> Remoting.fromValue todosApi
    |> Remoting.buildHttpHandler

let app =
    application {
        use_router webApp
        memory_cache
        use_static "public"
        use_gzip
    }

[<EntryPoint>]
let main _ =
    run app
    0