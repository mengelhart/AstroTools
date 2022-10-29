namespace Shared

open System
open Equipment

type Todo = { Id: Guid; Description: string }

module Todo =
    let isValid (description: string) =
        String.IsNullOrWhiteSpace description |> not

    let create (description: string) =
        let ep = Eyepiece {
            Id = Guid.NewGuid();
            Manufacturer = Manufacturer "TeleVue";
            Design = Design "Plossl";
            FocalLength = FocalLength 9<mm>;
            EyeRelief = EyeRelief 20<mm>;
            BarrelDiameter = BarrelDiameter 2.0<inch>;
            ApparentFieldOfView = ApparentFieldOfView 72<degree>
        }
        { Id = Guid.NewGuid()
          Description = description }

module Route =
    let builder typeName methodName =
        sprintf "/api/%s/%s" typeName methodName

type ITodosApi =
    { getTodos: unit -> Async<Todo list>
      addTodo: Todo -> Async<Todo> }
