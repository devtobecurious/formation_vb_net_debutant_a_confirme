Namespace My
    <HideModuleName>
    Public Module CustomModule
        Private _extension As New ThreadSafeObjectProvider(Of Integer) ' nécessaire pour la gestion Thread Safe

        Friend ReadOnly Property Test2Property() As Integer
            Get
                Return _extension.GetInstance()
            End Get
        End Property

    End Module
End Namespace
