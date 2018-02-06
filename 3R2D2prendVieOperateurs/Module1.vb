Module Module1

    Sub Main()
        JeParle()
        JeParleAvecUnMessage("1 Je suis un robot")
        JeParleAvecUnMessageFormate("2 Je suis un robot")
        Dim retour3 As Integer = JeSaisAdditionnerDeuxValeursAvecUnRetour(1, 2)
        Console.WriteLine(("3 fonction La valeur retour de l'addition vaut : " + retour3))
        Dim retour4 As Double = JeSaisMultiplierEtRenvoyer(2, 3)
        Console.WriteLine(("4 fonction La valeur de la multiplication vaut : " + retour4))
        Dim retour6 As Integer = CType(JeSaisMultiplierEtRenvoyer(2, 3), Integer)
        Console.WriteLine(("6 fonction La valeur de la multiplication vaut : " + retour6))
        Dim floatValue As Single = (1 / 3)
        Dim doubleValue As Double = (1 / 3)
        Dim decimalValue As Decimal = (1 / 3)
        Console.WriteLine("float: {0} double: {1} decimal: {2}", floatValue, doubleValue, decimalValue)
        floatValue = (1.0F / 3)
        doubleValue = 1.0R / 3
        decimalValue = 1D / 3
        Console.WriteLine("float: {0} double: {1} decimal: {2}", floatValue, doubleValue, decimalValue)
        ' Quid alors si l'on r�cup�re une valeur int de deux d�cimaux ?
        'int retour7 = 1.5F * 1.6F; => ne fonctionne pas
        Console.WriteLine(("7 fonction La valeur de la multiplication vaut : " + (1.5! * 1.6!)))
        Dim retour8 As Integer = CType((1.5! * 1.6!), Integer)
        Console.WriteLine(("8 fonction La valeur de la multiplication vaut : " + retour8))
        Dim retour9 As Decimal = retour8
        Console.WriteLine(("9 fonction La valeur de la multiplication vaut : " + retour9))
        Dim retour10 As Double = retour8
        Console.WriteLine(("10 fonction La valeur de la multiplication vaut : " + retour10))
        Dim retour11 As Single = retour8
        Console.WriteLine(("11 fonction La valeur de la multiplication vaut : " + retour11))
        ' Transtypage implicite, car valeur autoris�e plus grande, plus de digits
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

    Private Sub JeSaisAdditionnerDeuxValeursAvecUnRetourRef(ByVal valeur1 As Integer, ByVal valeur2 As Integer, ByRef retour As Integer)
        retour = (valeur1 + valeur2)
        Console.WriteLine(String.Format("Le montant de l'addition vaut {0}", retour))
    End Sub

    Private Sub JeSaisAdditionnerDeuxValeursAvecUnRetourOut(ByVal valeur1 As Integer, ByVal valeur2 As Integer, ByRef retour As Integer)
        retour = (valeur1 + valeur2)
        Console.WriteLine(String.Format("Le montant de l'addition vaut {0}", retour))
    End Sub

    Private Function JeSaisAdditionnerDeuxValeursAvecUnRetour(ByVal valeur1 As Integer, ByVal valeur2 As Integer) As Integer
        Return (valeur1 + valeur2)
    End Function

    ' Compl�ter cette m�thode
    Private Sub JeSaisMultiplier(ByVal valeur1 As Double, ByVal valeur2 As Double, ByVal retour As Double)
        retour = (valeur1 * valeur2)
    End Sub

    Private Function JeSaisMultiplierEtRenvoyer(ByVal valeur1 As Double, ByVal valeur2 As Double) As Double
        Return (valeur1 * valeur2)
    End Function
End Module
