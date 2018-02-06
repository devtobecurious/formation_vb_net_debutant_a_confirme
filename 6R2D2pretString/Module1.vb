Module Module1

    Sub Main()
        Console.WriteLine("Je suis R2D2, pr�t pour le combat")
        Dim maValeur As String = "Je suis un robot"
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
        Console.WriteLine(("7. Chaine vide ? " + estVide))
        Console.ReadLine()
    End Sub

End Module
