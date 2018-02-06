Module Module1

    Sub Main()
        Dim unTableauUneDimension() As Integer = New Integer() {1, 2, 3, 4, 5}
        ' Comment parcourir un tableau ?
        ' It�ration compl�te
        Dim i As Integer = 0
        Do While (i < unTableauUneDimension.Length)
            Console.WriteLine(("1. Tableau un, valeur[" _
                            + (i + ("] = " + unTableauUneDimension(i)))))
            ' Les valeurs de types primitifs sont pr�initialis�es � 0
            i = (i + 1)
        Loop

        Dim j As Integer = 0
        While (j < unTableauUneDimension.Length)
            Console.WriteLine(("2. Tableau un, valeur[" _
                            + (j + ("] = " + unTableauUneDimension(j)))))
            j = (j + 1)
        End While

        Dim k As Integer = 0

        While (k < unTableauUneDimension.Length)
            Console.WriteLine(("3. Tableau un, valeur[" _
                            + (k + ("] = " + unTableauUneDimension(k)))))

        End While

        k = 0

        While (k < unTableauUneDimension.Length)
            Console.WriteLine(("3. Tableau un, valeur[" _
                            + (k + ("] = " + unTableauUneDimension(k)))))
            k = (k + 1)

        End While

        ' Conditions
        If True Then
            Console.WriteLine("4. Le if valide une valeur bool�enne � true")
        End If

        If False Then
            Console.WriteLine("5. Le if valide une valeur bool�enne, on ne passe pas ici")
        Else
            Console.WriteLine("5. Le if valide une valeur bool�enne, on passe ici")
        End If

        If (unTableauUneDimension(0) = 1) Then
            Console.WriteLine("6. On v�rifier la valeur et on entre dans le if")
        End If

        If (unTableauUneDimension(2) = 2) Then
            Console.WriteLine("7. On ne passera jamais ici")
        End If

        ' D�couverte du switch
        i = 0
        Do While (i < unTableauUneDimension.Length)
            Select Case (unTableauUneDimension(i))
                Case 1
                    Console.WriteLine("8. Valeur 1 trouv�e")
                Case 2
                    Console.WriteLine("8. Valeur 2 trouv�e")
                Case Else
                    Console.WriteLine(("8. Autre valeur trouv�e : " + unTableauUneDimension(i)))
            End Select

            i = (i + 1)
        Loop

        If (5 = 4) Then
            Console.WriteLine("9 => 1")
        ElseIf ((10 / 2) _
                    = 5) Then
            Console.WriteLine("9 => 2")
        Else
            Console.WriteLine("9 => 3")
        End If

        Dim valeur As enumATroisValeurs = enumATroisValeurs.Etat1
        Select Case (valeur)
            Case enumATroisValeurs.Etat1
                Console.WriteLine("10 => Etat 1")
            Case enumATroisValeurs.Etat2
                Console.WriteLine("10 => Etat 2")
            Case enumATroisValeurs.Etat3
                Console.WriteLine("10 => Etat 3")
        End Select

        ' Enum peut aussi prendre plusieurs valeurs en une seule (notion de byte)
        valeur = (enumATroisValeurs.Etat3 Or enumATroisValeurs.Etat2)
        Select Case (valeur)
            Case enumATroisValeurs.Etat1
                Console.WriteLine("11 => Etat 1")
            Case enumATroisValeurs.Etat2
                Console.WriteLine("11 => Etat 2")
            Case (enumATroisValeurs.Etat3 Or enumATroisValeurs.Etat2)
                Console.WriteLine("11 => Etat 3 ou deux")
        End Select

        valeur = (enumATroisValeurs.Etat3 And enumATroisValeurs.Etat2)
        Select Case (valeur)
            Case enumATroisValeurs.Etat1
                Console.WriteLine("12 => Etat 1")
            Case enumATroisValeurs.Etat2
                Console.WriteLine("12 => Etat 2")
            Case (enumATroisValeurs.Etat3 And enumATroisValeurs.Etat2)
                Console.WriteLine("12 => Etat 3 et deux")
        End Select

        Console.ReadLine()
    End Sub

    Enum enumATroisValeurs

        Etat1 = 0

        Etat2 = 3

        Etat3 = 5
    End Enum
End Module
