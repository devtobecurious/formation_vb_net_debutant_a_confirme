Imports LesRobotsBoss5

Public Class Robot
    Inherits Combattant

#Region "Propriétés"

    Private _largeur As Integer

#End Region

    Public Sub New()
    End Sub

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
        Me.CoordonneeX = coordX
        Me.CoordonneeY = coordY
        Me.Nom = nom
        Me.EstVivant = True
    End Sub

    Public Sub AfficherPositionnement()
        Console.WriteLine(String.Format("{2} //>  Coordonn�es : x({0}), y({1})", Me.CoordonneeX, Me.CoordonneeY, Me.Nom))
    End Sub

    Public Property Taille As Integer

    Public Property TeamId As Integer

    Public Overrides Function ToString() As String
        Return String.Format("Robot : {2} // {0}:{1}", Me.CoordonneeX, Me.CoordonneeY, Me.Nom)
    End Function
End Class