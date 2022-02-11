using System;

namespace School_Firedepartment
{
    class AlarmEventArgs : EventArgs
    {
        public School School { get; }
        public DateTime Time { get; }
        public int Floor { get; }
        public UrgencyLevel UrgencyLevel { get; }

        public AlarmEventArgs(School school, DateTime time, int floor, UrgencyLevel urgencyLevel)
        {
            School = school;
            Time = time;
            Floor = floor;
            UrgencyLevel = urgencyLevel;
        }
    }
}
