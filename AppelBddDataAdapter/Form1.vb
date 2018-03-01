Public Class Form1
    Private _data As New DataTable

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click

        Using connection As New MySql.Data.MySqlClient.MySqlConnection()
            connection.ConnectionString = My.MySettings.Default.CONNEC

            Dim request = "SELECT * from Robot"

            Using adapter As New MySql.Data.MySqlClient.MySqlDataAdapter(request, connection)
                adapter.FillSchema(Me._data, SchemaType.Source)
                adapter.Fill(Me._data)
            End Using

            Me.LoadData()
        End Using
    End Sub

    Private Sub LoadData()
        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView1.DataSource = Me._data
    End Sub
End Class
