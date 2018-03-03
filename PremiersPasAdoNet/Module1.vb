Imports System.Data.Common
Imports MySql.Data.MySqlClient

Module Module1

    Sub Main()
        Dim connection As New MySql.Data.MySqlClient.MySqlConnection()

        Using connection
            connection.ConnectionString = My.Settings.STARWARS_DB_CONNECTION

            Try
                connection.Open()

                Console.WriteLine("0:" & connection.State.ToString())

                Throw New Exception()
            Catch ex As Exception
                Console.WriteLine("Erreur : " & ex.Message)
            End Try

        End Using

        Console.WriteLine("1: " & connection.State.ToString())

        Console.ReadLine()
    End Sub

End Module
