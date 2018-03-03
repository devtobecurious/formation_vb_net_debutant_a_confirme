Imports System.Data.Entity

'Même namespace que Entities
Public Class MyDbConfiguration
    Inherits DbConfiguration

    Public Sub New()
        Me.SetDatabaseLogFormatter(Function(context, writeAction)
                                       Return New MyLogFormater(context, writeAction)
                                   End Function)
    End Sub

End Class
