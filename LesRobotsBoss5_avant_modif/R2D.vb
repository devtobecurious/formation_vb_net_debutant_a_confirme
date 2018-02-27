Public Class R2D
    Inherits Droide

    Public Sub New(ByVal name As String, ByVal x As Integer, ByVal y As Integer)
        MyBase.New(name, x, y, "laser")

    End Sub

    Public Overrides Sub SeDeplacer(ByVal deplacementX As Integer, ByVal deplacementY As Integer)
        Dim rand As Random = New Random
        If (rand.Next(0, 2) = 1) Then
            MyBase.SeDeplacer(deplacementX, deplacementY)
        Else
            Me.Voler()
        End If

    End Sub

    Public Sub Voler()
        Dim rand As Random = New Random
        Dim coeff As Integer = 10
        Me.CoordonneeX = (rand.Next(0, 50) * coeff)
        Me.CoordonneeY = (rand.Next(0, 50) * coeff)
    End Sub
End Class