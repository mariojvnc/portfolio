using System;

namespace Erdbeben_AlterTest
{
    class EinsatzbestätigungEventArgs : EventArgs
    {
        public string Name { get; private set; }
        public DateTime Ankunftszeit { get; private set; }

        public EinsatzbestätigungEventArgs(string name, DateTime ankunftszeit)
        {
            Name = name;
            Ankunftszeit = ankunftszeit;
        }
    }
}
