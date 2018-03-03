Public Class Form1
    Private _data As New DataTable()
    Private _nbItems As Integer = 0

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)

        Me.Init()
    End Sub

    Private Sub Init()
        AddHandler Me._data.TableNewRow, AddressOf Data_NewRow

        Me._data.TableName = "Robot"

        Dim column As New DataColumn("Id", GetType(Integer)) With {
            .AutoIncrement = True,
            .AutoIncrementSeed = 1,
            .AutoIncrementStep = 1,
            .ReadOnly = True,
            .Unique = True
        }
        _data.Columns.Add(column)

        column = New DataColumn("Name", GetType(String)) With {
            .Unique = False
        }
        _data.Columns.Add(column)

        column = New DataColumn("LifePoint", GetType(Integer)) With {
            .Unique = False
        }
        _data.Columns.Add(column)

        column = New DataColumn("IsAlive", GetType(Boolean), "LifePoint > 0") 'https://msdn.microsoft.com/fr-fr/library/system.data.datacolumn.expression(v=vs.110).aspx
        _data.Columns.Add(column)

        Me._data.PrimaryKey = {Me._data.Columns(0)}
    End Sub

    Private Sub Data_NewRow(sender As Object, e As EventArgs)
        Me.Label1.Text = "Nouvelle ligne"
    End Sub

    Private Sub btnAddRobot_Click(sender As Object, e As EventArgs) Handles btnAddRobot.Click
        Dim row As DataRow
        Dim rand As New Random()

        row = Me._data.NewRow()
        Me._nbItems += 1

        row("Name") = "Robot" & Me._nbItems
        row("LifePoint") = rand.Next(50, 101)
        Me._data.Rows.Add(row)

        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView1.DataSource = Me._data
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If (Me.SaveFileDialog1.ShowDialog() = DialogResult.OK) Then
            Me._data.WriteXml(Me.SaveFileDialog1.FileName) 'attention, le nom est obligatoire
        End If
    End Sub

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        If Me.OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Me._data.ReadXml(Me.OpenFileDialog1.FileName)

            Me.DataGridView1.DataSource = Nothing
            Me.DataGridView1.DataSource = Me._data
        End If
    End Sub
End Class
