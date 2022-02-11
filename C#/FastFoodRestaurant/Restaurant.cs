using System;
using System.Collections.Generic;
using System.Threading;

namespace FastFoodRestaurant // MARKOVIC
{
    class Restaurant
    {
        #region Class variables
        private static int maxWaitingTime = 0;
        private static int maxWaitingAndProcessingTime = 0;
        private static Random rnd = new Random();
        private Queue<Car> driveIn_1;
        private Queue<Car> driveIn_2;
        private const int MAX_CARS_COUNT = 7  /*max cars*/;
        #endregion

        #region Constructor
        public Restaurant()
        {
            driveIn_1 = new Queue<Car>();
            driveIn_2 = new Queue<Car>();
        }
        #endregion

        #region Auxiliary methods
        public void DecideWhichDriveIn(ref Queue<Car> driveIn_1, ref Queue<Car> driveIn_2, int procenture)
        {
            if (rnd.Next(0, 100) < procenture)
            {
                if (driveIn_1.Count < 4 /*&& driveIn_1.Count != */)
                {
                    driveIn_1.Enqueue(new Car());  // Kunde stellt sich in die Warteschlange
                }
                else
                {
                    // 1er   2er
                    //  5    2   -> 2er
                    //  5    4   -> 2er
                    //  5    6   -> 1er
                    //  5    7   -> 1er
                    //  7    7   -> gar nicht
                    if (driveIn_1.Count < driveIn_2.Count)
                    {
                        driveIn_1.Enqueue(new Car());
                    }
                    else if (driveIn_2.Count < driveIn_1.Count)
                    {
                        driveIn_2.Enqueue(new Car());
                    }
                    else if (driveIn_1.Count == MAX_CARS_COUNT)
                    {
                        if (driveIn_2.Count == MAX_CARS_COUNT)
                        {
                            /*Console.WriteLine($"nicht möglich");*/
                            return;
                        }
                        else
                            driveIn_2.Enqueue(new Car());
                    }
                    else if (driveIn_2.Count == MAX_CARS_COUNT)
                    {
                        if (driveIn_1.Count == MAX_CARS_COUNT)
                        {
                            /*Console.WriteLine($"nicht möglich");*/
                            return;
                        }
                        else
                            driveIn_1.Enqueue(new Car());
                    }
                    else if (driveIn_1.Count == driveIn_2.Count)
                    {
                        driveIn_1.Enqueue(new Car());
                    }
                }
            }
        }
        public void GetMaxTimes(Car car)
        {
            if (car.WaitingTime > maxWaitingTime)
                maxWaitingTime = car.WaitingTime;
            if (car.WaitingTime + car.ProcessingTimeTotal > maxWaitingAndProcessingTime)
                maxWaitingAndProcessingTime = car.WaitingTime + car.ProcessingTimeTotal;
        }
        public void ProcessDriveIn_1()
        {
            if (driveIn_1.Count > 0)
            {
                Car firstCarDriveIn1 = driveIn_1.Peek();
                firstCarDriveIn1.BeingProcessed();

                if (firstCarDriveIn1.IsDone)
                {
                    GetMaxTimes(firstCarDriveIn1);
                    driveIn_1.Dequeue();
                }
            }
        }
        public void ProcessDriveIn_2()
        {
            if (driveIn_2.Count > 0)
            {
                Car firstCarDriveIn2 = driveIn_1.Peek();
                firstCarDriveIn2.BeingProcessed();

                if (firstCarDriveIn2.IsDone)
                {
                    GetMaxTimes(firstCarDriveIn2);
                    driveIn_2.Dequeue();
                }
            }
        }
        #endregion

        public void Simulate(DateTime dtStart, DateTime dtEnde)
        {
            // Sobald das Restaurant öffnet, befinden sich bereits ein Auto vor dem ersten Drive-In
            Car firstCar = new Car();
            driveIn_1.Enqueue(firstCar); //Schalter(mit Wartezeit 0).
            Console.WriteLine(firstCar.Identifier);

            for (DateTime dt = dtStart; dt <= dtEnde; dt = dt.AddMinutes(1))
            {
                #region Output
                Console.WriteLine($"{dt.ToShortTimeString()}:\nDriveIn One: {driveIn_1.Count} -> {string.Join(",", driveIn_1)}\nDriveIn Two: {driveIn_2.Count} -> {string.Join(",", driveIn_2)}\nMax. Waitingtime yet: {maxWaitingTime} min | Max. Waiting- and Processingtime yet: {maxWaitingAndProcessingTime} min\n");
                #endregion

                #region Increase Waitingtime
                foreach (var car in driveIn_1)
                    car.Waits();

                foreach (var car in driveIn_2)
                    car.Waits();

                #endregion

                #region Processing of the waiting cars
                ProcessDriveIn_1();
                ProcessDriveIn_2();
                #endregion

                #region Adding cars to queue
                if (dt.Hour == 12 && dt.Minute <= 30)
                {   // Between 12:00 and 12:30
                    DecideWhichDriveIn(ref driveIn_1, ref driveIn_2, 60);
                }
                else
                {
                    // Not between 12:00 and 12:30
                    DecideWhichDriveIn(ref driveIn_1, ref driveIn_2, 42);
                }
                #endregion

                Thread.Sleep(600);
            }
        }
    }
}