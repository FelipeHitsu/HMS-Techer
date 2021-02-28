using System;
using System.Collections.Generic;
using System.Text;

namespace HMS_Techer.Views
{
    class CheckOut 
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
            ConsolePrint.Print("\t\t     Realizar um CheckOut                    ", ConsoleColor.DarkCyan, ConsoleColor.Gray);
            Console.WriteLine();
            ConsolePrint.Print("\t\t                                             ", ConsoleColor.DarkCyan, ConsoleColor.Gray);
            Console.WriteLine();

            Console.Write("\t\t Insira o Número da Reserva: ");
            int numeroReserva = int.Parse(Console.ReadLine());

            Console.Write("\t\t Insira o valor de taxas e consumo: ");
            double taxasConsumo = double.Parse(Console.ReadLine());

            Console.Clear();
            Tela.Header();

            Console.WriteLine();
            ConsolePrint.Print("\t\t              CHECKOUT REALIZADO !          ", ConsoleColor.Green, ConsoleColor.DarkGray);
            Console.WriteLine();

            Servicos.Reserva.ReservaServico.FazerCheckOut(numeroReserva, taxasConsumo);

            Console.WriteLine("\t\t     Pressione qualquer tecla para retornar ao menu principal");
            Tela.Footer(Console.CursorLeft, Console.CursorTop);
            Console.ReadLine();

            return (int)Views.Telas.MenuPrincipal;
        }
    }
}
