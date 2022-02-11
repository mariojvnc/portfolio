using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    class Program
    {   // 1. Klassen für ein Rechteck und ein Dreieck anlegen
        // 2. Wir wollen der Klasse Rectangle & Triangle die
        //    Fähigkeiten geben, die Fläche & den Umfang zu berechnen
        //                      => Interfaces
        static void Main(string[] args)
        {
            Rectangle rectangle_1 = new Rectangle(2, 3);
            Triangle triangle_1 = new Triangle(5, 4, 2);

            Console.WriteLine($"{rectangle_1} --- Circumference: {rectangle_1.CalculateCircumference()}\nArea: {rectangle_1.GetArea()} m²");
            Console.WriteLine($"{triangle_1} --- Circumference: {triangle_1.CalculateCircumference()}\nArea: {triangle_1.GetArea()} m²\n");

            List<ICircumference> figures = new List<ICircumference>
            {
                rectangle_1, triangle_1
            };

            foreach (var figure in figures)
            {
                Console.Write(figure);
                if (figure is Rectangle)
                    Console.WriteLine($" ist ein Rechteck");
                else
                    Console.WriteLine($" ist ein Dreieck");
            }

            Console.ReadKey();
        }
    }
}
