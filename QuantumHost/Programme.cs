// See https://aka.ms/new-console-template for more information
using Microsoft.Quantum.Simulation.Simulators;
using QuantumArithmetic;

Console.WriteLine("Hello, World!");
using var quantumSimulator = new QuantumSimulator();

var plus = await quantumSimulator.Run<Add, (long, long), long>((3, 4));
Console.WriteLine($"3 + 4 = {plus}");

var minus = await quantumSimulator.Run<Subtract, (long, long), long>((10, 7));
Console.WriteLine($"10 - 7 = {minus}");

var product = await quantumSimulator.Run<Multiply, (long, long), long>((5, 6));
Console.WriteLine($"5 * 6 = {product}");

var shareBetween = await quantumSimulator.Run<Divide, (long, long), long>((12, 3));
Console.WriteLine($"12 / 3 = {shareBetween}");