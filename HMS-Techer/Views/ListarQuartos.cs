using HMS_Techer.Servicos.Quarto;
using System;


namespace HMS_Techer.Views
{
    class ListarQuartos 
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

            char escolha = char.Parse(Console.ReadLine());
            

            Console.BackgroundColor = originalBackground;
            Console.ForegroundColor = originalForeground;

            if (escolha == 'o' || escolha == 'O')
            {
                Console.Clear();
                Tela.Header();
                var quartos = quartoService.ListarQuartosPorSituacao(SituacaoEnum.Ocupado);
                foreach(QuartoModel quarto in quartos)
                    Console.WriteLine(quarto);

                Console.WriteLine("\t\t     Pressione qualquer tecla para retornar ao menu principal");
                Tela.Footer(Console.CursorLeft, Console.CursorTop);
                Console.ReadLine();
                return Telas.MenuPrincipal;
            }
            if (escolha == 'l' || escolha == 'L')
            {
                Console.Clear();
                Tela.Header();
                
                var quartos = quartoService.ListarQuartosPorSituacao(SituacaoEnum.Livre);
                foreach (QuartoModel quarto in quartos)
                    Console.WriteLine(quarto);


                Console.WriteLine("\t\t     Pressione qualquer tecla para retornar ao menu principal");
                Tela.Footer(Console.CursorLeft,Console.CursorTop);
                Console.ReadLine();
                return Telas.MenuPrincipal;
            }
            if (escolha == 'r' || escolha == 'R')
            {
                Console.Clear();
                Tela.Header();
                
                var quartos = quartoService.ListarQuartosPorSituacao(SituacaoEnum.Reservado);
                foreach (QuartoModel quarto in quartos)
                    Console.WriteLine(quarto);

                Console.WriteLine("\t\t     Pressione qualquer tecla para retornar ao menu principal");
                Tela.Footer(Console.CursorLeft, Console.CursorTop);
                Console.ReadLine();
                return Telas.MenuPrincipal;
            }
            if (escolha == 'm' || escolha == 'M')
            {
                Console.Clear();
                Tela.Header();
                
                var quartos = quartoService.ListarQuartosPorSituacao(SituacaoEnum.Manutencao);
                foreach (QuartoModel quarto in quartos)
                    Console.WriteLine(quarto);

                Console.WriteLine("\t\t     Pressione qualquer tecla para retornar ao menu principal");
                Tela.Footer(Console.CursorLeft, Console.CursorTop);
                Console.ReadLine();
                return Telas.MenuPrincipal;
            }
            else
            {
                Console.Clear();
                Tela.Header();
                Console.WriteLine();
                ConsolePrint.Print("\t\t              CADASTRO NAO ENCONTRADO !      ", ConsoleColor.Red, ConsoleColor.DarkGray);
                Console.WriteLine();
                Tela.Footer();
            }

            Console.WriteLine("\t\t     Pressione qualquer tecla para retornar ao menu principal");
            Console.ReadLine();
            return Telas.MenuPrincipal;
        }
    }
}
