using System;
using System.Diagnostics;
using System.Runtime.InteropServices;



class Program
{

    static void Task1()
    {
        string childProcessPath = @"C:\Windows\System32\notepad.exe";

        Process childProcess = new Process();
        childProcess.StartInfo.FileName = childProcessPath;

        try
        {
            childProcess.Start();

            childProcess.WaitForExit();

            int exitCode = childProcess.ExitCode;
            Console.WriteLine($"Дочірній процес завершився з кодом {exitCode}.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
        finally
        {
            childProcess.Close();
        }
    }
    static void Task2()
    {
        string childProcessPath = @"C:\Windows\System32\notepad.exe";

        Process childProcess = new Process();
        childProcess.StartInfo.FileName = childProcessPath;

        try
        {
            // Запускаємо дочірній процес
            childProcess.Start();

            Console.WriteLine("Оберіть дію:");
            Console.WriteLine("1. Чекати на завершення дочірнього процесу");
            Console.WriteLine("2. Примусово завершити дочірній процес");

            string choice = Console.ReadLine();

            if (choice == "1")
            { 
                childProcess.WaitForExit();

                int exitCode = childProcess.ExitCode;
                Console.WriteLine($"Дочірній процес завершився з кодом {exitCode}.");
            }
            else if (choice == "2")
            {
                childProcess.Kill();
                Console.WriteLine("Дочірній процес був примусово завершений.");
            }
            else
            {
                Console.WriteLine("Невірний вибір.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
        finally
        {
            childProcess.Close();
        }
    }

    


    static void Main()
    {
        //Task1();

        Task2();
    }
}

