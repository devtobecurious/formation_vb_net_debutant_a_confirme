Public Class NonValidCoordoonneeException
    Inherits Exception

    Public Sub New()
        MyBase.New

    End Sub

    Public Sub New(ByVal message As String)
        MyBase.New(message)

    End Sub

    Public Sub New(ByVal message As String, ByVal inner As Exception)
        MyBase.New(message, inner)

    End Sub

    Public Property Robot As Robot
        Get
            Return Me.Data("robot")
        End Get
        Set(value As Robot)
            Me.Data("robot") = value
        End Set
    End Property
End Class