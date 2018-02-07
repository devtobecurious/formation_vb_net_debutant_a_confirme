Imports System.IO
Imports System.Text

Module Module1

    Sub Main()
        Dim chemin As String = "..\..\..\..\test.txt"
        Dim info As FileInfo = New FileInfo(chemin)
        If info.Exists Then
            Console.WriteLine(("0. File : " _
                    + (info.Extension + (", " + info.DirectoryName))))
            Dim directory As DirectoryInfo = info.Directory
            If directory.Exists Then
                For Each item In directory.GetFiles
                    Console.WriteLine(("0. Fichiers du r�pertoire : " + item.Name))
                Next
            End If

        End If


        Using reader As FileStream = New FileStream(chemin, FileMode.Open)
            If reader.CanRead Then
                Dim buffer2() As Byte = New Byte((reader.Length) - 1) {}
                Dim index As Integer = 0
                Dim longueur As Integer = CType(reader.Length, Integer)

                While (longueur > 0)
                    Dim nbOctetsLus As Integer = reader.Read(buffer2, index, longueur)
                    index = (index + nbOctetsLus)
                    longueur = (longueur - index)

                End While

                Console.WriteLine(("1. Contenu : " + Encoding.Default.GetString(buffer2)))
            End If
        End Using

        Using reader As StreamReader = New StreamReader(chemin)
            Dim contenu = reader.ReadToEnd()
            Console.WriteLine(("2. Contenu : " + contenu))
        End Using

        Dim buffer As Byte()
        Using memStream As MemoryStream = New MemoryStream
            Dim content = "Ceci est un test"

            buffer = Encoding.Default.GetBytes(content)

            memStream.Write(buffer, 0, CInt(buffer.Length))
            memStream.Flush()
        End Using

        Using streamWriter As StreamWriter = New StreamWriter(chemin, True)
            streamWriter.WriteLine("Test2")
            'Pour montrer le cache d'écriture :  writer.Flush()
        End Using

        System.Console.Read()
    End Sub

End Module
