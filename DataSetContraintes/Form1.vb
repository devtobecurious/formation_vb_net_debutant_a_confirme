Public Class Form1
    Private _bdd As New DataSet()
    Private _data As New DataTable()
    Private _dataLocalization As New DataTable()
    Private _nbItems As Integer = 0

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)

        Me.Init()
    End Sub

    Private Sub Init()
        Me.InitLocalization()
        Me.InitRobot()
        Me.AddRelations()
        Me.AddCustomColumns()
    End Sub

    Private Sub AddRelations()
        Dim relation As New DataRelation("localization_robot", Me._dataLocalization.Columns("Id"), Me._data.Columns("LocalizationId"))
        Me._bdd.Relations.Add(relation)
    End Sub

    Private Sub AddCustomColumns()
        Dim column As DataColumn

        column = New DataColumn("IsAlive", GetType(Boolean), "LifePoint > 0") 'https://msdn.microsoft.com/fr-fr/library/system.data.datacolumn.expression(v=vs.110).aspx
        _data.Columns.Add(column)

        column = New DataColumn("Coordonnees:X", GetType(Decimal), "Parent.X") 'https://msdn.microsoft.com/fr-fr/library/system.data.datacolumn.expression(v=vs.110).aspx
        _data.Columns.Add(column)

        column = New DataColumn("Coordonnees:Y", GetType(Decimal), "Parent.Y") 'https://msdn.microsoft.com/fr-fr/library/system.data.datacolumn.expression(v=vs.110).aspx
        _data.Columns.Add(column)
    End Sub

    Private Sub InitLocalization()
        AddHandler Me._dataLocalization.TableNewRow, AddressOf Data_NewRow

        Me._dataLocalization.TableName = "Localization"

        Dim column As New DataColumn("Id", GetType(Integer)) With {
            .AutoIncrement = True,
            .AutoIncrementSeed = 1,
            .AutoIncrementStep = 1,
            .ReadOnly = True,
            .Unique = True
        }
        Me._dataLocalization.Columns.Add(column)

        column = New DataColumn("X", GetType(Decimal)) With {
            .Unique = False
        }
        Me._dataLocalization.Columns.Add(column)

        column = New DataColumn("Y", GetType(Decimal)) With {
            .Unique = False
        }
        Me._dataLocalization.Columns.Add(column)

        Me._dataLocalization.PrimaryKey = {Me._dataLocalization.Columns("Id")}

        Me._bdd.Tables.Add(Me._dataLocalization)
    End Sub

    Private Sub InitRobot()
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

        column = New DataColumn("LocalizationId", GetType(Integer)) With {
            .Unique = False
        }
        _data.Columns.Add(column)

        Me._data.PrimaryKey = {Me._data.Columns("Id")}

        Me._bdd.Tables.Add(Me._data)
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

        Dim child = Me._dataLocalization.NewRow()

        child("X") = rand.Next(0, 1000)
        child("Y") = rand.Next(0, 1000)

        row("Localizationid") = child("Id")

        Me._dataLocalization.Rows.Add(child)

        Me._data.Rows.Add(row)

        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView1.DataSource = Me._data
    End Sub
End Class
