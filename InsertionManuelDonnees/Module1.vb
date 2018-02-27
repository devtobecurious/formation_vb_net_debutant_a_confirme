Imports MySql.Data.MySqlClient

Module Module1

    Sub Main()
        Dim connection As New MySqlConnection()

        Using connection
            connection.ConnectionString = My.Settings.STARWARS_DB_CONNECTION

            Try
                connection.Open()

                Console.WriteLine("0:" & connection.State.ToString())


                Dim dico As New Dictionary(Of String, String)()
                Dim request As String = "INSERT INTO Jedi (name, lifepoint) Values ('{0}', {1}) "

                Console.WriteLine("Saississez le nom")
                dico.Add("name", Console.ReadLine())

                Console.WriteLine("Saississez le nombre de points de vie")
                dico.Add("lifepoint", Console.ReadLine())

                Using command As New MySqlCommand(request, connection)
                    command.CommandText = String.Format(request, dico("name"), dico("lifepoint"))
                    command.ExecuteNonQuery()

                    command.CommandText = "SELECT Name FROM Jedi"
                    Using reader = command.ExecuteReader()
                        While reader.Read()
                            Console.WriteLine("Jedi : " & reader("Name"))
                        End While
                    End Using
                End Using



            Catch ex As Exception
                Console.WriteLine("Erreur : " & ex.Message)
            End Try

        End Using

        Console.WriteLine("1: " & connection.State.ToString())

        Console.ReadLine()
    End Sub

End Module
