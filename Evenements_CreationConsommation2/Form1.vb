Imports System.ComponentModel

Public Class Form1
    Private _calc As New Calculateur()
    Private _worker As New BackgroundWorker()
    Private _count As Integer

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler _calc.StartInit, AddressOf Calc_StartInit
        AddHandler _calc.EndInit, AddressOf Calc_EndInit
        AddHandler _calc.StartComputing, AddressOf Calc_StartComputing
        AddHandler _calc.EndComputing, AddressOf Calc_EndComputing
        AddHandler _calc.TotalMultiple10, AddressOf Calc_IsMultiple10

        AddHandler _worker.DoWork, AddressOf Worker_DoWork
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me._calc.Initialiser(10000)

        Me._worker.RunWorkerAsync()
    End Sub

    Private Sub Worker_DoWork(ByVal sender As Object, e As DoWorkEventArgs)
        e.Result = Me._calc.Calculer()
    End Sub

    Private Sub Calc_StartInit(sender As Object, e As EventArgs)
        Me.Invoke(Sub()
                      Me.Label1.Text = "initialisation ...."
                  End Sub)
    End Sub

    Private Sub Calc_EndInit(sender As Object, e As EventArgs)
        Me.Invoke(Sub()
                      Me.Label1.Text = "initialisation finie !"
                  End Sub)
    End Sub

    Private Sub Calc_StartComputing(sender As Object, e As EventArgs)
        Me.Invoke(Sub()
                      Me.Label2.Text = "Démarrage calcul ..."
                  End Sub)
    End Sub

    Private Sub Calc_EndComputing(sender As Object, e As EventArgs)
        Me.Invoke(Sub()
                      Me.Label2.Text = "Calcul fini !"
                  End Sub)
    End Sub

    Private Sub Calc_IsMultiple10(sender As Object, e As ValueEventArgs)
        Me._count += 1

        Dim item As New ListViewItem() With
            {
                .Text = e.Value
            }

        Me.Invoke(Sub()
                      Me.ListView1.Items.Add(item)
                  End Sub)
    End Sub
End Class
