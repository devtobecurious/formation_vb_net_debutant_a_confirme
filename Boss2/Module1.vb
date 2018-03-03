Module Module1

    Sub Main()
        Dim MAX_LIST As Integer = 10
        Dim type As ActionType = ActionType.displaymenu
        Dim name As String = String.Empty
        Dim birthDay As DateTime = DateTime.Now
        Dim list As List(Of Integer) = New List(Of Integer)
        Dim actionHistoryList As Dictionary(Of DateTime, ActionType) = New Dictionary(Of DateTime, ActionType)

        While (type <> ActionType.exit)
            Console.ForegroundColor = ConsoleColor.Yellow
            Console.WriteLine("Bonjour Humain, quel est votre choix ? ")
            Dim value As String = Console.ReadLine
            Console.ForegroundColor = ConsoleColor.Green
            If System.Enum.TryParse(value, type) Then
                actionHistoryList.Add(DateTime.Now, type)
                Console.WriteLine(("Vous avez choisi " + type.ToString))
            Else
                Console.ForegroundColor = ConsoleColor.Red
                Console.WriteLine("Choix non pris en compte, veuillez r�essayer")
                type = ActionType.displaymenu
            End If

            Select Case (type)
                Case ActionType.displaymenu
                    Console.WriteLine("____________")
                    Console.WriteLine("MENU".PadLeft(5).PadRight(5))
                    Console.WriteLine("____________")
                    Dim names = System.Enum.GetNames(GetType(ActionType))
                    For Each key In names
                        Console.WriteLine(String.Format("{0} : {1}", CType(System.Enum.Parse(GetType(ActionType), key), Integer), key))
                    Next
                Case ActionType.askName
                    Console.WriteLine("Votre nom ?")
                    name = Console.ReadLine
                    Console.WriteLine(("Votre nom est : " + name))
                Case ActionType.askBirthday
                    Dim validDate As Boolean = False

                    While Not validDate
                        Console.ForegroundColor = ConsoleColor.Yellow
                        Console.WriteLine("Votre date de naissance ?")
                        Dim birthdayValue As String = Console.ReadLine
                        If DateTime.TryParse(birthdayValue, birthDay) Then
                            validDate = True
                            Console.WriteLine(String.Format("Votre date de naissance est : {0:dd/MM/yyyy}", birthDay))
                        Else
                            Console.ForegroundColor = ConsoleColor.Red
                            Console.WriteLine("Vous n'avez pas saisi une date, veuillez recommencer, s'il vous pla�t.")
                        End If


                    End While

                Case ActionType.computeSum10Number
                    list.Clear()
                    Dim i As Integer = 0

                    While (i < MAX_LIST)
                        Console.ForegroundColor = ConsoleColor.Yellow
                        Console.WriteLine(("Chiffre " _
                                        & (i & " a ajouter dans la liste ?")))
                        Dim valInput As String = Console.ReadLine
                        Dim number As Integer
                        If Integer.TryParse(valInput, number) Then
                            i = (i + 1)
                            list.Add(number)
                        Else
                            Console.ForegroundColor = ConsoleColor.Red
                            Console.WriteLine("Vous n'avez pas saisi un entier, veuillez recommencer, s'il vous pla�t.")
                        End If


                    End While

                    Console.ForegroundColor = ConsoleColor.Yellow
                    Console.WriteLine(("La somme est de : " & list.Sum))
                Case ActionType.computeAverage10Number
                    Console.ForegroundColor = ConsoleColor.Yellow
                    If (list.Count = 0) Then
                        Console.ForegroundColor = ConsoleColor.Red
                        Console.WriteLine("Veuillez d'abord ajouter les nombres dans la liste, s'il vous plaît.")
                    Else
                        Console.WriteLine(("La moyenne est de : " & list.Average))
                    End If

                Case ActionType.historic
                    For Each item In actionHistoryList
                        Console.WriteLine(String.Format("{0} - Action : {1}", item.Key.ToString("dd/MM/yyyy HH:mm:ss"), item.Value))
                    Next
                Case ActionType.exit
                    Console.ForegroundColor = ConsoleColor.Cyan
                    Console.WriteLine("Bye bye")
            End Select


        End While
    End Sub

End Module
