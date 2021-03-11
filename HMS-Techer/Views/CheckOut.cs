using System;
using HMS_Techer.Servicos.Reserva;

namespace HMS_Techer.Views
{
    class CheckOut 
    {
        public static Telas Run(ReservaService reservaService)
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

            if (!reservaService.ReservaValidaOut(numeroReserva))
            {
                return Telas.MenuPrincipal;
            }

            Console.Write("\t\t Insira o valor de taxas e consumo: ");
            double taxasConsumo = double.Parse(Console.ReadLine());

            var reservaCheckOut = reservaService.FazerCheckOut(numeroReserva, taxasConsumo);

            Console.Clear();
            Tela.Header();

            Console.WriteLine();
            ConsolePrint.Print("\t\t              CHECKOUT REALIZADO !          ", ConsoleColor.Green, ConsoleColor.DarkGray);
            Console.WriteLine();

            Console.WriteLine(reservaCheckOut);

            Console.WriteLine("\t\t     Pressione qualquer tecla para retornar ao menu principal");
            Tela.Footer(Console.CursorLeft, Console.CursorTop);
            Console.ReadLine();

            return Telas.MenuPrincipal;
        }
    }
}
