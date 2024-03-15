using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

class Program
{
    static Mutex mutex = new Mutex();
    static string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
    static string numbersFile = Path.Combine(currentDirectory, "numbers.txt");
    static string primesFile = Path.Combine(currentDirectory, "primes.txt");
    static string filteredPrimesFile = Path.Combine(currentDirectory, "filteredPrimes.txt");
    static string reportFile = Path.Combine(currentDirectory, "report.txt");

    static void Main()
    {
        Thread generatorThread = new Thread(GenerateNumbers);
        Thread primesThread = new Thread(ProcessPrimes);
        Thread filteredPrimesThread = new Thread(ProcessFilteredPrimes);
        Thread reportThread = new Thread(GenerateReport);

        generatorThread.Start();
        primesThread.Start();
        filteredPrimesThread.Start();

        generatorThread.Join();
        primesThread.Join();
        filteredPrimesThread.Join();

        reportThread.Start();
        reportThread.Join();

        Console.WriteLine("All threads finished execution. Check output files.");
    }

    static void GenerateNumbers()
    {
        mutex.WaitOne();
        Random rnd = new Random();
        List<int> numbers = new List<int>();
        for (int i = 0; i < 50; i++)
        {
            numbers.Add(rnd.Next(1, 100));
        }

        File.WriteAllLines(numbersFile, numbers.ConvertAll<string>(x => x.ToString()));
        mutex.ReleaseMutex();
    }

    static void ProcessPrimes()
    {
        mutex.WaitOne();
        List<int> numbers = new List<int>(Array.ConvertAll(File.ReadAllLines(numbersFile), int.Parse));
        List<int> primes = new List<int>();

        foreach (int num in numbers)
        {
            if (IsPrime(num))
            {
                primes.Add(num);
            }
        }

        File.WriteAllLines(primesFile, primes.ConvertAll<string>(x => x.ToString()));
        mutex.ReleaseMutex();
    }

    static void ProcessFilteredPrimes()
    {
        mutex.WaitOne();
        List<int> primes = new List<int>(Array.ConvertAll(File.ReadAllLines(primesFile), int.Parse));
        List<int> filteredPrimes = new List<int>();

        foreach (int prime in primes)
        {
            if (prime % 10 == 7)
            {
                filteredPrimes.Add(prime);
            }
        }

        File.WriteAllLines(filteredPrimesFile, filteredPrimes.ConvertAll<string>(x => x.ToString()));
        mutex.ReleaseMutex();
    }

    static bool IsPrime(int number)
    {
        if (number <= 1) return false;
        if (number <= 3) return true;
        if (number % 2 == 0 || number % 3 == 0) return false;

        for (int i = 5; i * i <= number; i += 6)
        {
            if (number % i == 0 || number % (i + 2) == 0)
            {
                return false;
            }
        }

        return true;
    }

    static void GenerateReport()
    {
        mutex.WaitOne();
        using (StreamWriter writer = new StreamWriter(reportFile))
        {
            WriteFileInfo(writer, numbersFile);
            WriteFileInfo(writer, primesFile);
            WriteFileInfo(writer, filteredPrimesFile);
        }
        mutex.ReleaseMutex();
    }

    static void WriteFileInfo(StreamWriter writer, string filePath)
    {
        writer.WriteLine($"File: {filePath}");
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            writer.WriteLine($"Number of lines: {lines.Length}");
            FileInfo fileInfo = new FileInfo(filePath);
            writer.WriteLine($"File size (bytes): {fileInfo.Length}");
            writer.WriteLine("File contents:");
            foreach (string line in lines)
            {
                writer.WriteLine(line);
            }
            writer.WriteLine();
        }
        else
        {
            writer.WriteLine("File does not exist.");
        }
    }
}
