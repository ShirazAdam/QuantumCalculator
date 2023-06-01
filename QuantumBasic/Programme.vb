Imports Microsoft.Quantum.Simulation.Simulators
Imports Nito.AsyncEx
Imports QuantumArithmetic

Module Programme
    Sub Main()
        AsyncContext.Run(Function() QuantumFunc())
    End Sub

    Async Function QuantumFunc() As Task

        Console.WriteLine("Hello, World!")
        Using quantumSimulator As New QuantumSimulator

            Dim plus As Double = Await quantumSimulator.Run(Of Add, (Double, Double), Double)((3, 4))
            Console.WriteLine($"3 + 4 = {plus}")

            Dim minus As Double = Await quantumSimulator.Run(Of Subtract, (Double, Double), Double)((10, 7))
            Console.WriteLine($"10 - 7 = {minus}")

            Dim product As Double = Await quantumSimulator.Run(Of Multiply, (Double, Double), Double)((5, 6))
            Console.WriteLine($"5 * 6 = {product}")

            Dim shareBetween As Double = Await quantumSimulator.Run(Of Divide, (Double, Double), Double)((12, 3))
            Console.WriteLine($"12 / 3 = {shareBetween}")

            Do While True

                Console.WriteLine("Please enter a number (or type exit to quit): ")
                Dim valueOne As String = Console.ReadLine()

                If (Not String.IsNullOrWhiteSpace(valueOne) AndAlso valueOne.ToLower().Equals("exit")) Then
                    Exit Do
                End If

                Console.WriteLine("Please enter an operator (+, -, x, /, or type exit to quit): ")
                Dim valueOperator As String = Console.ReadLine()

                If (Not String.IsNullOrWhiteSpace(valueOperator) AndAlso valueOperator.ToLower().Equals("exit")) Then
                    Exit Do
                End If

                Console.WriteLine("Please enter a number (or type exit to quit): ")
                Dim valueTwo As String = Console.ReadLine()

                If (Not String.IsNullOrWhiteSpace(valueTwo) AndAlso valueTwo.ToLower().Equals("exit")) Then
                    Exit Do
                End If

                Dim x, y As Double
                If (Not Double.TryParse(valueOne, x) OrElse Not Double.TryParse(valueTwo, y)) Then
                    Console.WriteLine("invalid entry for values!")
                    Continue Do
                ElseIf (String.IsNullOrWhiteSpace(valueOperator)) Then
                    Console.WriteLine("Invalid operator!")
                    Continue Do
                Else
                    Dim output As Double

                    Select Case (valueOperator)
                        Case "+"
                            output = Await quantumSimulator.Run(Of Add, (Double, Double), Double)((x, y))
                            Console.WriteLine(output)
                        Case "-"
                            output = Await quantumSimulator.Run(Of Subtract, (Double, Double), Double)((x, y))
                            Console.WriteLine(output)
                        Case "x"
                            output = Await quantumSimulator.Run(Of Multiply, (Double, Double), Double)((x, y))
                            Console.WriteLine(output)
                        Case "/"
                            output = Await quantumSimulator.Run(Of Divide, (Double, Double), Double)((x, y))
                            Console.WriteLine(output)
                        Case Else
                            Console.WriteLine("Invalid operator!")
                    End Select

                End If
            Loop
        End Using
    End Function

End Module
