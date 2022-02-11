using System;

namespace TestBeispielÜbungMitSchamma
{
    class _100MeterErreichtEventArgs : EventArgs
    {
        public double Length { get; private set; }

        public _100MeterErreichtEventArgs(double length)
        {
            Length = length;
        }
    }
}
