using System;

namespace TestBeispielÜbungMitSchamma
{
    class _50MeterErreichtEventArgs : EventArgs
    {
        public double Length { get; private set; }

        public _50MeterErreichtEventArgs(double length)
        {
            Length = length;
        }
    }
}
