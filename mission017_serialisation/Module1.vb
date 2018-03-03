Imports System.Text

Module Module1

    Sub Main()
        Dim path As String = "g:\tmps\formation_vbnet_serialisation.csv"
        Dim list As List(Of LesRobotsBoss5.Robot)


        If (IO.File.Exists(path)) Then
            list = LoadRobots(path, AddressOf DisplayOnRobot) 'Voir si les stagiaires connaissent l'address of
        Else
            Dim strBuilder As New StringBuilder()
            For index = 0 To 99
                strBuilder.Append(Convert(New LesRobotsBoss5.Robot() With
                                          {
                                            .Nom = "Robot" & index,
                                            .CoordonneeX = index,
                                            .CoordonneeY = index * 3
                                          }))
            Next

            Save(strBuilder.ToString(), path)
        End If

        Console.Read()
    End Sub

    Private Function Convert(ByVal robot As LesRobotsBoss5.Robot) As String
        Dim str As String

        str = String.Format("{0},{1},{2}{3}", robot.Nom, robot.Localisation.X, robot.Localisation.Y, vbCrLf)

        Return str
    End Function

    Private Sub Save(content As String, path As String)
        Using stream As New IO.StreamWriter(path)
            stream.WriteLine(content)

            stream.Flush()
        End Using
    End Sub

    Private Sub DisplayOnRobot(ByVal robot As LesRobotsBoss5.Robot)
        Console.WriteLine(robot)
    End Sub

    Private Function LoadRobots(path As String, ByVal maProc As Action(Of LesRobotsBoss5.Robot)) As List(Of LesRobotsBoss5.Robot)
        Dim list As New List(Of LesRobotsBoss5.Robot)

        Using stream As New IO.StreamReader(path)
            Dim content As String

            content = stream.ReadToEnd()

            Dim rows As String() = content.Split(vbCrLf)

            For Each row In rows
                Dim colums As String() = row.Split(",")

                If colums.Length >= 3 Then
                    Dim robot = New LesRobotsBoss5.Robot() With
                         {
                            .Nom = colums(0),
                            .CoordonneeX = colums(1),
                            .CoordonneeY = colums(2)
                         }

                    list.Add(robot)

                    maProc(robot)
                End If
            Next
        End Using

        Return list
    End Function
End Module
