Public Class Calculateur

    Public Sub Execute(ByVal val As Integer, ByVal val2 As Integer, ByVal display As Action(Of Integer))
        val = val * 10
        val2 = val / 10

        display(val + val2)
    End Sub
End Class
