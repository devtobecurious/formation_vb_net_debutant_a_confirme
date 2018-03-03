Public Class Calculateur
    Private _list As New List(Of Integer)
    Private _max As Integer
    Public Event StartInit(ByVal sender As Object, e As EventArgs)
    Public Event EndInit(ByVal sender As Object, e As EventArgs)
    Public Event StartComputing(ByVal sender As Object, e As EventArgs)
    Public Event EndComputing(ByVal sender As Object, e As EventArgs)
    Public Event TotalMultiple10(ByVal sender As Object, e As ValueEventArgs)

    Public Sub Initialiser(Optional max As Integer = 100000)
        RaiseEvent StartInit(Me, New EventArgs())

        Me._max = max

        For index = 1 To max
            _list.Add(index)
        Next

        RaiseEvent EndInit(Me, New EventArgs())
    End Sub

    Public Function Calculer() As Integer
        Dim total As Integer

        RaiseEvent StartComputing(Me, New EventArgs())

        For index = 0 To Me._max - 1
            total += Me._list(index)

            If total Mod 10 = 0 Then
                RaiseEvent TotalMultiple10(Me, New ValueEventArgs() With {.Value = total})
            End If

            Threading.Thread.Sleep(100)
        Next

        RaiseEvent EndComputing(Me, New EventArgs())

        Return total
    End Function
End Class
