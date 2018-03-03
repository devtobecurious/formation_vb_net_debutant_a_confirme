Imports MySql.Data.MySqlClient

Public Class Form1
    Private _data As New DataSet

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click

        Using connection As New MySql.Data.MySqlClient.MySqlConnection()
            connection.ConnectionString = My.MySettings.Default.CONNEC

            ' Deux tables, mais non pas définis
            ' mais pas de relations ! 
            Dim request = "SELECT * from Robot; SELECT * from Localization;"
            Using adapter As New MySql.Data.MySqlClient.MySqlDataAdapter(request, connection)
                adapter.FillSchema(Me._data, SchemaType.Mapped)
                adapter.Fill(Me._data)
            End Using

            Me.LoadData()
        End Using
    End Sub

    Private Sub LoadData()
        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView1.DataSource = Me._data.Tables(0)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Using connection As New MySql.Data.MySqlClient.MySqlConnection()
            connection.ConnectionString = My.MySettings.Default.CONNEC


            Using adapter As New MySql.Data.MySqlClient.MySqlDataAdapter()
                AddHandler adapter.RowUpdating, AddressOf Adapter_RowUpdating
                AddHandler adapter.FillError, AddressOf Adapter_FillError

                adapter.SelectCommand = New MySqlCommand() With
                {
                    .CommandText = "SELECT * FROM Robot",
                    .Connection = connection
                }

                Dim builder As New MySqlCommandBuilder(adapter)

                adapter.InsertCommand = builder.GetInsertCommand()
                adapter.UpdateCommand = builder.GetUpdateCommand()

                Dim dataChanges = Me._data.Tables(0).Select(Nothing, Nothing, DataViewRowState.ModifiedOriginal)
                Dim dataAdded = Me._data.Tables(0).Select(Nothing, Nothing, DataViewRowState.Added)

                'adapter.Update(dataAdded)
                'adapter.Update(dataChanges)

                ' Ou 
                Dim tableWithChange = Me._data.Tables(0).GetChanges()
                adapter.Update(tableWithChange)

                Me._data.Tables(0).Merge(tableWithChange)
                Me._data.Tables(0).AcceptChanges()
                'Me._data.Tables(0).RejectChanges()

                RemoveHandler adapter.RowUpdating, AddressOf Adapter_RowUpdating
                RemoveHandler adapter.FillError, AddressOf Adapter_FillError
            End Using
        End Using
    End Sub

    Private Sub btnAdd_Click_1(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim row As DataRow

        row = Me._data.Tables(0).NewRow()

        row("Name") = Me.TextBox1.Text
        row("LifePoint") = Me.TextBox2.Text

        Me._data.Tables(0).Rows.Add(row)
    End Sub

    Private Sub Adapter_RowUpdating(sender As Object, e As EventArgs)

    End Sub

    Private Sub Adapter_FillError(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me._data.RejectChanges()
        Me.LoadData()
    End Sub
End Class
