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
            ConsolePrint.Print("\t\t     Realizar um CheckIN                     ", ConsoleColor.DarkCyan, ConsoleColor.Gray);
            Console.WriteLine();
            ConsolePrint.Print("\t\t                                             ", ConsoleColor.DarkCyan, ConsoleColor.Gray);
            Console.WriteLine();

            Console.Write("\t\t Insira o Número da Reserva: ");
            int reservaId = int.Parse(Console.ReadLine());

            

            if (!Servicos.Reserva.ReservaService.ReservaValidaIn(reservaId))
            {
                Console.WriteLine("\t\t Reserva não encontrada");
                Console.WriteLine("\t\t Check In não realizado, erro encontrado");

                Console.Write("\t\t Pressiona qualquer tecla para continuar");
                Console.ReadLine();
                return (int)Views.Telas.CheckIn;
            }

            var quartoReserva = Servicos.Reserva.ReservaService.QuartoDaReserva(reservaId);

            if (quartoReserva.Situacao.SituacaoQuartoId == 3 && quartoReserva.Tipo.TipoQuartoId == 1) // Quarto solteiro
            {
              
                Console.Write("\t\t Insira o Número CPF do Hóspede (11 Digitos sem pontuação): ");
                string cpfHospede = Console.ReadLine();

                if(!Servicos.Reserva.ReservaService.FazerCheckIn(reservaId, cpfHospede))
                {
                    Console.WriteLine("\t\t Check In não realizado, erro encontrado");

                    Console.Write("\t\t Pressiona qualquer tecla para continuar");
                    Console.ReadLine();
                    return (int)Views.Telas.CheckIn;
                }

                Console.WriteLine("\t\t Check in Realizado na Reserva " + reservaId + " na data de " + DateTime.Now.ToString("f"));

                Console.Write("\t\t Pressiona qualquer tecla para continuar");
                Console.ReadLine();
                return (int)Views.Telas.MenuPrincipal;
            }
            else if(quartoReserva.Situacao.SituacaoQuartoId == 3) // Quartos casal e duplo 
            {
                Console.Write("\t\t  Insira o Número de hóspedes (1 / 2): ");
                int numeroDeHospedes = int.Parse(Console.ReadLine());

                if(numeroDeHospedes == 1)
                {
                  
                    Console.Write("\t\t Insira o Número CPF do Hóspede (11 Digitos sem pontuação): ");
                    string cpfHospede = Console.ReadLine();

                    if (!Servicos.Reserva.ReservaService.FazerCheckIn(reservaId, cpfHospede))
                    {
                        Console.WriteLine("\t\t Check In não realizado, erro encontrado");

                        Console.Write("\t\t Pressiona qualquer tecla para continuar");
                        Console.ReadLine();
                        return (int)Views.Telas.CheckIn;
                    }

                    Console.WriteLine("\t\t Check in Realizado na Reserva " + reservaId + " na data de " + DateTime.Now.ToString("f"));

                    Console.Write("\t\t Pressiona qualquer tecla para continuar");
                    Console.ReadLine();
                    return (int)Views.Telas.MenuPrincipal;
                }

                if(numeroDeHospedes == 2)
                {

                    Console.Write("\t\t Insira o Número CPF do Hóspede 1 (11 Digitos sem pontuação): ");
                    string cpfHospede1 = Console.ReadLine();

                    Console.Write("\t\t Insira o Número CPF do Hóspede 2 (11 Digitos sem pontuação): ");
                    string cpfHospede2 = Console.ReadLine();

                    if (!Servicos.Reserva.ReservaService.FazerCheckIn(reservaId, cpfHospede1,cpfHospede2))
                    {
                        Console.WriteLine("\t\t Check In não realizado, quarto indisponivel ou cliente não encontrado");

                        Console.Write("\t\t Pressiona qualquer tecla para continuar");
                        Console.ReadLine();
                        return (int)Views.Telas.CheckIn;
                    }

                    Console.WriteLine("\t\t Check in Realizado na Reserva " + reservaId + " na data de " + DateTime.Now.ToString("f"));

                    Console.Write("\t\t Pressiona qualquer tecla para continuar");
                    Console.ReadLine();
                    return (int)Views.Telas.MenuPrincipal;
                }

                else
                {
                    Console.Write("\t\t Quantidade Invalida");
                    Console.Write("\t\t Pressiona qualquer tecla para continuar");
                    Console.ReadLine();
                    return (int)Views.Telas.CheckIn;
                }
            }

            Console.Write("\t\t Pressiona qualquer tecla para continuar");
            Console.ReadLine();
            return (int)Views.Telas.MenuPrincipal;
        }
    }
}
