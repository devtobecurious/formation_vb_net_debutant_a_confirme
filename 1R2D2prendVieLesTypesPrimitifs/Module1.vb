Module Module1
    Private Const MONAGE As Integer = 6

    Sub Main()
        ListeTypesPrimitifs()
    End Sub

    Public Sub ListeTypesPrimitifs()
        Dim jeSuisUnBoolean As Boolean = True
        Console.WriteLine(("boolean : " + jeSuisUnBoolean))

        Dim jeSuisUnByte As Byte = 0
        Console.WriteLine(("boolean : " + jeSuisUnByte))

        Dim jeSuisUnEntier As Integer = 0
        Console.WriteLine(("entier : " + jeSuisUnEntier))

        Dim jeSuisUnCaractere As Char = Microsoft.VisualBasic.ChrW(114)
        Console.WriteLine(("caractere : " + jeSuisUnCaractere))

        Dim jeSuisUnDouble As Double = 1
        Console.WriteLine(("double : " + jeSuisUnDouble))

        Dim jeSuisUnDecimal As Single = 2
        Console.WriteLine(("decimal : " + jeSuisUnDecimal))

        Dim [date] As DateTime = DateTime.Now
        Console.WriteLine(("date : " + [date]))

        Dim monEtat As Etat

        monEtat = Etat.Endormi

        Dim str As String

        Select Case str.ToLower()
            Case "Endormie !".ToLower()

            Case "eveille"

            Case Else

        End Select


        Dim a As Etat

        Select Case a
            Case Etat.Endormi

            Case Etat.Eveille

            Case Else

        End Select
    End Sub


    Public Enum Etat
        Eveille = 1
        Fatigue
        Endormi
    End Enum

End Module
