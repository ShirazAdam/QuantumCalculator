// See https://aka.ms/new-console-template for more information
using Microsoft.Quantum.Simulation.Simulators;
using QuantumArithmetic;

Console.WriteLine("Hello, World!");
using var quantumSimulator = new QuantumSimulator();

var plus = await quantumSimulator.Run<Add, (double, double), double>((3, 4));
Console.WriteLine($"3 + 4 = {plus}");

var minus = await quantumSimulator.Run<Subtract, (double, double), double>((10, 7));
Console.WriteLine($"10 - 7 = {minus}");

var product = await quantumSimulator.Run<Multiply, (double, double), double>((5, 6));
Console.WriteLine($"5 * 6 = {product}");

var shareBetween = await quantumSimulator.Run<Divide, (double, double), double>((12, 3));
Console.WriteLine($"12 / 3 = {shareBetween}");

do
{
    Console.WriteLine("Please enter a number (or type exit to quit): ");
    var valueOne = Console.ReadLine();

    if (!string.IsNullOrWhiteSpace(valueOne) && valueOne.ToLower().Equals("exit"))
        break;

    Console.WriteLine("Please enter an operator (+, -, x, /, or type exit to quit): ");
    var valueOperator = Console.ReadLine();

    if (!string.IsNullOrWhiteSpace(valueOperator) && valueOperator.ToLower().Equals("exit"))
        break;

    Console.WriteLine("Please enter a number (or type exit to quit): ");
    var valueTwo = Console.ReadLine();

    if (!string.IsNullOrWhiteSpace(valueTwo) && valueTwo.ToLower().Equals("exit"))
        break;

    if (!double.TryParse(valueOne, out var x) || !double.TryParse(valueTwo, out var y))
    {
        Console.WriteLine("invalid entry for values!");
        return;
    }
    else if (string.IsNullOrWhiteSpace(valueOperator))
    {
        Console.WriteLine("Invalid operator!");
        return;
    }
    else
    {
        double output = 0.0;

        switch (valueOperator)
        {
            case "+":
                output = await quantumSimulator.Run<Add, (double, double), double>((x, y));
                Console.WriteLine(output);
                break;
            case "-":
                output = await quantumSimulator.Run<Subtract, (double, double), double>((x, y));
                Console.WriteLine(output);
                break;
            case "x":
                output = await quantumSimulator.Run<Multiply, (double, double), double>((x, y));
                Console.WriteLine(output);
                break;
            case "/":
                output = await quantumSimulator.Run<Divide, (double, double), double>((x, y));
                Console.WriteLine(output);
                break;
            default:
                Console.WriteLine("Invalid operator!");
                return;
        }
    }
}
while (true);