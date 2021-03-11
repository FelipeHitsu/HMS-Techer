using System;
using System.Threading;
using HMS_Techer.Dados;
using HMS_Techer.Views;
using HMS_Techer.Servicos.Quarto;
using HMS_Techer.Servicos.Cliente;
using HMS_Techer.Servicos.Reserva;

namespace HMS_Techer
{
    class Program
    {

        static void Main(string[] args)
        {
            Tela.Carregar();
            bool aplicacaoFinalizada = false;
            Telas estadoTela = Telas.Inicio;
            //int estadoMenu = -1;
            //inicialização e criação de contextos
            HmsTecherContext context = new HmsTecherContext();
            QuartoService quartoService = new QuartoService(context);
            ClienteService clienteService = new ClienteService(context);
            ReservaService reservaService = new ReservaService(context,clienteService,quartoService);

            while (!aplicacaoFinalizada)
            {
                switch (estadoTela)
                {
                    case Telas.Inicio: //Não precisa desse cast do int
                        estadoTela = Inicio.Run();
                        break;

                    case Telas.MenuPrincipal:
                        estadoTela = MenuPrincipal.Run(quartoService);
                        break;

                    case Telas.CadastroClientes:
                        estadoTela = CadastroClientes.Run(clienteService);
                        break;

                    case Telas.BuscarCliente:
                        estadoTela = BuscarCliente.Run(clienteService);
                        break;

                    case Telas.ListarQuartos:
                        estadoTela = ListarQuartos.Run(quartoService);
                        break;

                    case Telas.RealizarReserva:
                        estadoTela = RealizarReserva.Run(reservaService);
                        break;

                    case Telas.CheckIn:
                        estadoTela = CheckIn.Run(reservaService);
                        break;

                    case Telas.CheckOut:
                        estadoTela = CheckOut.Run(reservaService);
                        break;

                    case Telas.Finalizar:
                        aplicacaoFinalizada = true;
                        break;

                }

            }

            Console.Clear();
            Tela.Header();
            Console.WriteLine();
            ConsolePrint.Print("\t\t             FINALIZANDO O SISTEMA            ", ConsoleColor.DarkCyan, ConsoleColor.Gray);
            Console.WriteLine();
            Tela.Footer();
            Thread.Sleep(2000);
            Environment.Exit(0);
           
        }

       
    }
}
