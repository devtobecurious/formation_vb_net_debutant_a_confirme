Public Class Form1
    WithEvents _timer As New Timer()  ' (Container) utile si durée de vie lié au container =>  dispose
    Private _timer2 As New Timer()
    Private _count As Integer = 0

    Private Sub timer_Tick(sender As Object, e As EventArgs) Handles _timer.Tick
        Me.Label3.Text = "timer  : " & DateTime.Now.ToString("HH:mm:ss")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Label1.Text = DateTime.Now
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click, Button3.Click
        Me.Label1.Text = Guid.NewGuid().ToString()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.Label2.Text = "Timer1  :" & DateTime.Now.ToString("HH:mm:ss")
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs)
        Me._count += 1
        Me.Label4.Text = "Timer2  : " & DateTime.Now.ToString("HH:mm:ss") & " (" & _count & ")"
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Timer1.Interval = 1000
        Me.Timer1.Start()

        Me._timer.Interval = 2000
        Me._timer.Start()

        AddHandler Me._timer2.Tick, AddressOf Timer2_Tick

        Me._timer2.Interval = 5000
        Me._timer2.Start()

        'RemoveHandler Me._timer2.Tick, AddressOf Timer2_Tick si on le met ici, ça empêche les événements
    End Sub

    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        RemoveHandler Me._timer2.Tick, AddressOf Timer2_Tick
    End Sub
End Class
