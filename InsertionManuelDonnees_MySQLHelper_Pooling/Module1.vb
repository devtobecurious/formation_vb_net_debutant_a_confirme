Imports MySql.Data.MySqlClient

Module Module1

    Sub Main()
        Dim connection As New MySqlConnection()
        Dim request As String = "INSERT INTO Jedi (name, lifepoint) Values ('{0}', {1}) "

        Dim dico As New Dictionary(Of String, String)()

        Console.WriteLine("Saississez le nom")
        dico.Add("name", Console.ReadLine())

        Console.WriteLine("Saississez le nombre de points de vie")
        dico.Add("lifepoint", Console.ReadLine())

        Using connection
            connection.ConnectionString = My.Settings.STARWARS_DB_CONNECTION

            Try
                connection.Open()

                Console.WriteLine("0:" & connection.State.ToString())

                Using reader2 = MySqlHelper.ExecuteReader(connection, "SELECT Name FROM Jedi")
                    While reader2.Read()
                        Console.WriteLine("Jedi : " & reader2("Name"))
                    End While
                End Using

            Catch ex As Exception
                Console.WriteLine("Erreur : " & ex.Message)
            End Try

        End Using

        Console.WriteLine("1: " & connection.State.ToString())

        MySqlHelper.ExecuteNonQuery(My.Settings.STARWARS_DB_CONNECTION, String.Format(request, dico("name"), dico("lifepoint")))

        Console.ReadLine()
    End Sub

End Module
