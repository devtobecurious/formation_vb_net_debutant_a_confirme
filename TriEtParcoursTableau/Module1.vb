Module Module1

    Sub Main()
        Dim numbers1 = {1, 4, 8, 2, 3, 65, 50}

        Array.Sort(numbers1)

        For index = 0 To numbers1.Length - 1
            Console.WriteLine(numbers1(index))
        Next

        Dim numbers = {{1, 2}, {3, 4}, {5, 6}}

        ' Iterate through the array.
        For index0 = 0 To numbers.GetUpperBound(0)
            For index1 = 0 To numbers.GetUpperBound(1)
                Debug.Write(numbers(index0, index1).ToString & " ")
            Next
        Next

        Console.ReadLine()
    End Sub

End Module
