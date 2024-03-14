using System;
using System.Runtime.InteropServices;



class Program
{

    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    public static extern int SendMessage(IntPtr hWnd, int msg, IntPtr wParam, string lParam);

    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    public static extern int MessageBox(IntPtr hWnd, string text, string caption, uint type);

    [DllImport("kernel32.dll")]
    public static extern bool Beep(int frequency, int duration);

    [DllImport("user32.dll")]
    public static extern bool MessageBeep(uint uType);

    static void Task1()
    {

        string userInfo1 = "Храмцов";
        MessageBox(IntPtr.Zero, userInfo1, "Інформація про користувача", 0x00000040);

        string userInfo2 = "Дмитро";
        MessageBox(IntPtr.Zero, userInfo2, "Інформація про користувача", 0x00000040);

        string userInfo3 = "17 років";
        MessageBox(IntPtr.Zero, userInfo3, "Інформація про користувача", 0x00000040);
    }
    static void Task2()
    {

        string windowTitle = "Form1";
        IntPtr hWnd = FindWindow(null, windowTitle);

        if (hWnd != IntPtr.Zero)
        {
            Console.WriteLine("Вікно знайдено!");

            Console.WriteLine("Оберіть дію:");
            Console.WriteLine("1. Змінити заголовок вікна");
            Console.WriteLine("2. Закрити вікно");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.WriteLine("Введіть новий заголовок:");
                string newTitle = Console.ReadLine();
                SendMessage(hWnd, 0x000C, IntPtr.Zero, newTitle);
            }
            else if (choice == "2")
            {
                SendMessage(hWnd, 0x0010, IntPtr.Zero, null);
            }
            else
            {
                Console.WriteLine("Невірний вибір.");
            }
        }
        else
        {
            Console.WriteLine("Вікно не знайдено.");
        }
    }

    static void Task3()
    {
        Console.WriteLine("Генеруємо звукові сигнали:");

        Console.WriteLine("Beep звук");
        Beep(500, 300);

        Thread.Sleep(1000);

        Console.WriteLine("MessageBeep звук");
        MessageBeep(0xFFFFFFFF);

        Console.WriteLine("Готово.");
    }



    static void Main()
    {
        //Task1();

        //Task2();

        Task3();
    }
}

