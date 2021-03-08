using System;
using System.Threading;

namespace HMS_Techer
{
    class Program
    {

        static void Main(string[] args)
        {
            //Dados.DadosServico.CarregarDados();
            Views.Tela.Carregar();
            bool aplicacaoFinalizada = false;
            int estadoMenu = -1;
            while (!aplicacaoFinalizada)
            {
                switch (estadoMenu)
                {
                    case (int)Views.Telas.Inicio:
                        estadoMenu = Views.Inicio.Run();
                        break;

                    case (int)Views.Telas.MenuPrincipal:
                        estadoMenu = Views.MenuPrincipal.Run();
                        break;

                    case (int)Views.Telas.CadastroClientes:
                        estadoMenu = Views.CadastroClientes.Run();
                        break;

                    case (int)Views.Telas.BuscarCliente:
                        estadoMenu = Views.BuscarCliente.Run();
                        break;

                    case (int)Views.Telas.ListarQuartos:
                        estadoMenu = Views.ListarQuartos.Run();
                        break;

                    case (int)Views.Telas.RealizarReserva:
                        estadoMenu = Views.RealizarReserva.Run();
                        break;

                    case (int)Views.Telas.CheckIn:
                        estadoMenu = Views.CheckIn.Run();
                        break;

                    case (int)Views.Telas.CheckOut:
                        estadoMenu = Views.CheckOut.Run();
                        break;

                    case (int)Views.Telas.Finalizar:
                        aplicacaoFinalizada = true;
                        break;

                }

            }

            //Dados.DadosServico.SalvarTodosOsDados();
            Console.Clear();
            Views.Tela.Header();
            Console.WriteLine();
            Views.ConsolePrint.Print("\t\t             FINALIZANDO O SISTEMA            ", ConsoleColor.DarkCyan, ConsoleColor.Gray);
            Console.WriteLine();
            Views.Tela.Footer();
            Thread.Sleep(2000);
            System.Environment.Exit(0);
           
        }

       
    }
}
