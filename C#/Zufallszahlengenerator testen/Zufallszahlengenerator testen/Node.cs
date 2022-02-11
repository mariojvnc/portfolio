using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zufallszahlengenerator_testen
{
    class Node
    {
        public int Value { get; private set; }
        public Node Next { get; private set; }
        public Node Previous { get; private set; }

        public Node(int value, Node next, Node previous)
        {
            Value = value;
            Next = next;
            Previous = previous;
        }
    }
}
