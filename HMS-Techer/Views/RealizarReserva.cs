﻿using System;
using HMS_Techer.Servicos.Reserva.Modelos;
using HMS_Techer.Servicos.Reserva;

namespace HMS_Techer.Views
{
    class RealizarReserva 
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
            ConsolePrint.Print("\t\t     Realizar uma Reserva                    ", ConsoleColor.DarkCyan, ConsoleColor.Gray);
            Console.WriteLine();
            ConsolePrint.Print("\t\t                                             ", ConsoleColor.DarkCyan, ConsoleColor.Gray);
            Console.WriteLine();

            var formularioReserva = new ReservaFormularioModel();

            Console.Write("\t\t Insira o Número do Quarto a reservar: ");
            int quartoSelecionado = int.Parse(Console.ReadLine());

            Console.Write("\t\t Insira o Número CPF do cliente (11 Digitos sem pontuação): ");
            string cpfCadastro = Console.ReadLine();

            formularioReserva.QuartoNumero = quartoSelecionado;
            formularioReserva.ClienteCpf = cpfCadastro;


            if (reservaService.CriarNovaReserva(formularioReserva))
            {
                Console.WriteLine();
                ConsolePrint.Print("\t\t              RESERVA REALIZADA !          ", ConsoleColor.Green, ConsoleColor.DarkGray);
                Console.WriteLine();

                var ultimaReserva = reservaService.UltimaReserva();

                Console.WriteLine(ultimaReserva);
                Console.ReadLine();
                return Telas.MenuPrincipal;
            }

            Console.WriteLine();
            ConsolePrint.Print("\t\t              QUARTO INDISPONIVEL OU CLIENTE NÃO CADASTRADO !          ", ConsoleColor.Red, ConsoleColor.DarkGray);
            Console.WriteLine();
            Console.ReadLine();
            return Telas.MenuPrincipal;
        }
    }
}
