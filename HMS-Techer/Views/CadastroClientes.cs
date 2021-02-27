using System;
using System.Collections.Generic;
using System.Text;

namespace HMS_Techer.Views
{
    class CadastroClientes 
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
            ConsolePrint.Print("\t\t     Cadastrar um novo cliente               ", ConsoleColor.DarkCyan, ConsoleColor.Gray);
            

            Console.ReadLine();
            return (int)Views.Telas.MenuPrincipal;
        }
    }
}
