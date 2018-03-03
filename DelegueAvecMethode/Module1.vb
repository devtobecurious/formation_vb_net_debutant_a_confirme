Module Module1

    Sub Main()
        Dim calc As New Calculateur()

        calc.Execute(200, 20, AddressOf Afficher)

        Console.ReadLine()
    End Sub

    Private Sub Afficher(ByVal result As Integer)
        Console.WriteLine(result)
    End Sub

End Module
