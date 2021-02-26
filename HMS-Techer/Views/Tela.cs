﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace HMS_Techer.Views
{
    static class Tela
    {
        public static void ConfigurarJanela()
        {
            Console.SetWindowSize(200, 50);
        }
        public static void Limpar()
        {
            Console.Clear();
        }
        public static void Carregar()
        {
            Limpar();
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
            Thread.Sleep(3000);
            Limpar();
        }
    }
}
