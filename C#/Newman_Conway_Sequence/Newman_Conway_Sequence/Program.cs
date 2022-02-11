using System;
using System.Numerics;
using System.Text;
using System.Threading;

namespace Newman_Conway_Sequence
{
    class Program
    {
        static BigInteger NextNumber(BigInteger number)
        {
            StringBuilder builder = new StringBuilder();
            char c = number.ToString()[0];
            int counter = 1;
            for (int i = 1; i < number.ToString().Length; i++)
            {
                char cNext = number.ToString()[i];
                if (cNext != c)
                {
                    builder.Append(counter);
                    builder.Append(c);
                    counter = 1;
                    c = cNext;
                }
                else
                    counter++;
            }
            builder.Append(counter);
            builder.Append(c);
            BigInteger bigInteger = BigInteger.Parse(builder.ToString());
            return bigInteger;
        }
        static void Main(string[] args)
        {
            Console.Write($"Give me a number: ");
            var number = int.Parse(Console.ReadLine());
            BigInteger bigInteger = new BigInteger(number);
            var newnumber = NextNumber(number);
            Console.WriteLine(newnumber);
            while (true)
            {
                var help = newnumber;
                newnumber = NextNumber(help);
                Console.WriteLine(newnumber);
                Thread.Sleep(300);
            }
        }
    }
}
