// For more information see https://aka.ms/fsharp-console-apps

open Microsoft.Quantum.Simulation.Simulators
open QuantumArithmetic

let quantumSimulator = new QuantumSimulator()

let plusfunc() =
    async {
        let! plus = quantumSimulator.Run<Add, (double * double), double>(3, 4) |> Async.AwaitTask
        printfn $"3 + 4 = {plus}"
    }

let minusfunc() =
    async {
        let! minus = quantumSimulator.Run<Subtract, (double * double), double>(10, 7) |> Async.AwaitTask
        printfn $"10 - 7 = {minus}"
    }

let productfunc() =
    async {
        let! product = quantumSimulator.Run<Multiply,( double * double), double>(5, 6) |> Async.AwaitTask
        printfn $"5 * 6 = {product}"
    }


let shareBetweenfunc() =
    async {
        let! shareBetween = quantumSimulator.Run<Divide, (double * double), double>(12, 3) |> Async.AwaitTask
        printfn $"12 / 3 = {shareBetween}"
    }

[<EntryPoint>]
let main argv =
    async {
        plusfunc() |> ignore
        minusfunc() |> ignore
        productfunc() |> ignore
        shareBetweenfunc() |> ignore
    }
    |> Async.Ignore
    |> Async.RunSynchronously

    0