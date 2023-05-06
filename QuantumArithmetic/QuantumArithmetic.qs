namespace QuantumArithmetic {

    open Microsoft.Quantum.Canon;
    open Microsoft.Quantum.Intrinsic;


    operation HelloQ () : Unit
    {
        Message("Hello quantum world!");
    }

    operation Add(x : Int, y : Int) : Int
    {
        return x + y;
    }

    operation Subtract(x : Int, y : Int) : Int
    {
        return x - y;
    }

    operation Multiply(x : Int, y : Int) : Int
    {
        return x * y;
    }

    operation Divide(x : Int, y : Int) : Int
    {
        if (y == 0)
        {
            fail "Divide by zero";
        }

        return x / y;
    }
}
