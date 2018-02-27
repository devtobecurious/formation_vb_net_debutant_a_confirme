Module Module1

    Public Sub Main(ByVal args() As String)
        Console.WriteLine("Je suis R2D2, je sais courir")
        Courir()
        Dim value As Integer = Sommer(1, 2)
        Console.WriteLine(("1. Valeur somm�e : " + value))
        ' Comment alors retourner plusieurs �l�ments ?
        ' Notion de tuples
        Dim resultat As Tuple(Of String, String) = SeparerChaineEnDeux("JESUISUNROBOT")
        Console.WriteLine(("3. Tuple, R�sultat 1 : " _
                        + (resultat.Item1 + (", resultat 2 : " + resultat.Item2))))
        ' D'autre fa�on de retourner plusieurs r�sultats ? 
        ' =>  dictionary, list, ...
        Console.ReadLine()
    End Sub

    Private Function SeparerChaineEnDeux(ByVal chaine As String) As Tuple(Of String, String)
        Dim halfPartIndex As Integer = (chaine.Length / 2)
        Return New Tuple(Of String, String)(chaine.Substring(0, halfPartIndex), chaine.Substring(halfPartIndex, (chaine.Length - halfPartIndex)))
    End Function

    ''' <summary>
    ''' 1 M�thode pour faire courir le robot
    ''' </summary>
    Private Sub Courir()
        Dim i As Integer = 0
        Do While (i < 10)
            Console.WriteLine(("Je me d�place de " _
                            + (i + "km")))
            i = (i + 1)
        Loop

    End Sub

    Private Function Sommer(ByVal a As Integer, ByVal b As Integer) As Integer
        Return (a + b)
    End Function

End Module
