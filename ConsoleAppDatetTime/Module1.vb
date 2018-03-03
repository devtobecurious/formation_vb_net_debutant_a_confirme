

Imports System.Globalization

Module Module1

    Sub Main()
        Dim dateT As DateTime

        dateT = DateTime.Now

        Dim maChaine As String

        maChaine = String.Format("{0:HH:mm}, le mois sur 4 caractères: {0:dddd'h'MMM}", dateT)

        Dim cult As New CultureInfo("en-US")
        maChaine = dateT.ToString(cult)

        Console.WriteLine(maChaine)

        Console.Read()
    End Sub

End Module
