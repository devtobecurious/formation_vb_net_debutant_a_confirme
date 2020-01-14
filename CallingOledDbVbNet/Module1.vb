Imports System.Data.OleDb

Module Module1

    Sub Main()
        Dim cmd As OleDbDataAdapter

        Dim ds As New DataSet()

        Dim cn As OleDbConnection

        cn = New System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;" + "data source=C:\Users\evan\Documents\devtobecurious - suivi stagiaires - poei - lyon, temp.xlsx;Extended Properties=Excel 8.0;")

        cmd = New System.Data.OleDb.OleDbDataAdapter("select * from [Feuil1$]", cn)

        cn.Open()

        cmd.Fill(ds, "Table1")

        cn.Close()
    End Sub

End Module
