Public Class MonExceptionTypee2
    Inherits Exception

    Public Sub New()
        MyBase.New

    End Sub

    Public Sub New(ByVal message As String)
        MyBase.New(message)

    End Sub

    Public Sub New(ByVal message As String, ByVal ex As Exception)
        MyBase.New(message, ex)

    End Sub

    Public Property MaValeur As Integer
        Get
            Return CType(Me.Data("MaValeur"), Integer)
        End Get
        Set
            Me.Data("MaValeur") = Value
        End Set
    End Property
End Class