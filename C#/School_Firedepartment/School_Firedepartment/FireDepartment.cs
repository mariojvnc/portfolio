using System;

namespace School_Firedepartment
{
    // Observor
    enum UrgencyLevel { Vollbrand, Schwelbrand, UnbekannteStufe }
    class FireDepartment
    {
        public string Name { get; private set; }

        public FireDepartment(string name) { Name = name; }

        public void NotifyNewFire(object sender, AlarmEventArgs args)
        {
            if (!(sender is School))
            {
                throw new InvalidOperationException();
            }
            Console.WriteLine($"{Name} got notifed. NEW FIRE! ");
            School school = (sender as School);

            Console.WriteLine($"{args.Time}: {school} | Floor: {args.Floor} | Urgency level: {args.UrgencyLevel}\n");
        }

        public override string ToString() => Name;
    }
}
