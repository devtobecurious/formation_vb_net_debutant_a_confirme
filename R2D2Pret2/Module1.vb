Module Module1

    ''' <summary>
    ''' Commentaire de classe
    ''' </summary>
    Sub Main()
        ' test

        For i = 0 To 10

        Next



        For index = 1 To 1000
            If index = 1000 Then
                Throw New Exception()
            End If
        Next

        Dim array(5) As Integer



        Console.WriteLine(array.Length)

        Console.ReadLine()
    End Sub

End Module
