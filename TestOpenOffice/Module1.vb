Imports Excel = Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Interop

Module Module1

    Sub Main()
        Dim application = New Excel.Application()

        Dim books = application.Workbooks.Open("C:\Users\evan\Documents\devtobecurious - suivi stagiaires - poei - lyon, temp.xlsx")

        books.Close()

        application.Quit()

        ReleaseObject(books)
    End Sub

    Private Sub ReleaseObject(ByVal obj As Object)

        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

End Module
