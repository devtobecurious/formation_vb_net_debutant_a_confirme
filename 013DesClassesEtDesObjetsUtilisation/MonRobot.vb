Public Class MonRobot

    Private Const MAX_X As Integer = 10000

    Private Const MAX_Y As Integer = 20000

    Private _largeur As Integer

    Private _coordonneeX As Integer

    Private _coordonneeY As Integer

    Public Sub New(ByVal nom As String)
        Me.New(nom, 0, 0)

    End Sub

    Public Sub New(ByVal nom As String, ByVal taille As Integer)
        Me.New(nom, taille, 0)

    End Sub

    Public Sub New(ByVal nom As String, ByVal taille As Integer, ByVal largeur As Integer)
        Me.New(nom, taille, largeur, 0, 0)

    End Sub

    Public Sub New(ByVal nom As String, ByVal taille As Integer, ByVal largeur As Integer, ByVal coordX As Integer, ByVal coordY As Integer)
        MyBase.New
        Me.Taille = taille
        Me._largeur = largeur
        Me._coordonneeX = coordX
        Me._coordonneeY = coordY
        Me.Nom = nom
    End Sub

    ' A montrer =>  ne fonctionne pas car ?
    'public MonRobot(int coordX, int coordY)
    '{
    '}
    Public Sub SeDeplacer(ByVal deplacementX As Integer, ByVal deplacementY As Integer)
        Me._coordonneeX = deplacementX
        Me._coordonneeY = deplacementY
        Me.VerifierCoordonnees()
        Me.AfficherPositionnement()
    End Sub

    Public Sub AfficherPositionnement()
        Console.WriteLine(String.Format("{2} //>  Coordonn�es : x({0}), y({1})", Me._coordonneeX, Me._coordonneeY, Me.Nom))
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

    Public Property Nom As String

End Class