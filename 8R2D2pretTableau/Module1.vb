Module Module1

    Sub Main()
        Dim unTableauUneDimension() As Integer = New Integer((5) - 1) {}
        Dim unSecondTableauUneDimension() As Integer = {1, 2, 3}


        Dim unTroisiemeTableauUneDimension() As String = New String() {"chaine 1", "chaine 2", "chaine 3"}
        ' Comment parcourir un tableau ?
        ' It�ration compl�te
        Dim i As Integer = 0
        Do While (i < unTableauUneDimension.Length)
            Console.WriteLine(("1. Tableau un, valeur[" _
                            + (i + ("] = " + unTableauUneDimension(i)))))
            ' Les valeurs de types primitifs sont pr�initialis�es � 0
            i = (i + 1)
        Loop


        i = 0
        Do While (i < unSecondTableauUneDimension.Length)
            Console.WriteLine(("2. Tableau deux, valeur[" _
                            + (i + ("] = " + unSecondTableauUneDimension(i)))))
            i = (i + 1)
        Loop

        i = 0
        Do While (i < unTroisiemeTableauUneDimension.Length)
            Console.WriteLine(("3. Tableau trois, valeur[" _
                            + (i + ("] = " + unTroisiemeTableauUneDimension(i)))))
            i = (i + 1)
        Loop

        Console.WriteLine(("4. Average : " + unTableauUneDimension.Average))
        Console.WriteLine(("5. Average : " + unSecondTableauUneDimension.Average))
        Console.WriteLine(("6. Contient 2 ? " + unSecondTableauUneDimension.Contains(2)))
        Dim value As Integer = CType(unSecondTableauUneDimension.GetValue(2), Integer)
        Console.WriteLine(("7. R�cup�ration de la valeur � l'index 2 : " + value))
        Console.WriteLine(("8. Longueur du tableau : " + unSecondTableauUneDimension.Length))
        Console.WriteLine(("9. Max : " + unSecondTableauUneDimension.Max))
        Console.WriteLine(("10. Min : " + unSecondTableauUneDimension.Min))
        ' Parler de : unSecondTableauUneDimension.Rank
        ' Affectation valeur : 
        value = unSecondTableauUneDimension(2)
        unSecondTableauUneDimension(2) = 5
        Console.WriteLine(("11. Valeur avant : " _
                        + (value + (", apr�s : " + unSecondTableauUneDimension(2)))))
        ' ou bien
        value = unSecondTableauUneDimension(2)
        unSecondTableauUneDimension.SetValue(10, 2)
        Console.WriteLine(("11. Valeur avant : " _
                        + (value + (", apr�s : " + unSecondTableauUneDimension(2)))))



        Dim twoSidedCube = {{{1, 2}, {3, 4}}, {{5, 6}, {7, 8}}}

        Dim scores1 = {{10S, 10S, 10S}, {10S, 10S, 10S}}
        Dim scores2 As Short(,) = {{10, 10, 10}, {10, 10, 10}}

        Dim numbers = {{1, 2}, {3, 4}, {5, 6}}


        ' a montrer après le tp
        For index0 = 0 To numbers.GetUpperBound(0)
            For index1 = 0 To numbers.GetUpperBound(1)
                Console.Write(numbers(index0, index1).ToString & " ")
            Next
            Console.WriteLine("")
        Next
    End Sub

End Module
