Module Module1

    Sub Main()
        JeParle()
        JeParleAvecUnMessage("1 Je suis un robot")
        JeParleAvecUnMessageFormate("2 Je suis un robot")
        JeSaisAdditionnerDeuxValeurs(1, 2)

        Dim retour As Integer = 0
        JeSaisAdditionnerDeuxValeursAvecUnRetour1(1, 2, retour)
        Console.WriteLine(("3 La valeur retour de l'addition vaut : " + retour))

        ' Ref permet de passer une r�f�rence vers cette variable => les variables dans les m�thodes sont en fait des copies des valeurs
        JeSaisAdditionnerDeuxValeursAvecUnRetourRef(1, 2, retour)
        Console.WriteLine(("4 ref La valeur retour de l'addition vaut : " + retour))
        JeSaisAdditionnerDeuxValeursAvecUnRetourOut(1, 2, retour)
        Console.WriteLine(("5 out La valeur retour de l'addition vaut : " + retour))

        Dim retour2 As Integer
        JeSaisAdditionnerDeuxValeursAvecUnRetourOut(1, 2, retour2)
        Console.WriteLine(("6 out La valeur retour de l'addition vaut : " + retour2))

        Dim retour3 As Integer
        Dim retour4 As Integer = JeSaisAdditionnerDeuxValeursAvecUnRetour(1, 2)
        Console.WriteLine(("8 fonction La valeur retour de l'addition vaut : " + retour4))

        Dim nouveauMessage As String = "Un message pour Le�a"
        JeParleAvecUnMessageEtJeReponds(nouveauMessage)
        Console.WriteLine(("9 Le message re�u est : " + nouveauMessage))

        Dim estPrimitive As Boolean = GetType(System.String).IsPrimitive
        Console.WriteLine(("String est primitif ?" + estPrimitive))

        ' mais transmet bien une copie dans la m�thode
        Console.ReadLine()
    End Sub

    Private Sub JeParle()
        Console.WriteLine("Je m'appelle R2D2")
    End Sub

    Private Sub JeParleAvecUnMessage(ByVal message As String)
        Console.WriteLine(("Je m'appelle R2D2, " + message))
    End Sub

    Private Sub JeParleAvecUnMessageEtJeReponds(ByVal message As String)
        Console.WriteLine(("Je m'appelle R2D2, " + message))
        message = "Bien re�u"
    End Sub

    Private Sub JeParleAvecUnMessageFormate(ByVal message As String)
        Console.WriteLine(String.Format("Je m'appelle R2D2, {0}", message))
    End Sub

    Private Sub JeSaisAdditionnerDeuxValeurs(ByVal valeur1 As Integer, ByVal valeur2 As Integer)
        Dim valeur3 As Integer = (valeur1 + valeur2)
        Console.WriteLine(String.Format("Le montant de l'addition vaut {0}", valeur3))
    End Sub

    Private Sub JeSaisAdditionnerDeuxValeursAvecUnRetour1(ByVal valeur1 As Integer, ByVal valeur2 As Integer, ByVal retour As Integer)
        retour = (valeur1 + valeur2)
        Console.WriteLine(String.Format("Le montant de l'addition vaut {0}", retour))
    End Sub

    Private Shared Sub JeSaisAdditionnerDeuxValeursAvecUnRetourRef(ByVal valeur1 As Integer, ByVal valeur2 As Integer, ByRef retour As Integer)
        retour = (valeur1 + valeur2)
        Console.WriteLine(String.Format("Le montant de l'addition vaut {0}", retour))
    End Sub

    Private Shared Sub JeSaisAdditionnerDeuxValeursAvecUnRetourOut(ByVal valeur1 As Integer, ByVal valeur2 As Integer, ByRef retour As Integer)
        retour = (valeur1 + valeur2)
        Console.WriteLine(String.Format("Le montant de l'addition vaut {0}", retour))
    End Sub

    Private Shared Function JeSaisAdditionnerDeuxValeursAvecUnRetour(ByVal valeur1 As Integer, ByVal valeur2 As Integer) As Integer
        Return (valeur1 + valeur2)
    End Function

    ' Compl�ter cette m�thode
    Private Shared Sub JeSaisMultiplier(ByVal valeur1 As Double, ByVal valeur2 As Double, ByVal retour As Double)
        retour = (valeur1 * valeur2)
    End Sub

End Module
