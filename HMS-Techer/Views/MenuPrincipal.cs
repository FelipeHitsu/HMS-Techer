using System;
using HMS_Techer.Servicos.Quarto;

namespace HMS_Techer.Views
{
    class MenuPrincipal
    {
        public static Telas Run(QuartoService quartoService)
        {
            Console.Clear();
            Tela.Header();
            Tela.Footer();

            ConsolePrint.Print("\t\t                                             ", ConsoleColor.DarkCyan, ConsoleColor.Gray);
            Console.WriteLine();
            ConsolePrint.Print("\t\t                                             ", ConsoleColor.DarkCyan, ConsoleColor.Gray);
            Console.WriteLine();
            ConsolePrint.Print("\t\t     Menu Principal                          ", ConsoleColor.DarkCyan, ConsoleColor.Gray);
            Console.WriteLine();
            ConsolePrint.Print("\t\t     Selecionar Atividade:                   ", ConsoleColor.DarkCyan, ConsoleColor.Gray);
            var cursorPos = (Console.CursorLeft, Console.CursorTop);

            Console.WriteLine();
            ConsolePrint.Print("\t\t                                             ", ConsoleColor.DarkCyan, ConsoleColor.Gray);
            Console.WriteLine();

            ConsolePrint.Print("\t\t     1 - Cadastrar um Cliente                " + System.Environment.NewLine, ConsoleColor.DarkCyan, ConsoleColor.Gray);
            ConsolePrint.Print("\t\t     2 - Buscar o cadastro de um cliente     " + System.Environment.NewLine, ConsoleColor.DarkCyan, ConsoleColor.Gray);
            ConsolePrint.Print("\t\t     3 - Listar Quartos                      " + System.Environment.NewLine, ConsoleColor.DarkCyan, ConsoleColor.Gray);
            ConsolePrint.Print("\t\t     4 - Realizar uma reserva                " + System.Environment.NewLine, ConsoleColor.DarkCyan, ConsoleColor.Gray);
            ConsolePrint.Print("\t\t     5 - Realizar um check in                " + System.Environment.NewLine, ConsoleColor.DarkCyan, ConsoleColor.Gray);
            ConsolePrint.Print("\t\t     6 - Realizar um check out               " + System.Environment.NewLine, ConsoleColor.DarkCyan, ConsoleColor.Gray);
            ConsolePrint.Print("\t\t     7 - Encerrar o sistema                  " + System.Environment.NewLine, ConsoleColor.DarkCyan, ConsoleColor.Gray);
            ConsolePrint.Print("\t\t     8 - Liberar Quartos em Manutenção       " + System.Environment.NewLine, ConsoleColor.DarkCyan, ConsoleColor.Gray);
            ConsolePrint.Print("\t\t                                             ", ConsoleColor.DarkCyan, ConsoleColor.Gray);
            Console.WriteLine();
            ConsolePrint.Print("\t\t                                             ", ConsoleColor.DarkCyan, ConsoleColor.Gray);
            Tela.Footer();
            Console.SetCursorPosition(cursorPos.CursorLeft - 18, cursorPos.CursorTop);

            ConsoleColor originalForeground = Console.ForegroundColor;
            ConsoleColor originalBackground = Console.BackgroundColor;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Red;

            int escolha = int.Parse(Console.ReadLine());

            Console.BackgroundColor = originalBackground;
            Console.ForegroundColor = originalForeground;

            if (escolha == 1)
                return Telas.CadastroClientes;
            if (escolha == 2)
                return Telas.BuscarCliente;
            if (escolha == 3)
                return Telas.ListarQuartos;
            if (escolha == 4)
                return Telas.RealizarReserva;
            if (escolha == 5)
                return Telas.CheckIn;
            if (escolha == 6)
                return Telas.CheckOut;
            if (escolha == 7)
                return Telas.Finalizar;
            if(escolha == 8)
            {
                quartoService.ResetQuartosEmManutencao();
                return Telas.MenuPrincipal;
            }

            else
                return Telas.MenuPrincipal;

        }
    }
}
