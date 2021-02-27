using System;
using System.Collections.Generic;
using System.Text;

namespace HMS_Techer.Views
{
    class ListarQuartos 
    {
        public static int Run()
        {
            Console.Clear();
            Tela.Header();
            Tela.Footer();

            ConsolePrint.Print("\t\t                                             ", ConsoleColor.DarkCyan, ConsoleColor.Gray);
            Console.WriteLine();
            ConsolePrint.Print("\t\t                                             ", ConsoleColor.DarkCyan, ConsoleColor.Gray);
            Console.WriteLine();
            ConsolePrint.Print("\t\t     Listar Quartos                          ", ConsoleColor.DarkCyan, ConsoleColor.Gray);
            Console.WriteLine();
            ConsolePrint.Print("\t\t                                             ", ConsoleColor.DarkCyan, ConsoleColor.Gray);
            Console.WriteLine();
            ConsolePrint.Print("\t\t     Buscar Quartos:                         ", ConsoleColor.DarkCyan, ConsoleColor.Gray);
            var cursorPos = (Console.CursorLeft, Console.CursorTop);

            Console.WriteLine();
            ConsolePrint.Print("\t\t                                             ", ConsoleColor.DarkCyan, ConsoleColor.Gray);
            Console.WriteLine();

            ConsolePrint.Print("\t\t     O - Ocupados                            " + System.Environment.NewLine, ConsoleColor.DarkCyan, ConsoleColor.Gray);
            ConsolePrint.Print("\t\t     L - Livres                              " + System.Environment.NewLine, ConsoleColor.DarkCyan, ConsoleColor.Gray);
            ConsolePrint.Print("\t\t     R - Reservados                          " + System.Environment.NewLine, ConsoleColor.DarkCyan, ConsoleColor.Gray);
            ConsolePrint.Print("\t\t     M - Em Manutenção                       " + System.Environment.NewLine, ConsoleColor.DarkCyan, ConsoleColor.Gray);
            ConsolePrint.Print("\t\t                                             ", ConsoleColor.DarkCyan, ConsoleColor.Gray);
            Console.WriteLine();
            ConsolePrint.Print("\t\t                                             ", ConsoleColor.DarkCyan, ConsoleColor.Gray);
            Tela.Footer();
            Console.SetCursorPosition(cursorPos.CursorLeft - 25, cursorPos.CursorTop);

            ConsoleColor originalForeground = Console.ForegroundColor;
            ConsoleColor originalBackground = Console.BackgroundColor;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Red;

            Console.ReadLine();

            Console.BackgroundColor = originalBackground;
            Console.ForegroundColor = originalForeground;

            return (int)Views.Telas.MenuPrincipal;
        }
    }
}
