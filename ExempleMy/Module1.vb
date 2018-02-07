Imports System.IO

Module Module1

    Sub Main()
        My.Computer.TestProperty = "test"
        Dim val = My.Test2Property


        Dim info = New DirectoryInfo("d:\")
        Dim files = info.GetFiles("*.txt")

        For Each item In files
            Console.WriteLine("Item ? " + item.FullName)
        Next

        Console.Read()
    End Sub

End Module
