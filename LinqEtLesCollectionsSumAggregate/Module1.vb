Imports LesRobotsBoss5

Module Module1

    Private _list As New List(Of LesRobotsBoss5.R2D)()
    Private _listTeam As New List(Of Team)()

    Sub Main()
        Init()

        AggregateRobots()

        'DisplayRobots()

        Console.ReadLine()
    End Sub

    Private Sub AggregateRobots()
        Dim query = Aggregate robot In _list
                    Into Min = Min(robot.LifePoint), Max = Max(robot.LifePoint)

        Console.WriteLine(query.Min & "/" & query.Max)

        Console.WriteLine("************************************")
    End Sub

    Private Sub DisplayRobots()
        Console.WriteLine("************************************")

        ' Joiture en group join 
        Dim query3 = From team In _listTeam
                     Group Join robot In _list
                         On team.Id Equals robot.TeamId
                     Into robotList = Group, nbRobots = Count()
                     Select team, robotList, nbRobots

        For Each item In query3.OrderBy(Function(a)
                                            Return a.team.Name
                                        End Function)
            Console.WriteLine("team : " & item.team.Name & ", (" & item.nbRobots & ")" & vbCr)
            For Each child In item.robotList
                Console.WriteLine("  - " & child.Nom)
            Next
            Console.WriteLine(vbCrLf)
        Next

        Console.WriteLine("************************************")

        ' Présentation du let
        Dim query4 = From team In _listTeam
                     Let Matricule = Guid.NewGuid().ToString() 'ici, on peut calculer, pour chaque ligne
                     Let RequestTime = DateTime.Now
                     Group Join robot In _list
                         On team.Id Equals robot.TeamId
                     Into robotList = Group, nbRobots = Count()
                     Select team, Matricule, robotList, nbRobots

        For Each item In query4.OrderBy(Function(a)
                                            Return a.team.Name
                                        End Function)
            Console.WriteLine("team : " & item.team.Name & "[" & item.Matricule & "], (" & item.nbRobots & ")" & vbCr)
            For Each child In item.robotList
                Console.WriteLine("  - " & child.Nom)
            Next
            Console.WriteLine(vbCrLf)
        Next
    End Sub

    Private Sub Init()
        LoadTeams(10)
        LoadRobots(150)
    End Sub

    Private Sub LoadTeams(ByVal nb As Integer)
        Dim rand As New Random()

        nb = nb * 10

        For index = 0 To nb - 1
            Dim name As String = String.Format("R2D.{0}", rand.Next(0, nb))

            Dim team As New Team() With {.Id = index, .Name = name}

            _listTeam.Add(team)
        Next
    End Sub

    Private Sub LoadRobots(ByVal nb As Integer)
        Dim rand As New Random()

        For index = 1 To nb
            Dim name As String = String.Format("R2D.{0}", rand.Next(0, nb))
            Dim robot As New R2D(name, rand.Next(0, 500), rand.Next(0, 500))

            robot.TeamId = rand.Next(0, 10)
            robot.LifePoint = rand.Next(100, 1000)

            _list.Add(robot)
        Next
    End Sub

End Module
