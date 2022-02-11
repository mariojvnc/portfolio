using System;

namespace FastFoodRestaurant // MARKOVIC
{
    class Car
    {
        private static Random rnd = new Random();
        private static int NextNumber = 1;

        #region Properties
        public int Identifier { get; private set; }
        public int ProcessingTime { get; private set; } // Bearbeitungszeit
        public int ProcessingTimeTotal { get; private set; } // Bearbeitungszeit, die nicht immer -1 gerechnet wird

        public int WaitingTime { get; private set; } // Wartezeit
        public bool IsDone
        {
            get
            {
                return ProcessingTime == 0;
            }
        }
        #endregion

        #region Construcor
        public Car()
        {
            Identifier = NextNumber;
            NextNumber++;

            ProcessingTime = rnd.Next(1, 4); // 1, 2 or 3 minutes
            ProcessingTimeTotal = ProcessingTime;
        }
        #endregion

        #region Methods
        public void Waits() { WaitingTime++; }
        public void BeingProcessed()
        {
            if (ProcessingTime != 0)
                ProcessingTime--;
        }
        #endregion

        #region ToString()
        public override string ToString() => $"{Identifier}({ProcessingTime})";
        #endregion
    }
}