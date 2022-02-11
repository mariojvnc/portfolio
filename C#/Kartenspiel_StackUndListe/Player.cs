using System.Collections.Generic;

namespace Kartenspiel_StackUndListe
{
    class Player
    {
        public string NickName { get; private set; }
        public int Points { get; private set; }
        public Player(string nickName) { NickName = nickName; }

        public int PicksCard(Stack<int> stack)
        {
            if (stack.Count != 0)
                return stack.Pop();

            return 0;
        }
        public void IncreasePoints() { Points++; }
        public override string ToString() => $"{NickName} has {Points}";
    }
}
