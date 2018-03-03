Module Module1

    Sub Main()
        Using context As New starwars_dbEntities1()
            Dim query = From robot In context.Robot
                        Select robot

            For Each rob As Robot In query
                Console.WriteLine(rob)
            Next

            For Each jedi As Jedi In context.Jedi
                Console.WriteLine(jedi.Name)
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

End Module
