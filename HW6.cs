using System;
using System.Threading;

class Program
{
    static int maxPassengers = 30;
    static int totalPassengers = 0; 
    static object lockObject = new object();
    static Random random = new Random();

    static event Action<int> BusArrived;

    static void Main()
    {
        BusArrived += OnBusArrived; 

        Thread busThread = new Thread(SimulateBus);
        busThread.Start();

        for (int i = 0; i < 24; i++)
        {
            int newPassengers = random.Next(1, 10); 
            lock (lockObject)
            {
                totalPassengers += newPassengers; 
                Console.WriteLine($"На зупинку прибуло {newPassengers} нових пасажирів. Загальна кількість на зупинці: {totalPassengers}");
            }

            Thread.Sleep(1000); 
        }

        Console.WriteLine("Робота автобусної кінцевої зупинки завершена.");

        Environment.Exit(0); 
    }


    static void SimulateBus()
    {
        while (true)
        {
            Thread.Sleep(5000); 

            BusArrived?.Invoke(maxPassengers);
        }
    }

    static void OnBusArrived(int passengersInBus)
    {
        lock (lockObject)
        {
            int passengersLeaving = Math.Min(passengersInBus, totalPassengers); 
            totalPassengers -= passengersLeaving; 

            Console.WriteLine($"Автобус прибув. Пасажирів у автобусі: {passengersLeaving}. Залишилось на зупинці: {totalPassengers}");
        }
    }
}
