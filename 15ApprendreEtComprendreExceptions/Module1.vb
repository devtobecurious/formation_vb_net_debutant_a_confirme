

Module Module1

    Sub Main()
        Dim val1 As Integer = 10
        Dim val2 As Integer = 0
        ' 1. int result = val1 / val2;
        Try
            Dim result As Integer = (val1 / val2)
        Catch
            Console.WriteLine("Il existe une erreur")
        End Try




        Try
            Dim result As Integer = (val1 / val2)
        Catch ex As Exception
            Console.WriteLine(("Il existe une erreur : " + ex.Message))
        End Try

        Try
            Dim result As Integer = (val1 / val2)
        Catch ex As Exception
            Console.WriteLine(("Il existe une erreur : " + ex.Message))
        Finally
            Console.WriteLine("A. Passons ici quelque soit le code // Utile pour lib�rer les acc�s, fermer des fichiers, ....")
        End Try

        ' Du plus sp�cifique au moins sp�cifique
        Try
            Dim result As Integer = (val1 / val2)

        Catch ex As DivideByZeroException When ex.Message.Contains("test")
        Catch ex As DivideByZeroException
            Console.WriteLine(("Il existe une erreur sp�cifique : " + ex.Message))
        Catch ex As Exception
            Console.WriteLine(("Traitement des autres erreurs : " + ex.Message))
        Finally
            Console.WriteLine("A. Passons ici quelque soit le code // Utile pour lib�rer les acc�s, fermer des fichiers, ....")
        End Try

        ' A montrer : �a ne peut fonctionner, car Exception englobe toutes les autres
        'try
        '{
        '    int result = val1 / val2;
        '}
        'catch (Exception ex)
        '{
        '    Console.WriteLine("Traitement des autres erreurs : " + ex.Message);
        '}
        'catch (DivideByZeroException ex)
        '{
        '    Console.WriteLine("Il existe une erreur sp�cifique : " + ex.Message);
        '}
        'finally
        '{
        '    Console.WriteLine("A. Passons ici quelque soit le code // Utile pour lib�rer les acc�s, fermer des fichiers, ....");
        '}
        Try
            Dim result As Integer = (val1 * val2)
        Catch ex As Exception
            Console.WriteLine(("Il existe une erreur : " + ex.Message))
        Finally
            Console.WriteLine("B. Passons ici quelque soit le code // Utile pour lib�rer les acc�s, fermer des fichiers, ....")
        End Try

        ' Pour lancer une exception
        'throw new MonExceptionTypee();
        Try
            Throw New MonExceptionTypee2("test")
        Catch ex As MonExceptionTypee2
            Console.WriteLine(("Une erreur typ�e est re�u, " + ex.Message))
        End Try

        Console.ReadLine()
    End Sub

End Module
