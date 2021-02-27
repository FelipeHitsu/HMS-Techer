using System;
using System.Collections.Generic;
using System.Text;

namespace HMS_Techer.Views
{
    class RealizarReserva 
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
            ConsolePrint.Print("\t\t     Realizar uma Reserva                    ", ConsoleColor.DarkCyan, ConsoleColor.Gray);
            Console.WriteLine();
            ConsolePrint.Print("\t\t                                             ", ConsoleColor.DarkCyan, ConsoleColor.Gray);
            Console.WriteLine();

            var formularioReserva = new Servicos.Reserva.Modelos.ReservaFormularioModelo();

            Console.Write("\t\t Insira o Número do Quarto a reservar: ");
            int quartoSelecionado = int.Parse(Console.ReadLine());

            Console.Write("\t\t Insira o Número CPF do cliente (11 Digitos sem pontuação): ");
            string cpfCadastro = Console.ReadLine();

            formularioReserva.QuartoNumero = quartoSelecionado;
            formularioReserva.ClienteCpf = cpfCadastro;

            Servicos.Reserva.ReservaServico.CriarNovaReserva(formularioReserva);

            Console.WriteLine();
            ConsolePrint.Print("\t\t              RESERVA REALIZADA !          ", ConsoleColor.Green, ConsoleColor.DarkGray);
            Console.WriteLine();

            Console.ReadLine();
            return (int)Views.Telas.MenuPrincipal;
        }
    }
}
