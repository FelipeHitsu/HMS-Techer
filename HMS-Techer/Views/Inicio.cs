using System;
using System.Collections.Generic;
using System.Text;

namespace HMS_Techer.Views
{
    class Inicio 
    {
        public static int Run()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("\t\t");
            for (int i = 0; i < 41; i++)
                Console.Write("-");

            Console.WriteLine();

            Console.WriteLine("\t\t|\t\tHMS Techer\t\t|");
            Console.WriteLine("\t\t|\t\t          \t\t|");
            Console.Write("\t\t");
            for (int i = 0; i < 41; i++)
                Console.Write("-");

            Console.WriteLine("");
            Console.WriteLine("\t\t|\t\t          \t\t|");
            Console.WriteLine("\t\t|\t\tCarregando\t\t|");
            Console.Write("\t\t");
            for (int i = 0; i < 41; i++)
                Console.Write("-");
            Console.ForegroundColor = ConsoleColor.White;

            Console.ReadLine();

            return (int)Views.Telas.MenuPrincipal;
        }
    }
}
