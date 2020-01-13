Public Class Form1
    Public Sub New()

        ' Cet appel est requis par le concepteur.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        'Using graphics = Me.CreateGraphics()
        '    graphics.DrawEllipse(New Pen(SystemColors.ButtonFace), New Rectangle())
        'End Using


    End Sub

    ' https://stackoverflow.com/questions/17895619/how-to-draw-a-line-in-vb-net
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)

        e.Graphics.DrawLine(Pens.Blue, 10, 10, 100, 100)

        Dim myPen As Pen

        'myPen = New Pen(Color.Blue, Width = 2)

        'e.Graphics.DrawLine(myPen, 100, 150, 150, 100)

    End Sub
End Class
