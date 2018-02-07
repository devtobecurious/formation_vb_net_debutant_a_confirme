Public Class Droide
    Inherits Robot

    ' Ici, on est oblig� de cr�er un constructeur, car des param�tres dans le parent
    Public Sub New(ByVal nom As String)
        MyBase.New(nom)

    End Sub

    Public Sub New(ByVal nom As String, ByVal x As Integer, ByVal y As Integer, ByVal nomArme As String)
        MyBase.New(nom)
        Me.CoordonneeX = x
        Me.CoordonneeY = y
        Me.Arme = nomArme
    End Sub

    Public Overrides Sub SeDeplacer(ByVal deplacementX As Integer, ByVal deplacementY As Integer)
        Const COEFFICIENT As Integer = 2
        Me.CoordonneeX = (deplacementX * COEFFICIENT)
        Me.CoordonneeY = (deplacementY * COEFFICIENT)
        Me.VerifierCoordonnees()
    End Sub

    Public Overrides Function ToString() As String
        Return Me.Nom
    End Function

    Public Property Arme As String
End Class