Imports LesRobots

Module Module1
    Dim MAX_X As Integer = 50
    Dim MAX_Y As Integer = 50


    Private Sub Main(ByVal args() As String)
        Dim robots As List(Of LesRobots.Robot) = New List(Of LesRobots.Robot)
        Initialize(robots)
        LancerAttaques(robots)
    End Sub

    Private Sub LancerAttaques(ByVal robotList As List(Of LesRobots.Robot))
        Dim rand As Random = New Random

        While robotList.Any(Function(robot) robot.EstVivant)
            Dim listVivants = robotList.Where(Function(robot) robot.EstVivant).ToList()

            listVivants.ForEach(Sub(robot)
                                    Dim x As Integer = rand.Next(1, MAX_X)
                                    Dim y As Integer = rand.Next(1, MAX_Y)
                                    robot.SeDeplacer(x, y)
                                    For Each rob In listVivants.Where(Function(item) ((item.Nom <> robot.Nom) _
                                                                                      AndAlso item.EstAuBonEndroit(robot)))
                                        robot.Attaquer(rob)
                                        System.Threading.Thread.Sleep(100)
                                    Next
                                    AfficherRobots(robotList)
                                    System.Threading.Thread.Sleep(1000)
                                End Sub)
        End While

    End Sub

    Private Sub AfficherRobots(ByVal robotList As List(Of LesRobots.Robot))
        Console.WriteLine("________________")
        Dim i As Integer = 1
        Do While (i < MAX_X)
            Dim line As String = String.Empty
            Dim j As Integer = 1
            Do While (j < MAX_Y)
                Dim value As String = " "
                Dim robot As Robot = robotList.FirstOrDefault(Function(item) item.EstAuBonEndroit(i, j))
                If (Not (robot) Is Nothing) Then
                    value = "O"
                End If

                line = (line + value)
                j = (j + 1)
            Loop

            Console.WriteLine(line)
            i = (i + 1)
        Loop

    End Sub

    Private Sub Initialize(ByVal robotList As List(Of LesRobots.Robot))
        Dim rand As Random = New Random
        Dim i As Integer = 0
        Do While (i < 10)
            Dim typeValue As Integer = rand.Next(1, 3)
            Dim type As TypeRobot = CType(typeValue, TypeRobot)
            Dim robot As Robot = Nothing
            Select Case (type)
                Case TypeRobot.Droide
                    robot = New Droide(("droide : " + i), 1, 1, "fusil")
                Case TypeRobot.R2D
                    robot = New R2D(("r2d : " + i), 1, 1)
            End Select

            robotList.Add(robot)
            i = (i + 1)
        Loop

    End Sub
End Module
