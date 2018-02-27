Imports System.Collections.ObjectModel

Public Class Robot
    Public Event Winner(ByVal sender As Object, ByVal e As WinerEventArgs)
    Public Event StartingFight(ByVal sender As Object, ByVal e As EventArgs)
    Public Event Fighting(ByVal sender As Object, ByVal e As StepEventArgs)

    Private _lifePoints As Integer = 100

    Public Sub New(name As String)
        Me.Name = name
    End Sub

    Public Sub Kill(robot As Robot)
        Dim winer As Robot = Me

        RaiseEvent StartingFight(Me, New EventArgs())

        While (robot.IsAlive AndAlso Me.IsAlive)
            Me.Attack(robot)
            robot.Attack(Me)
        End While

        If (robot.IsAlive) Then
            winer = robot
        End If

        RaiseEvent Winner(Me, New WinerEventArgs() With {.Item = winer})
    End Sub

    Private Sub Attack(rob As Robot)
        Dim rand As New Random()
        Dim max As Integer = rand.Next(20, 50)
        Dim val As Integer = rand.Next(0, max)

        rob.LifePoints -= val

        Threading.Thread.Sleep(200)

        RaiseEvent Fighting(Me, New StepEventArgs() With {.FightValue = val, .Defender = rob, .Fighter = Me})
    End Sub

    Public Property LifePoints As Integer
        Get
            Return _lifePoints
        End Get
        Set(value As Integer)
            _lifePoints = value
        End Set
    End Property

    Public Property IsAlive As Integer
        Get
            Return Me._lifePoints > 0
        End Get
        Set(value As Integer)

        End Set
    End Property

    Public Property Name As String

End Class
