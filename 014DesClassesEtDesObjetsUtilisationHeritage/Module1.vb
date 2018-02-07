Imports LesRobots

Module Module1

    Sub Main()
        Dim robot As Robot = New Robot("Robot 1")
        ' affichage tout string() par d�faut de Object :
        Console.WriteLine(("Robot " _
                        + (robot.Nom + (", tostring => " + robot.ToString()))))
        Dim droide As Droide = New Droide("Droide1", 1, 2, "arme1")
        ' ici, on n'a qu'un constructeur disponible
        Console.WriteLine(("Robot " _
                        + (droide.Nom + (", tostring => " + droide.ToString()))))
        droide.AfficherPositionnement
        ' h�rite des attributs du parent, des m�thodes du parent
        droide.SeDeplacer(1, 2)
        ' comment faire pour se d�placer plus vite ? => surcharge de la m�thode
        droide.AfficherPositionnement
        Dim robot2 As Robot = droide
        Dim robots As List(Of Robot) = New List(Of Robot)

        Dim lambda = Sub(rob)
                         Dim rand As Random = New Random
                         rob.SeDeplacer(rand.Next(0, 100), rand.Next(0, 100))
                         rob.AfficherPositionnement()
                         System.Threading.Thread.Sleep(300)
                     End Sub

        While True
            robots.ForEach(lambda)
        End While

        Console.ReadLine()
    End Sub

End Module
