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
                Dim request As String = "INSERT INTO Jedi (name, lifepoint) Values (@name, @lifepoint) "

                Console.WriteLine("Saississez le nom")
                dico.Add("name", Console.ReadLine())

                Console.WriteLine("Saississez le nombre de points de vie")
                dico.Add("lifepoint", Console.ReadLine())

                Using command As New MySqlCommand(request, connection)
                    command.CommandType = CommandType.TableDirect
                    command.CommandText = "Jedi"
                    command.CommandTimeout = 1200

                    Using reader = command.ExecuteReader()
                        While reader.Read()
                            Console.WriteLine("Jedi : " & reader("Name"))
                        End While
                    End Using

                    command.CommandText = request
                    'command.CommandType = CommandType.TableDirect // retourne toute la table, direct
                    command.CommandType = CommandType.Text

                    Dim param As MySqlParameter = command.CreateParameter()
                    param.DbType = DbType.String
                    param.Direction = ParameterDirection.Input
                    param.MySqlDbType = MySqlDbType.VarChar
                    param.ParameterName = "name"
                    param.Value = dico("name")

                    command.Parameters.Add(param)

                    param = command.CreateParameter()
                    param.DbType = DbType.Int32
                    param.Direction = ParameterDirection.Input
                    param.MySqlDbType = MySqlDbType.Int32
                    param.ParameterName = "lifepoint"
                    param.Value = dico("lifepoint")

                    command.Parameters.Add(param)

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
