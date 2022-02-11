using System;
using System.Diagnostics;
using System.Threading;

namespace School_Firedepartment
{
    class Program
    {
        static void Main(string[] args)
        {
            var fireDepartment = new FireDepartment("Feuerwehr 1220"); // Observor
            var htlDonaustadt = new School("HTL - Donaustadt", "Deinleinstraße 45", 3); // Obervable
            var bernoulligymnasium = new School("Bernoulligymnasium", "Bernoulligasse 3", 5);
            var herthaFirnbergSchule = new School("Hertha Firnberg Schule", "Firnbergstraße 1", 6);

            // Registration
            htlDonaustadt.Alarm += fireDepartment.NotifyNewFire;
            bernoulligymnasium.Alarm += fireDepartment.NotifyNewFire;
            herthaFirnbergSchule.Alarm += fireDepartment.NotifyNewFire;

            // Simulation for 10 sec
            Stopwatch watch = new Stopwatch();
            watch.Start();

            while (watch.ElapsedMilliseconds < 20_000) // 20 sec
            {
                htlDonaustadt.AlarmTrigger();
                bernoulligymnasium.AlarmTrigger();
                herthaFirnbergSchule.AlarmTrigger();

                Console.WriteLine(fireDepartment);

                Thread.Sleep(1000); // 1 sec
            }

            watch.Stop();

            // Unregister
            htlDonaustadt.Alarm -= fireDepartment.NotifyNewFire;
            bernoulligymnasium.Alarm -= fireDepartment.NotifyNewFire;
            herthaFirnbergSchule.Alarm -= fireDepartment.NotifyNewFire;

            Console.ReadKey();
        }
    }
}
