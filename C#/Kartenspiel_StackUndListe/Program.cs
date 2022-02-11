using System;
using System.Collections.Generic;
using System.Linq;

namespace Kartenspiel_StackUndListe
{
    class Program
    {
        // MARKOVIC
        static List<int> CreateList(int count, int countOfJokers, int jokerCard)
        {
            List<int> list = new List<int>();

            for (int i = 1; i <= count; i++)
                list.Add(i);
            for (int i = 0; i < countOfJokers; i++)
                list.Add(jokerCard);
            return list;
        }
        static void WriteList(List<int> list)
        {
            foreach (var element in list)
                Console.Write($"{element} ");
        }
        static void WriteStack(Stack<int> stack)
        {
            foreach (var element in stack)
                Console.Write($"{element} ");
        }
       
        static void Main(string[] args)
        {
            const int JOKER = 100;
            const int countOfJokers = 4;

            // Shuffle cards
            var shuffledCards = CreateList(99, countOfJokers, JOKER).OrderBy(x => Guid.NewGuid()).ToList();
            WriteList(shuffledCards);
            Console.WriteLine(); Console.WriteLine();

            // Create Stack from shuffled list
            Stack<int> stackCards = new Stack<int>(shuffledCards); // (shuffledCards) erspart foreach schleife in der man list in stack speichert
            WriteStack(stackCards);
            Console.Write($"\n\nNickname Player 1: ");
            Player player1 = new Player(Console.ReadLine());

            Console.Write($"Nickname Player 2: ");
            Player player2 = new Player(Console.ReadLine());
            Console.WriteLine();
            

            while (stackCards.Count >= 2)
            {
                int player1PickedCard = player1.PicksCard(stackCards);
                int player2PickedCard = player2.PicksCard(stackCards);

                Console.WriteLine($"{player1.NickName} has picked {player1PickedCard} and {player2.NickName} has picked {player2PickedCard}");
                if (player1PickedCard == JOKER && player2PickedCard == JOKER)
                {
                    Console.Write($"--> Draw! No one has won the round!\n{player1.Points} : {player2.Points}\n");
                }
                else if (player1PickedCard == JOKER && player2PickedCard != JOKER)
                {
                    player1.IncreasePoints();
                    Console.Write($"--> {player1.NickName} has picked the joker! {player1.NickName} has won the round!\n{player1.Points} : {player2.Points} ({player1.NickName} : {player2.NickName})\n\n");
                }
                else if (player1PickedCard != JOKER && player2PickedCard == JOKER)
                {
                    player1.IncreasePoints();
                    Console.Write($"--> {player2.NickName} has picked the joker! {player2.NickName} has won the round!\n{player1.Points} : {player2.Points} ({player1.NickName} : {player2.NickName})\n\n");
                }
                else if (player1PickedCard > player2PickedCard)
                {
                    player1.IncreasePoints();
                    Console.WriteLine($"--> {player1PickedCard} is greater than {player2PickedCard}. {player1.NickName} has won the round!\n{player1.Points} : {player2.Points} ({player1.NickName} : {player2.NickName})\n\n");
                }
                else
                {
                    player2.IncreasePoints();
                    Console.WriteLine($"--> {player2PickedCard} is greater than {player1PickedCard}. {player2.NickName} has won the round!\n{player1.Points} : {player2.Points} ({player1.NickName} : {player2.NickName})\n\n");
                }
            }

            if (player1.Points > player2.Points)
            {
                Console.WriteLine($"---------------------------------------------\n{player1.NickName} has won {player1.Points} rounds! Congrats\n---------------------------------------------");
            }
            else if (player2.Points > player1.Points)
            {
                Console.WriteLine($"---------------------------------------------\n{player2.NickName} has won {player2.Points} rounds! Congrats\n---------------------------------------------");
            }
            else
            {
                Console.WriteLine($"No one has won!");
            }

            Console.ReadKey();
        }
    }
}
