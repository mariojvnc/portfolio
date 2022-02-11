using System;

namespace School_Firedepartment
{
    // Obervable
    class School
    {
        public string Name { get; private set; }
        public string Adress { get; private set; }
        public int MaxFloors { get; private set; }

        // 1. und 2.
        public event EventHandler<AlarmEventArgs> Alarm;

        public School(string name, string adress, int maxFloors)
        {
            Name = name;
            Adress = adress;
            MaxFloors = maxFloors;
        }

        private static Random rnd = new Random();
        public void AlarmTrigger()
        {
            // zu 15 % wird der Feueralarm ausgelöst
            int r = rnd.Next(0, 100);
            int randomUrgencyIndex;

            if (r < 15)
            {
                randomUrgencyIndex = rnd.Next(1, 4); // 1 - 3
                /*UrgencyLevel urgencyLevel;
                switch (randomUrgencyIndex)
                {
                    case 1: urgencyLevel = UrgencyLevel.Vollbrand; break;
                    case 2: urgencyLevel = UrgencyLevel.Schwelbrand; break;
                    case 3: urgencyLevel = UrgencyLevel.UnbekannteStufe; break;
                    default: throw new ArgumentOutOfRangeException();
                }*/
                Alarm?.Invoke(this, new AlarmEventArgs(this, DateTime.Now, rnd.Next(-1, MaxFloors + 1)/*Floor where the fire broke out*/, (UrgencyLevel)rnd.Next(0, 3)));
            }
        }

        public override string ToString() => $"{Name}, {Adress}";
    }
}
