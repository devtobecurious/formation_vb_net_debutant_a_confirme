Module Module1

    Sub Main()
        Using context As New starwars_dbEntities1()
            Dim query = From robot In context.Robot
                        Select robot

            context.Database.Log = AddressOf ConsoleLog

            For Each rob As Robot In query
                Console.WriteLine(rob)
            Next

            Console.WriteLine("*****")

            For Each jedi As Jedi In context.Jedi
                Console.WriteLine(jedi.Name)
            Next

            Console.WriteLine("*****")

            Dim query2 = From rob In context.Robot
                         Join loc In context.Localization On rob.LocalizationId Equals loc.Id
                         Select rob.Name, loc.X, loc.Y

            Console.WriteLine("*****")

            Dim query3 = From loc In context.Localization
                         Group Join rob In context.Robot
                             On loc.Id Equals rob.LocalizationId
                         Into RobotList = Group, Total = Count()
                         Select loc.X, loc.Y, Total, RobotList

            'Requête exécutée que lors d'un save, tolist, first, count, ...
            For Each localisation In query3
                Console.WriteLine("Loc : (" & localisation.X & "," & localisation.Y & ") => [" & localisation.Total & "]")
            Next

            Console.WriteLine("*****")

            Dim robott As Robot = context.Robot.First()

            Console.WriteLine("Name : " & robott.Name)

            robott.Name = "Test" & Guid.NewGuid().ToString()
            context.SaveChanges()

            robott = context.Robot.First()

            Console.WriteLine("Name : " & robott.Name)
        End Using

        Console.ReadLine()
    End Sub

    Private Sub ConsoleLog(query As String)
        Console.ForegroundColor = ConsoleColor.DarkGreen

        Console.WriteLine(query)

        Console.ForegroundColor = ConsoleColor.White
    End Sub

End Module
