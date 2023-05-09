namespace QuantumArithmetic {

    open Microsoft.Quantum.Canon;
    open Microsoft.Quantum.Intrinsic;


    operation HelloQ () : Unit
    {
        Message("Hello quantum world!");
    }

    operation Add(x : Double, y : Double) : Double
    {
        return x + y;
    }

    operation Subtract(x : Double, y : Double) : Double
    {
        return x - y;
    }

    operation Multiply(x : Double, y : Double) : Double
    {
        return x * y;
    }

    operation Divide(x : Double, y : Double) : Double
    {
        if (y == 0.0)
        {
            fail "Divide by zero";
        }

        return x / y;
    }
}
