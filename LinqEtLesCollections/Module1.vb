Imports LesRobotsBoss5

Module Module1

    Private _list As New List(Of LesRobotsBoss5.R2D)()
    Private _listTeam As New List(Of Team)()

    Sub Main()
        Init()
        DisplayRobots()

        Console.ReadLine()
    End Sub

    Private Sub DisplayRobots()
        ' Afficher les robots dont le nom comprend 1

        Dim query = From robot In _list
                    Where robot.Nom.EndsWith("1")
                    Select robot

        For Each item In query
            Console.WriteLine("Robot : " & item.Nom)
        Next

        Console.WriteLine("************************************")

        ' Jointure forte robot, team
        Dim query2 = From team In _listTeam
                     Join robot In _list On team.Id Equals robot.TeamId
                     Select team, robot

        For Each item In query2.OrderBy(Function(a)
                                            Return a.team.Name
                                        End Function)
            Console.WriteLine("team : " & item.team.Name & ", robot : " & item.robot.Nom)
        Next

        Console.WriteLine("************************************")

        ' Joiture en group join 
        Dim query3 = From team In _listTeam
                     Group Join robot In _list
                         On team.Id Equals robot.TeamId
                     Into robotList = Group
                     Select team, robotList

        For Each item In query3.OrderBy(Function(a)
                                            Return a.team.Name
                                        End Function)
            Console.WriteLine("team : " & item.team.Name & vbCr)
            For Each child In item.robotList
                Console.WriteLine("  - " & child.Nom)
            Next
            Console.WriteLine(vbCrLf)
        Next

        Console.WriteLine("************************************")

        ' Joiture en group join flat
        Dim query4 = From team In _listTeam
                     Group Join robot In _list
                         On team.Id Equals robot.TeamId
                     Into robotList = Group
                     From robot In robotList.DefaultIfEmpty()
                     Select team, robot = If(robot Is Nothing, "??", robot.Nom)

        For Each item In query4.OrderBy(Function(a)
                                            Return a.team.Name
                                        End Function)
            Console.WriteLine("team : " & item.team.Name & vbCr)
            Console.WriteLine("robot : " & item.robot)
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

            _list.Add(robot)
        Next
    End Sub

End Module
