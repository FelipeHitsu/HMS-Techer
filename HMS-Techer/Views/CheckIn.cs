using System;
using System.Collections.Generic;
using System.Text;

namespace HMS_Techer.Views
{
    class CheckIn 
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
            ConsolePrint.Print("\t\t     Realizar um CheckIN                    ", ConsoleColor.DarkCyan, ConsoleColor.Gray);
            Console.WriteLine();
            ConsolePrint.Print("\t\t                                             ", ConsoleColor.DarkCyan, ConsoleColor.Gray);
            Console.WriteLine();

            Console.Write("\t\t Insira o Número da Reserva: ");
            int reservaId = int.Parse(Console.ReadLine());

            var quartoReserva = Servicos.Reserva.ReservaServico.QuartoDaReserva(reservaId);

            if(quartoReserva.Situacao.SituacaoId == 1) // Quarto solteiro
            {

            }
            else // Quartos casal e duplo 
            {

            }

            Console.ReadLine();
            return (int)Views.Telas.MenuPrincipal;
        }
    }
}
