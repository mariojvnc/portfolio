using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryWPF_3AHIF
{
    class Player
    {
        public string Name { get; }
        public int Points { get; private set; }

        public Player(string name) => Name = name;
        public bool IsTurn { get;  set; }
        public void IncrementPoints() => Points++;

        public override string ToString() => $"{Name}: {Points} points";
    }
}
