Imports System.Data.Common
Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure.Interception

Public Class MyLogFormater
    Inherits DatabaseLogFormatter

    Public Sub New(writeAction As Action(Of String))
        MyBase.New(writeAction)
    End Sub

    Public Sub New(context As DbContext, writeAction As Action(Of String))
        MyBase.New(context, writeAction)
    End Sub

    Public Overrides Sub LogCommand(Of TResult)(command As DbCommand, interceptionContext As DbCommandInterceptionContext(Of TResult))
        Dim message As String

        message = "context " & command.CommandText

        Write(message)
    End Sub
End Class
