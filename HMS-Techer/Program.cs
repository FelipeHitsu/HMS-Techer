using System;
using System.Threading;

namespace HMS_Techer
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Console.SetWindowSize(120, 30);

            //Views.Tela.ConfigurarJanela();
            Console.WriteLine("Hello World!");
            Thread.Sleep(1000);
            Views.Tela.Carregar();
            Console.WriteLine("OK");*/

            /*Servicos.Cliente.ClienteServico.CadastrarCliente(new Servicos.Cliente.Modelos.ClienteFormularioModelo
            {
                NomeCompleto = "Joao da Silva",
                Cpf = "00000000001",
                DataNascimento = DateTime.Parse("19/01/1971"),
                Email = "JoaoDaSilva@email.com",
                TelefoneCelular = "41995246164"
            });

            Dados.DadosServico.SalvarTodosOsDados();*/

            Dados.DadosServico.CarregarDados();
            Servicos.Cliente.ClienteServico.ListarTodosOsClientes();

            //Servicos.Quarto.QuartoServico.PrimeiraInstanciaQuartos();

            //Servicos.Quarto.QuartoServico.ListarQuartos();

            // Dados.DadosServico.SalvarTodosOsDados();

            //Servicos.Cliente.ClienteServico.MostrarCliente("00000000001");

            Servicos.Reserva.ReservaServico.CriarNovaReserva(new Servicos.Reserva.Modelos.ReservaFormularioModelo { ClienteCpf = "00000000001", QuartoNumero = 35 });
            Servicos.Reserva.ReservaServico.CriarNovaReserva(new Servicos.Reserva.Modelos.ReservaFormularioModelo { ClienteCpf = "00000000002", QuartoNumero = 10 });
            Servicos.Reserva.ReservaServico.FazerCheckIn(1, "00000000001");
            Servicos.Reserva.ReservaServico.FazerCheckOut(1, 150);
            Console.WriteLine(Dados.DadosLocais.Reservas.Count);
            Servicos.Reserva.ReservaServico.ListarTodasAsReservas();

            Console.ReadLine();
        }
    }
}
