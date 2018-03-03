Imports System.Data.Common
Imports MySql.Data.MySqlClient

Module Module1

    Sub Main()
        Dim connectionString = My.MySettings.Default.DATABASE_CONFIG_SETTING

        Dim factory As DbProviderFactory = DbProviderFactories.GetFactory("MySql.Data.MySqlClient")

        'https://stackoverflow.com/questions/3488962/how-to-create-a-dbdataadapter-given-a-dbcommand-or-dbconnection
        Dim adapter = factory.CreateDataAdapter() ' ne fonctionne pas => bug

        Using connection = factory.CreateConnection()
            connection.ConnectionString = "Server=localhost;Database=starwars_db;Uid=root;Pwd=coucou_2510?;"

            adapter = New MySqlDataAdapter()

            Dim data As New DataTable()
            'data.Load(command.ExecuteReader(CommandBehavior.CloseConnection))

            ' => https://www.codeproject.com/Articles/55890/Don-t-hard-code-your-DataProviders
            Dim dt = System.Data.Common.DbProviderFactories.GetFactoryClasses()

            adapter.SelectCommand = connection.CreateCommand()
            adapter.SelectCommand.CommandText = "SELECT * FROM Robot"

            Dim commandBuilder As DbCommandBuilder = factory.CreateCommandBuilder() 'ne fonctionne pas

            commandBuilder = New MySqlCommandBuilder(adapter)
            adapter.InsertCommand = commandBuilder.GetInsertCommand(True)
            adapter.UpdateCommand = commandBuilder.GetUpdateCommand(True)

            AddHandler CType(adapter, MySqlDataAdapter).RowUpdating, AddressOf RowUpdating
            adapter.Fill(data)

            Dim row As DataRow = data.NewRow()
            row("Name") = "Essai"

            data.Rows.Add(row)

            adapter.Update(data)


            Using command = connection.CreateCommand()
                command.CommandText = "SELECT * from Robot"
                connection.Open()

                Using reader = command.ExecuteReader()
                    data = New DataTable()
                    data.Load(command.ExecuteReader(CommandBehavior.CloseConnection))
                End Using





            End Using
        End Using

    End Sub

    Public Sub RowUpdating(sender As Object, e As MySqlRowUpdatingEventArgs)

    End Sub
End Module
