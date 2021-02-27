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

        public static void Header()
        {
            Console.WriteLine();
            Console.WriteLine();
            ConsolePrint.Print("\t\t\t\t    HMS TECHER    ", ConsoleColor.DarkCyan, ConsoleColor.Gray);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }

        public static void Footer()
        {
            int originalX = Console.CursorLeft;
            int originalY = Console.CursorTop;
            Console.SetCursorPosition(0, Console.WindowHeight);
            ConsolePrint.Print("               --" + DateTime.Now.ToString("f") + "--    " + "         --Operador: " + Dados.DadosLocais.NomeFuncionario + "--",
                ConsoleColor.DarkCyan, ConsoleColor.Gray);
            int cursorPos = Console.CursorLeft;
            for(int i = cursorPos;i < Console.WindowWidth; i++)
            {
                ConsolePrint.Print(" ", ConsoleColor.DarkCyan, ConsoleColor.Gray);
            }

            Console.SetCursorPosition(originalX, originalY);
        }
    }
}
