using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    private static bool stopPrimeThread = false;
    private static bool stopFiboThread = false;
    static void GenerateFibonacci(int lowerBound, int upperBound)
    {
        Console.WriteLine($"Генеруємо числа Фібоначчі у діапазоні від {lowerBound} до {upperBound}...");

        int a = 0, b = 1, c;
        while (a <= upperBound)
        {
            if (a >= lowerBound)
            {
                Console.WriteLine($"Число Фібоначчі: {a}");
            }
            c = a + b;
            a = b;
            b = c;
        }

        Console.WriteLine("Генерація чисел Фібоначчі завершена.");
    }

    static void GeneratePrimes(int lowerBound, int upperBound)
    {
        Console.WriteLine($"Генеруємо прості числа у діапазоні від {lowerBound} до {upperBound}...");

        for (int number = lowerBound; number <= upperBound; number++)
        {
            if (IsPrime(number))
            {
                Console.WriteLine($"Просте число: {number}");
            }
        }

        Console.WriteLine("Генерація завершена.");
    }

    static bool IsPrime(int number)
    {
        if (number <= 1) return false;

        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0) return false;
        }

        return true;
    }
    static void Task1()
    {
        Console.Write("Введіть нижню межу діапазону (або натисніть Enter для значення 0): ");
        int lowerBound;
        if (!int.TryParse(Console.ReadLine(), out lowerBound))
        {
            lowerBound = 0;
        }

        int upperBound;
        Console.Write("Введіть верхню межу діапазону (або натисніть Enter для нескінченності): ");
        string upperInput = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(upperInput))
        {
            upperBound = int.MaxValue;
        }
        else if (!int.TryParse(upperInput, out upperBound))
        {
            Console.WriteLine("Некоректне значення для верхньої межі. Використано значення за замовчуванням.");
            upperBound = int.MaxValue;
        }

        Console.WriteLine("Оберіть потік для запуску:");
        Console.WriteLine("1. Прості числа");
        Console.WriteLine("2. Числа Фібоначчі");

        string choice = Console.ReadLine();

        Thread thread = null;

        switch (choice)
        {
            case "1":
                thread = new Thread(() => GeneratePrimes(lowerBound, upperBound));
                break;
            case "2":
                thread = new Thread(() => GenerateFibonacci(lowerBound, upperBound));
                break;
            default:
                Console.WriteLine("Невірний вибір.");
                return;
        }

        thread.Start();
        //
        //
        //
        //
        //Тут повинен бути метод з зупинкою, але я не зміг винокани...
        //
        //
        //
    }




    static void Main()
    {
        Task1();
    }
}

    
    
    
    
    

