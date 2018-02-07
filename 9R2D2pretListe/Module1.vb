Module Module1

    Sub Main()
        Dim list As System.Collections.ArrayList = New System.Collections.ArrayList
        list.Add(1)
        list.Add("test")
        list.Add(DateTime.Now)
        Dim i As Integer = 0
        Do While (i < list.Count)
            Console.WriteLine(("1. ArrayList[" _
                            + (i + ("] = " + list(i)))))
            i = (i + 1)
        Loop

        For Each item In list
            Console.WriteLine(("2. ArrayList " + item))
        Next
        list.Insert(1, 1.5, M)
        For Each item In list
            Console.WriteLine(("3. ArrayList " + item))
        Next

        Dim listInt As List(Of Integer) = New List(Of Integer)(1) From {
            1,
            2
        }
        Dim listInt2 As List(Of Integer) = New List(Of Integer)(1)
        listInt2.Add(10)
        listInt2.Add(20)

        For Each item In listInt
            Console.WriteLine(("4. List<int> " + item))
        Next
        For Each item In listInt2
            Console.WriteLine(("5. List<int> " + item))
        Next
        Dim dico As Dictionary(Of String, Integer) = New Dictionary(Of String, Integer)
        For Each item In dico
            Console.WriteLine(("6. dico " + item.ToString()))
            Console.WriteLine(("6. dico.Key " + item.Key))
            Console.WriteLine(("6. dico.Value " + item.Value))
        Next
        For Each key In dico.Keys
            Console.WriteLine(("7. dico(key) " + key))
            Console.WriteLine(("7. dico[key] " + dico(key)))
        Next
        Console.ReadLine()
    End Sub

End Module
