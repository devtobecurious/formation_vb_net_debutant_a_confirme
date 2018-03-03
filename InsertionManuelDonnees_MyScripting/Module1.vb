Imports MySql.Data.MySqlClient

Module Module1

    Sub Main()
        Dim connection As New MySqlConnection()


        Using connection
            connection.ConnectionString = My.Settings.STARWARS_DB_CONNECTION

            Try
                'connection.Open() 'pas besoin d'être connecté

                Console.WriteLine("0:" & connection.State.ToString())

                Dim script As New MySqlScript(connection) With {
                    .Delimiter = ";"
                }

                AddHandler script.ScriptCompleted, AddressOf Script_ScriptCompleted

                For index = 1 To 10
                    script.Query &= "INSERT INTO Jedi (Name) Values('SurnomSuper" & index & "');"
                Next

                script.Execute()

            Catch ex As Exception
                Console.WriteLine("Erreur : " & ex.Message)
            End Try

        End Using

        Console.WriteLine("1: " & connection.State.ToString())

        Console.ReadLine()
    End Sub

    Public Sub Script_ScriptCompleted(ByVal sender As Object, e As EventArgs)
        Console.WriteLine("Le script est passé")
    End Sub

End Module
