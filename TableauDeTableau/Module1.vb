Module Module1

    Sub Main()
        Dim jaggedNumbers = {({1, 2, 3}), ({4, 5}), ({6}), ({7})}


        For indexA = 0 To jaggedNumbers.Length - 1
            For indexB = 0 To jaggedNumbers(indexA).Length - 1
                Console.Write(jaggedNumbers(indexA)(indexB) & " ")
            Next
            Console.WriteLine("")
        Next

        Console.ReadLine()
    End Sub

End Module
