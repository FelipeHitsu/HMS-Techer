using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace HMS_Techer.Views
{
    static class Tela
    {
        public static void ConfigurarJanela()
        {
            Console.SetWindowSize(240, 32);
        }
        public static void Limpar()
        {
            Console.Clear();
        }

        public static void Carregar()
        {
            Limpar();
            Console.SetCursorPosition(64, 15);
            Console.WriteLine("HMS Techer");
            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight/2);
            Console.WriteLine("--------------------------------------------------------");
            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight);
            Console.WriteLine("                        Carregando                      ");
            Thread.Sleep(2000);
            Limpar();
        }
    }
}
