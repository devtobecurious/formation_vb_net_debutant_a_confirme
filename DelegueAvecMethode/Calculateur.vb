Public Class Calculateur
    Delegate Sub AfficherResultat(ByVal result As Integer)

    Public Sub Execute(ByVal val As Integer, ByVal val2 As Integer, ByVal display As AfficherResultat)
        val = val * 10
        val2 = val / 10

        display(val + val2)
    End Sub
End Class
