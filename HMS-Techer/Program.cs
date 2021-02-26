using System;
using System.Threading;

namespace HMS_Techer
{
    class Program
    {
        static void Main(string[] args)
        {
            Views.Tela.ConfigurarJanela();
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

                }
                Console.ReadLine();
            }
            /*Servicos.Cliente.ClienteServico.CadastrarCliente(new Servicos.Cliente.Modelos.ClienteFormularioModelo
            {
                NomeCompleto = "Joao da Silva",
                Cpf = "00000000001",
                DataNascimento = DateTime.Parse("19/01/1971"),
                Email = "JoaoDaSilva@email.com",
                TelefoneCelular = "41995246164"
            });

            Dados.DadosServico.SalvarTodosOsDados();*/

            //Dados.DadosServico.CarregarDados();
            //Servicos.Cliente.ClienteServico.ListarTodosOsClientes();

            //Servicos.Quarto.QuartoServico.PrimeiraInstanciaQuartos();

            //Servicos.Quarto.QuartoServico.ListarQuartos();

            // Dados.DadosServico.SalvarTodosOsDados();

            //Servicos.Cliente.ClienteServico.MostrarCliente("00000000001");

            // Servicos.Reserva.ReservaServico.CriarNovaReserva(new Servicos.Reserva.Modelos.ReservaFormularioModelo { ClienteCpf = "00000000001", QuartoNumero = 35 });
            // Servicos.Reserva.ReservaServico.CriarNovaReserva(new Servicos.Reserva.Modelos.ReservaFormularioModelo { ClienteCpf = "00000000002", QuartoNumero = 10 });
            //Servicos.Reserva.ReservaServico.FazerCheckIn(1, "00000000001");
            // Servicos.Reserva.ReservaServico.FazerCheckOut(1, 150);
            //Console.WriteLine(Dados.DadosLocais.Reservas.Count);
            //Servicos.Reserva.ReservaServico.ListarTodasAsReservas();
            //Dados.DadosServico.SalvarTodosOsDados();

            
        }
    }
}
