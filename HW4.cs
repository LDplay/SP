using System;
using System.Threading;

//class HorseRace
//{
//    static Random random = new Random();
//    static int[] positions = new int[5];
//    static object lockObj = new object();

//    static void Main()
//    {
//        Console.WriteLine("Емуляція кінних перегонів");
//        Console.WriteLine("Натисніть Enter, щоб розпочати гонку...");
//        Console.ReadLine();

//        Thread[] threads = new Thread[5];
//        for (int i = 0; i < 5; i++)
//        {
//            int horseNumber = i + 1;
//            threads[i] = new Thread(() => Race(horseNumber));
//            threads[i].Start();
//        }

//        while (true)
//        {
//            lock (lockObj)
//            {
//                Console.Clear();
//                for (int i = 0; i < 5; i++)
//                {
//                    Console.WriteLine($"Кінь {i + 1}: {GetProgressBar(positions[i])}");
//                }
//            }

//            Thread.Sleep(100);
//            if (positions[4] >= 100)
//            {
//                break;
//            }
//        }

//        Console.WriteLine("\nРезультати гонки:");
//        for (int i = 0; i < 5; i++)
//        {
//            Console.WriteLine($"Кінь {i + 1} фінішував з відсотком {positions[i]}");
//        }
//    }

//    static void Race(int horseNumber)
//    {
//        int distance = 0;
//        while (distance < 100)
//        {
//            Thread.Sleep(random.Next(50, 200));
//            distance += random.Next(1, 5);
//            lock (lockObj)
//            {
//                positions[horseNumber - 1] = distance;
//            }
//        }
//    }

//    static string GetProgressBar(int progress)
//    {
//        const int progressBarLength = 20;
//        int completedBlocks = progress * progressBarLength / 100;
//        string progressBar = "[" + new string('#', completedBlocks) + new string('-', progressBarLength - completedBlocks) + "]";
//        return progressBar;
//    }
//}




//class Findword
//{
//    static async Task Main()
//    {
//        Console.WriteLine("Введіть слово для пошуку:");
//        string searchWord = Console.ReadLine();

//        Console.WriteLine("Введіть шлях до файлу:");
//        string filePath = Console.ReadLine();

//        try
//        {
//            int count = await SearchWordInFileAsync(filePath, searchWord);
//            Console.WriteLine($"Слово '{searchWord}' зустрілося у файлі {count} разів.");
//        }
//        catch (FileNotFoundException ex)
//        {
//            Console.WriteLine($"Помилка: {ex.Message}");
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine($"Інша помилка: {ex.Message}");
//        }
//    }

//    static async Task<int> SearchWordInFileAsync(string filePath, string searchWord)
//    {
//        if (!File.Exists(filePath))
//        {
//            throw new FileNotFoundException("Файл не знайдено.");
//        }

//        using (StreamReader reader = new StreamReader(filePath))
//        {
//            string content = await reader.ReadToEndAsync();
//            string[] words = content.Split(new char[] { ' ', '\n', '\r', '.', ',', ';', ':', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

//            int count = 0;
//            foreach (string word in words)
//            {
//                if (word.Equals(searchWord, StringComparison.OrdinalIgnoreCase))
//                {
//                    count++;
//                }
//            }

//            return count;
//        }
//    }
//}