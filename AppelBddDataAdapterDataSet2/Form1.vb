Public Class Form1
    Private _data As New DataSet

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click

        Using connection As New MySql.Data.MySqlClient.MySqlConnection()
            connection.ConnectionString = My.MySettings.Default.CONNEC

            ' Une seule table, même avec dataset

            'Using adapter As New MySql.Data.MySqlClient.MySqlDataAdapter(request, connection)
            '    adapter.FillSchema(Me._data, SchemaType.Source)
            '    adapter.Fill(Me._data)
            'End Using

            Dim request = "SELECT * from Robot"
            Using adapter As New MySql.Data.MySqlClient.MySqlDataAdapter(request, connection)
                adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey
                adapter.Fill(Me._data, "Robot")
            End Using

            request = "SELECT * from Localization"
            Using adapter As New MySql.Data.MySqlClient.MySqlDataAdapter(request, connection)
                adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey
                adapter.Fill(Me._data, "Localization")
            End Using

            Dim relation As New DataRelation("localization_robot", Me._data.Tables("Localization").Columns("Id"),
                                                                   Me._data.Tables("Robot").Columns("LocalizationId"))
            Me._data.Relations.Add(relation)

            Me.LoadData()
        End Using
    End Sub

    Private Sub LoadData()
        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView1.DataSource = Me._data.Tables(0)
    End Sub
End Class
