Public Class MaPremiereClasse

    Private Const MAX_X As Integer = 10

    Private Const MAX_Y As Integer = 20

    Private _largeur As Integer

    Private _coordonneeX As Integer

    Private _coordonneeY As Integer

    Public Sub New()
        Me.New(0, 0)

    End Sub

    Public Sub New(ByVal taille As Integer)
        Me.New(taille, 0)

    End Sub

    Public Sub New(ByVal taille As Integer, ByVal largeur As Integer)
        MyBase.New
        Me.Taille = taille
        Me._largeur = largeur
    End Sub

    Public Sub SeDeplacer(ByVal deplacementX As Integer, ByVal deplacementY As Integer)
        Me._coordonneeX = (Me._coordonneeX + deplacementX)
        Me._coordonneeY = (Me._coordonneeY + deplacementY)
        Me.VerifierCoordonnees()
        Console.WriteLine(String.Format("Nouvelles coordonn�es : x({0}), y({1})", Me._coordonneeX, Me._coordonneeY))
    End Sub

    Private Overloads Sub VerifierCoordonnees()
        Me.VerifierCoordonnees(Me._coordonneeX, MAX_X)
        Me.VerifierCoordonnees(Me._coordonneeY, MAX_Y)
    End Sub

    Private Overloads Sub VerifierCoordonnees(ByRef valeur As Integer, ByVal constante As Integer)
        If (valeur >= constante) Then
            valeur = constante
        End If

    End Sub

    Public Property Taille As Integer
End Class