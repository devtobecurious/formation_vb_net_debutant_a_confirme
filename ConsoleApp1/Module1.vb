Imports System.Timers
Imports LesRobotsBoss5

Module Module1

    Sub Main()
        Dim robot As New Robot("c3") With
        {
            .CoordonneeX = 1,
            .CoordonneeY = 2
        }

        Dim ser As New System.Xml.Serialization.XmlSerializer(GetType(Robot), "http://www.w3.org/2001/shcemmm") 'obligé constructeur sans paramètres

        Dim stopWatch As New Stopwatch()

        stopWatch.Start()
        Using stream As New System.IO.StreamWriter("G:\Tmps\formation_vbnet_serialisation.xml")
            ser.Serialize(stream, robot)
        End Using
        stopWatch.Stop()

        Console.WriteLine("Temps de sérialisation : " & stopWatch.ElapsedMilliseconds)
        Console.WriteLine("Veuillez taper entrée")
        Console.Read()

        Dim robotClone As Robot

        Using stream As New System.IO.StreamReader("G:\Tmps\formation_vbnet_serialisation.xml")
            robotClone = CType(ser.Deserialize(stream), Robot)
        End Using

        Console.WriteLine(robotClone.CoordonneeX)


        'Si on change le texte en fichier XML, valeur changée ici ? // A copier ici, et modifier le fichier 
        Using stream As New System.IO.StreamReader("G:\Tmps\formation_vbnet_serialisation2.xml")
            robotClone = CType(ser.Deserialize(stream), Robot)
        End Using

        Console.WriteLine(robotClone)

        ' Enregistrement liste
        Dim list As New List(Of Robot)()
        For index = 1 To 100
            list.Add(New Robot() With
            {
                .Nom = "Robot" & index,
                .CoordonneeX = 10 * index,
                .CoordonneeY = 100 * index
            })
        Next


        Console.ReadLine()
        Dim serializer2 As New System.Xml.Serialization.XmlSerializer(GetType(List(Of Robot)))
        stopWatch.Start()
        Using stream As New System.IO.StreamWriter("G:\Tmps\formation_vbnet_serialisation_list.xml")
            serializer2.Serialize(stream, list)
        End Using
        stopWatch.Stop()
        Console.WriteLine("Temps de sérialisation : " & stopWatch.ElapsedMilliseconds)

        Console.ReadLine()

        'json : https://www.newtonsoft.com/json/help/html/SerializingJSON.htm



    End Sub

End Module
