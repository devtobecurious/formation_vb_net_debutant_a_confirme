Public MustInherit Class Combattant
    Private Const MAX_X As Integer = 50
    Private Const MAX_Y As Integer = 50

    Private _localisation As New Localisation()

    Public Overridable Sub Attaquer(ByVal combattant As Combattant)
        If ((combattant.CoordonneeX = Me.CoordonneeX) _
                    AndAlso ((combattant.CoordonneeY = Me.CoordonneeY) _
                    AndAlso Me.EstVivant)) Then
            'Console.WriteLine(string.Format("Une attaque a lieu entre {0} et {1}", this.Nom, robot.Nom));
            Dim rand As Random = New Random
            Dim valeur As Integer = rand.Next(1, 10)
            Me.EstVivant = (valeur > 5)
            combattant.EstVivant = Not Me.EstVivant
            Dim nomMort As String = combattant.Nom
            If Not Me.EstVivant Then
                nomMort = Me.Nom
            End If

            'Console.WriteLine(string.Format("Le robot {0} est mort ...", nomMort));
        End If

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
        End If

    End Sub

    Public Overloads Function EstAuBonEndroit(ByVal x As Integer, ByVal y As Integer) As Boolean
        Return ((Me.CoordonneeX = x) _
                    AndAlso (Me.CoordonneeY = y))
    End Function

    Public Overloads Function EstAuBonEndroit(ByVal robot As Robot) As Boolean
        Return Me.EstAuBonEndroit(robot.CoordonneeX, robot.CoordonneeY)
    End Function

    Public Property Nom As String

    Public Property CoordonneeX As Integer
        Get
            Return Me._localisation.X
        End Get
        Set(value As Integer)
            Me._localisation.X = value
        End Set
    End Property

    Public Property CoordonneeY As Integer
        Get
            Return Me._localisation.Y
        End Get
        Set(value As Integer)
            Me._localisation.Y = value
        End Set
    End Property

    Public Property EstVivant As Boolean

    Public Property Localisation As Localisation
        Get
            Return _localisation
        End Get
        Set(value As Localisation)
            _localisation = value
        End Set
    End Property
End Class
