Imports MySql.Data.MySqlClient

Module Module1


    Sub Main()
        Dim connection As New MySqlConnection()

        Using connection
            connection.ConnectionString = My.Settings.STARWARS_DB_CONNECTION

            Try
                connection.Open()

                Console.WriteLine("0:" & connection.State.ToString())


                Dim request As String = "SELECT Id, Name From Robot"
                Using command As New MySqlCommand(request, connection)
                    Using reader As MySqlDataReader = command.ExecuteReader()
                        While reader.Read()
                            Console.WriteLine(reader("Id") & " : " & reader("Name"))
                        End While

                    End Using

                    Using reader As MySqlDataReader = command.ExecuteReader(CommandBehavior.SchemaOnly)
                        Dim data = reader.GetSchemaTable()

                        For Each row As DataRow In data.Rows
                            For Each cell In row.ItemArray
                                Console.WriteLine(cell)
                            Next
                        Next
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
