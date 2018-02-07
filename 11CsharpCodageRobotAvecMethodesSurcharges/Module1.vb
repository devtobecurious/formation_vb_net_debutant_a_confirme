Module Module1

    Private Sub Main(ByVal args() As String)
        Console.WriteLine("Je suis R2D2, je sais courir")
        Courir()
        Courir(20)
        Voler(1, 20)
        ' Comment faire pour passer autant de param�tres que l'on souhaite ?
        Voler(1, 2, 3, 4, 5, 6, 10)
        Console.ReadLine()
    End Sub

    'static void Courir()
    '{
    '    for (int i = 0; i < 10; i++)
    '    {
    '        Console.WriteLine("Je me d�place de " + i + "km");
    '    }
    '}
    ''' <summary>
    ''' 2, apres am�lioration, M�thode pour faire courir le robot
    ''' </summary>
    Private Sub Courir()
        Courir(10)
    End Sub

    ''' <summary>
    ''' M�thode pour faire courir le robot, surcharge de la premi�re
    ''' > La premi�re a le presque le m�me code, non ?
    ''' </summary>
    Private Sub Courir(ByVal nbKms As Integer)
        Dim i As Integer = 0
        Do While (i < nbKms)
            Console.WriteLine(("Je me d�place de " _
                            + (i + "km")))
            i = (i + 1)
        Loop

    End Sub

    Private Sub Voler(ByVal pointA As Integer, ByVal pointB As Integer)
        Console.WriteLine(("Je vole du point " _
                        + (pointA + (", au point " + pointB))))
    End Sub

    Private Sub Voler(ParamArray ByVal destinations() As Integer)
        Dim i As Integer = 0
        Do While (i < destinations.Length)
            Console.WriteLine(("Je pars � cette destination : " + destinations(i)))
            i = (i + 1)
        Loop

    End Sub

End Module
