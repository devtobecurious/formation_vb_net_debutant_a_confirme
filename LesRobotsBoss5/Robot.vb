Public Class Robot

    Private Const MAX_X As Integer = 50

    Private Const MAX_Y As Integer = 50

#Region "Propri�t�s"

    Private _largeur As Integer
#End Region

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

    ' A montrer =>  ne fonctionne pas car ?
    'public MonRobot(int coordX, int coordY)
    '{
    '}
    ''' <summary>
    ''' Se d�placer sur la carte 2D
    ''' </summary>
    ''' <param name="deplacementX"></param>
    ''' <param name="deplacementY"></param>
    Public Overridable Sub SeDeplacer(ByVal deplacementX As Integer, ByVal deplacementY As Integer)
        If Me.EstVivant Then
            Me.CoordonneeX = deplacementX
            Me.CoordonneeY = deplacementY
            Me.VerifierCoordonnees()
        End If

    End Sub

    Public Sub AfficherPositionnement()
        Console.WriteLine(String.Format("{2} //>  Coordonn�es : x({0}), y({1})", Me.CoordonneeX, Me.CoordonneeY, Me.Nom))
    End Sub

    Public Sub Attaquer(ByVal robot As Robot)
        If ((robot.CoordonneeX = Me.CoordonneeX) _
                    AndAlso ((robot.CoordonneeY = Me.CoordonneeY) _
                    AndAlso Me.EstVivant)) Then
            'Console.WriteLine(string.Format("Une attaque a lieu entre {0} et {1}", this.Nom, robot.Nom));
            Dim rand As Random = New Random
            Dim valeur As Integer = rand.Next(1, 10)
            Me.EstVivant = (valeur > 5)
            robot.EstVivant = Not Me.EstVivant
            Dim nomMort As String = robot.Nom
            If Not Me.EstVivant Then
                nomMort = Me.Nom
            End If

            'Console.WriteLine(string.Format("Le robot {0} est mort ...", nomMort));
        End If

    End Sub

    Public Overloads Function EstAuBonEndroit(ByVal x As Integer, ByVal y As Integer) As Boolean
        Return ((Me.CoordonneeX = x) _
                    AndAlso (Me.CoordonneeY = y))
    End Function

    Public Overloads Function EstAuBonEndroit(ByVal robot As Robot) As Boolean
        Return Me.EstAuBonEndroit(robot.CoordonneeX, robot.CoordonneeY)
    End Function

    Protected Overloads Sub VerifierCoordonnees()
        Me.VerifierCoordonnees(Me.CoordonneeX, MAX_X)
        Me.VerifierCoordonnees(Me.CoordonneeY, MAX_Y)
    End Sub

    Private Overloads Sub VerifierCoordonnees(ByRef valeur As Integer, ByVal constante As Integer)
        If (valeur >= constante) Then
            valeur = 1
        End If

        Throw New NonValidCoordoonneeException
    End Sub

    Public Property Taille As Integer


    Public Property Nom As String

    Protected Property CoordonneeX As Integer

    Protected Property CoordonneeY As Integer

    Public Property EstVivant As Boolean

End Class