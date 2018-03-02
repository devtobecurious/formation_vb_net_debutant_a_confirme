Module Module1
    Delegate Sub AfficherResultat(message As String)


    Sub Main()
        Dim method As AfficherResultat = AddressOf AfficherAvecDecoration

        method("ceci est un message")

        method = AddressOf AfficherSansDecoration

        method("deuxième message")

        Console.ReadLine()
    End Sub

    Private Sub AfficherAvecDecoration(message As String)
        Console.WriteLine("*************** MESSAGE ******************")
        Console.WriteLine("******************************************")
        Console.WriteLine(message)
        Console.WriteLine("******************************************")
        Console.WriteLine("******************************************")
    End Sub

    Private Sub AfficherSansDecoration(message As String)
        Console.WriteLine(message)
    End Sub

End Module
