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
            Console.WriteLine();
            ConsolePrint.Print("\t\t                                             ", ConsoleColor.DarkCyan, ConsoleColor.Gray);
            Console.WriteLine();
            Console.Write("\t\t     Insira o CPF: ");
            string cpf = Console.ReadLine();

            var resultadoBusca = Servicos.Cliente.ClienteServico.BuscarCliente(cpf);

            if(resultadoBusca != null)
            {
                Console.WriteLine(resultadoBusca);
                Console.WriteLine();
                ConsolePrint.Print("\t\t              CLIENTE ENCONTRADO !           ", ConsoleColor.Green, ConsoleColor.DarkGray);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine();
                ConsolePrint.Print("\t\t              CADASTRO NAO ENCONTRADO !      ", ConsoleColor.Red, ConsoleColor.DarkGray);
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("\t\t Pressione qualquer tecla para retornar ao menu...");
            Console.ReadLine();
            return (int)Views.Telas.MenuPrincipal;
        }
    }
}
