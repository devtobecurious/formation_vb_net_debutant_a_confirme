Public Class Form1
    Private _data As New DataSet

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click

        Using connection As New MySql.Data.MySqlClient.MySqlConnection()
            connection.ConnectionString = My.MySettings.Default.CONNEC

            ' Une seule table, même avec dataset
            'Dim request = "SELECT * from Robot join Localization on Robot.LocalizationId = Localization.Id"
            'Using adapter As New MySql.Data.MySqlClient.MySqlDataAdapter(request, connection)
            '    adapter.FillSchema(Me._data, SchemaType.Source)
            '    adapter.Fill(Me._data)
            'End Using

            ' Deux tables, mais non pas définis
            ' mais pas de relations ! 
            Dim request = "SELECT * from Robot; SELECT * from Localization;"
            Using adapter As New MySql.Data.MySqlClient.MySqlDataAdapter(request, connection)
                adapter.FillSchema(Me._data, SchemaType.Source)
                adapter.Fill(Me._data)
            End Using

            Me.LoadData()
        End Using
    End Sub

    Private Sub LoadData()
        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView1.DataSource = Me._data.Tables(0)
    End Sub
End Class
