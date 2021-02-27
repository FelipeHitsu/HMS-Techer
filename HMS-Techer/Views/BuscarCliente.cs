using System;
using System.Collections.Generic;
using System.Text;

namespace HMS_Techer.Views
{
    class BuscarCliente 
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
            ConsolePrint.Print("\t\t     Buscar um cliente                       ", ConsoleColor.DarkCyan, ConsoleColor.Gray);


            Console.ReadLine();
            return (int)Views.Telas.MenuPrincipal;
        }
    }
}
