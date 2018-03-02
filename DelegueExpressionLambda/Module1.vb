Module Module1

    Sub Main()
        Dim monExpression = Sub(result As Integer)
                                Console.WriteLine("Test : " & result)
                            End Sub

        monExpression.Invoke(12)

        Dim calc As New Calculateur()

        calc.Execute(15, 88, monExpression)

        Console.ReadLine()
    End Sub



End Module
