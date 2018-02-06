Module Module1

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
    End Sub
End Module
