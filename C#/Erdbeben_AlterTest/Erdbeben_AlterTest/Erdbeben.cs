using System;
using System.Threading;

namespace Erdbeben_AlterTest
{
    class Erdbeben
    {
        public Random rnd = new Random();
        public event EventHandler<ErdbebenEventArgs> NeuerAusbruch;

        public void Process()
        {
            for (DateTime dt = DateTime.Now; dt <= DateTime.Now.AddHours(5); dt = dt.AddHours(1))
            {
                Console.WriteLine(dt.ToShortTimeString());
                if (rnd.Next(0, 100) < 50) // 50 % Chance
                {
                    Action<DateTime> method = Ausbruch;
                    method.BeginInvoke(dt, null, null);

                }
                Thread.Sleep(1000);
                Console.WriteLine();
            }
        }


        public void Ausbruch(DateTime time)
        {
            var information = new ErdbebenEventArgs(time);
            Console.WriteLine($"Neuer Erdbebenausbruch auf {information.X_Koordinate}/{information.Y_Koordinate}");
            NeuerAusbruch?.Invoke(this, information);
        }
    }
}
