Imports System.Collections.ObjectModel
Imports System.ComponentModel

Public Class Form1
    Private _list As New List(Of Robot)()
    Private _historicList As New BindingList(Of FightPresentation)()
    Private WithEvents _worker As New BackgroundWorker()

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)

        Me.Init()
    End Sub

    Private Sub Init()
        Me._list.Add(New Robot("droide1") With {.LifePoints = 100})
        Me._list.Add(New Robot("droide2") With {.LifePoints = 100})


        Me.DataGridView1.DataSource = Me._historicList

        AddHandler Me._list(0).StartingFight, AddressOf Robot_Starting
        AddHandler Me._list(0).Winner, AddressOf Robot_WinnerIs
        AddHandler Me._list(0).Fighting, AddressOf Robot_Fighting
    End Sub

    Private Sub Raz()
        For Each item In Me._list
            item.LifePoints = 100
        Next

        Me._historicList.Clear()
    End Sub

    Private Sub Worker_DoWork(sender As Object, e As EventArgs) Handles _worker.DoWork
        Me._list(0).Kill(Me._list(1))
    End Sub

    Private Sub Robot_Starting(sender As Object, e As EventArgs)
        Me.Invoke(Sub()
                      Me.lblInfo.Text = "Démarrage du combat"
                  End Sub)
    End Sub

    Private Sub Robot_Fighting(sender As Object, e As StepEventArgs)
        Dim row As String

        row = String.Format(">> {0} donne un coup de {2} sur {1}", e.Fighter.Name, e.Defender.Name, e.FightValue)

        Me.Invoke(Sub()
                      Me._historicList.Add(New FightPresentation() With
                             {
                                .Fighter = e.Fighter.Name,
                                .Defender = e.Defender.Name,
                                .Point = e.FightValue,
                                .FighterLifePoint = e.Fighter.LifePoints,
                                .DefenderLifePoint = e.Defender.LifePoints
                             })
                  End Sub)
    End Sub

    Private Sub Robot_WinnerIs(sender As Object, e As WinerEventArgs)
        Me.Invoke(Sub()
                      Me.lblInfo.Text = "Le gagnant est " & e.Item.Name
                  End Sub)
    End Sub

    Private Sub btnStartFight_Click(sender As Object, e As EventArgs) Handles btnStartFight.Click
        Me.Raz()

        Me._worker.RunWorkerAsync()
    End Sub
End Class
