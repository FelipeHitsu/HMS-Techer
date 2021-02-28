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
            ConsolePrint.Print("\t\t     Realizar Check In                       ", ConsoleColor.DarkCyan, ConsoleColor.Gray);

            Servicos.Reserva.ReservaServico.ListarTodasAsReservas();

            Console.ReadLine();
            return (int)Views.Telas.MenuPrincipal;
        }
    }
}
