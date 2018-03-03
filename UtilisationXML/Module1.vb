Module Module1

    Sub Main()
        Console.WriteLine("Quel est le chemin du fichier ?")
        Dim path As String = Console.ReadLine()

        Dim doc As XDocument = XDocument.Load(path)

        Dim query = From item In doc.Descendants
                    Where item.Value.Contains("t")
                    Select item



        Console.ReadLine()
    End Sub

End Module
