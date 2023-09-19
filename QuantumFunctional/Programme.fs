// For more information see https://aka.ms/fsharp-console-apps

open Microsoft.Quantum.Simulation.Simulators
open QuantumArithmetic

let quantumSimulator = new QuantumSimulator()

let plusfunc() = 
    async {
        let plus = quantumSimulator.Run(Add 3 4) |> Async.AwaitTask 
        printfn "3 + 4 = %M" plus
    }

let minusfunc() = 
    async { 
        let minus = quantumSimulator.Run(Subtract, (10 7)) |> Async.AwaitTask
        printfn "10 - 7 = %M" minus
    }

let productfunc() = 
    async { 
        let product = quantumSimulator.Run(Multiply, (5 6)) |> Async.AwaitTask
        printfn "5 * 6 = %M" product
    }


let shareBetweenfunc() = 
    async { 
        let shareBetween = quantumSimulator.Run(Divide, (12 3)) |> Async.AwaitTask
        printfn "12 / 3 = %M" shareBetween
    }

[<EntryPoint>]
let main argv =
    argv
    |> Seq.map plus minus product shareBetween
    |> Async.Parallel
    |> Async.Ignore
    |> Async.RunSynchronously

    0