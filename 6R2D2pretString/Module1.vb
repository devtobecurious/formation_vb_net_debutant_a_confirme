Module Module1

    Sub Main()
        Console.WriteLine("Je suis R2D2, pr�t pour le combat")

        Dim maValeur As String = "Je suis un robot"

        Dim maChaine As String

        Dim i As Integer = 10
        Dim b As Integer = 25
        maChaine = "Ma valeur vaut : " + CStr(i) + ", et ma seconde valeur vaut :" + CStr(b)

        Dim strPattern As String = "Ma valeur vaut : {{{0}, et la seconde valeur vaut {1}"
        maChaine = String.Format(strPattern, i, b, 16)

        Console.WriteLine(maChaine)

        Dim a = maValeur(0)
        maValeur.Trim()

        Dim bb As Char = maValeur(1)










        Dim maSecondeValeur As String = "intelligent"
        Dim concatenation As String = (maValeur + (" " + maSecondeValeur))
        Console.WriteLine(("1. Concatenation : " _
                        + (concatenation + String.Empty)))
        concatenation = concatenation.ToLower
        Console.WriteLine(("2. Mise en minuscule : " + concatenation))
        concatenation = concatenation.ToUpper
        Console.WriteLine(("3. Mise en majuscule : " + concatenation))
        Dim quatriemeCaractere As String = concatenation.Substring(3, 1)
        ' Commence � z�ro
        Console.WriteLine(("4. Affichage 4� caract�re : " + quatriemeCaractere))
        Dim premierCaractere As String = concatenation.Substring(0, 1)
        ' Commence � z�ro
        Console.WriteLine(("4. Affichage 1� caract�re : " + premierCaractere))
        concatenation = concatenation.PadRight((concatenation.Length + 5))
        Console.WriteLine(("5. Ajout de caract�res blancs : " _
                        + (concatenation + ".")))
        Console.WriteLine(("6. Suppression des caract�res blancs : " _
                        + (concatenation.Trim + ".")))
        Dim estVide As Boolean = String.IsNullOrEmpty("")
        Console.WriteLine(("7. Chaine vide ? " + estVide.ToString()))
        Console.ReadLine()
    End Sub

End Module
