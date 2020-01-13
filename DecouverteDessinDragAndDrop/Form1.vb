Imports System.Drawing.Drawing2D

Public Class Form1
    Private _graphics As Graphics
    Private _state As GraphicsState

    Protected Overrides Sub OnPaint(e As PaintEventArgs)

    End Sub

    Protected Overrides Sub OnMouseCaptureChanged(e As EventArgs)
        MyBase.OnMouseCaptureChanged(e)
    End Sub

    Protected Overrides Sub OnMouseClick(e As MouseEventArgs)
        MyBase.OnMouseClick(e)

        'Me.CreateGraphics().DrawLine(Pens.Blue, e.X, e.Y, e.X + 100, e.Y + 100)

        'Me.CreateGraphics().DrawLine(Pens.Red, e.X, e.Y, e.X + 1, e.Y + 1)
        'Me.CreateGraphics().DrawRectangle(Pens.Red, e.X, e.Y, 1, 1)
    End Sub

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        MyBase.OnMouseDown(e)


    End Sub

    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
        MyBase.OnMouseMove(e)



        If Me._graphics IsNot Nothing AndAlso e.Button = MouseButtons.Left Then
            Me._graphics.DrawRectangle(Pens.Red, e.X, e.Y, 1, 1)
        Else

        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me._graphics = Me.CreateGraphics()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Invalidate()
    End Sub
End Class
