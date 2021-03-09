using System;
using HMS_Techer.Dados;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace HMS_Techer.Servicos.Reserva
{
    class ReservaService
    {
        public static bool CriarNovaReserva(Modelos.ReservaFormularioModel reservaFormularioModelo)
        {
            var context = new HmsTecherContext();
            var quartoBusca = context.Quarto.Where(q => q.QuartoId == reservaFormularioModelo.QuartoNumero).FirstOrDefault();
            var clienteBusca = Cliente.ClienteService.BuscarClienteCompleto(reservaFormularioModelo.ClienteCpf);

            if (quartoBusca.SituacaoId == 1 && clienteBusca != null)
            {

                context.Reserva.Add(new Entidades.Reserva
                {
                    ReservaId = context.Reserva.ToList().Count + 1,
                    DataCriacao = DateTime.Now,
                    CpfReserva = clienteBusca.Cpf,
                    QuartoId = quartoBusca.QuartoId
                });
                quartoBusca.SituacaoId = 3;

                context.SaveChanges();
                return true;
            }

            else
                return false;

        }
        public static void MostrarUltimaReserva()
        {
            var context = new HmsTecherContext();
            var reserva = context.Reserva
                .Include(r => r.ClienteReserva)
                .Include(r => r.Quarto)
                .ThenInclude(r => r.Situacao)
                .Include(r => r.Quarto)
                .ThenInclude(r => r.Tipo)
                .ToList()
                .Last<Entidades.Reserva>();

            var reservaModelo = new Reserva.Modelos.ReservaRealizadaModel
            {
                ReservaId = reserva.ReservaId,
                DataCriacao = reserva.DataCriacao,
                Cliente = new Cliente.Modelos.ClienteFormularioModel
                {
                    Cpf = reserva.ClienteReserva.Cpf,
                    NomeCompleto = reserva.ClienteReserva.NomeCompleto,
                    DataNascimento = reserva.ClienteReserva.DataNascimento,
                    Email = reserva.ClienteReserva.Email,
                    TelefoneCelular = reserva.ClienteReserva.TelefoneCelular
                },
                Quarto = new Quarto.QuartoModel
                {
                    QuartoId = reserva.Quarto.QuartoId,
                    Situacao = reserva.Quarto.Situacao,
                    Tipo = reserva.Quarto.Tipo
                }
            };

            Console.WriteLine(reservaModelo);
        }

        /*public static bool FazerCheckIn(int reservaId, string hospedeCpf)
        {

            var hospede = Dados.DadosLocais.ClienteCadastrados.Find(a => a.Cpf == hospedeCpf);

            if (hospede == null) 
            {
                return false;
            }

            foreach (Entidades.Reserva reserva in Dados.DadosLocais.Reservas)
            {
                if (reserva.ReservaId == reservaId )
                {
                    reserva.Hospedes.Add(hospede);
                    reserva.HospedesJSON = hospedeCpf + "/" + string.Empty;
                    reserva.DataCheckIn = DateTime.Now;
                    reserva.Quarto.Situacao.SituacaoId = 2;
                    reserva.Quarto.Situacao.Descricao = "Ocupado";
                    return true;
                }
            }

            return false;

        }

        public static bool FazerCheckIn(int reservaId, string hospedeCpf1, string hospedeCpf2)
        {

            var hospede = Dados.DadosLocais.ClienteCadastrados.Find(a => a.Cpf == hospedeCpf1);
            var hospede2 = Dados.DadosLocais.ClienteCadastrados.Find(a => a.Cpf == hospedeCpf2);

            if (hospede == null || hospede2 == null)
            {
                return false;
            }

            foreach (Entidades.Reserva reserva in Dados.DadosLocais.Reservas)
            {
                if (reserva.ReservaId == reservaId )
                {
                    reserva.Hospedes.Add(hospede);
                    reserva.Hospedes.Add(hospede2);
                    reserva.HospedesJSON = hospedeCpf1 + "/" + hospedeCpf2;
                    reserva.DataCheckIn = DateTime.Now;
                    reserva.Quarto.Situacao.SituacaoId = 2;
                    reserva.Quarto.Situacao.Descricao = "Ocupado";
                    return true;
                }
            }
            return false;
        }

        public static void FazerCheckOut(int reservaId, double consumoETaxas)
        {
            try
            {
                var reserva = Dados.DadosLocais.Reservas.Find(a => a.ReservaId == reservaId);
                reserva.DataCheckOut = DateTime.Now;
                int diasHospedagem = (reserva.DataCheckOut - reserva.DataCheckIn).Days;
                reserva.ValorDiarias = diasHospedagem * reserva.Quarto.Tipo.Valor;
                reserva.TaxasConsumo = consumoETaxas;
                reserva.ValorFinal = reserva.ValorDiarias + reserva.TaxasConsumo;
                reserva.Quarto.Situacao = new Entidades.SituacaoQuarto { SituacaoId = 4, Descricao = "Em Manutenção" };

                var reservaModelo = new Reserva.Modelos.ReservaFinalModelo
                {
                    ReservaId = reserva.ReservaId,
                    DataCriacao = reserva.DataCriacao,
                    DataCheckIn = reserva.DataCheckIn,
                    DataCheckOut = reserva.DataCheckOut,
                    Cliente = reserva.Cliente,
                    Hospedes = reserva.Hospedes,
                    Quarto = reserva.Quarto,
                    ValorDiarias = reserva.ValorDiarias,
                    TaxasConsumo = reserva.TaxasConsumo,
                    ValorFinal = reserva.ValorFinal
                };

                Console.WriteLine(reservaModelo);
            }
            catch (Exception e)
            {
                Console.WriteLine("CheckIn não realizado, erro encontrado");
                Console.WriteLine(e.Message);
            }
        }

        public static void ListarTodasAsReservas()
        {
            foreach (Entidades.Reserva reserva in Dados.DadosLocais.Reservas)
            {
                var reservaModelo = new Reserva.Modelos.ReservaFinalModelo
                {
                    ReservaId = reserva.ReservaId,
                    DataCriacao = reserva.DataCriacao,
                    DataCheckIn = reserva.DataCheckIn,
                    DataCheckOut = reserva.DataCheckOut,
                    Cliente = reserva.Cliente,
                    Hospedes = reserva.Hospedes,
                    Quarto = reserva.Quarto,
                    ValorDiarias = reserva.ValorDiarias,
                    TaxasConsumo = reserva.TaxasConsumo,
                    ValorFinal = reserva.ValorFinal
                };

                Console.WriteLine(reservaModelo);
            }
        }


        public static void MostrarUltimaReserva()
        {
            var reserva = Dados.DadosLocais.Reservas.Last<Entidades.Reserva>();
            var reservaModelo = new Reserva.Modelos.ReservaRealizadaModelo
            {
                ReservaId = reserva.ReservaId,
                DataCriacao = reserva.DataCriacao,
                Cliente = reserva.Cliente,
                Quarto = reserva.Quarto,
            };

            Console.WriteLine(reservaModelo);
        }

        public static void InicializaReservas()
        {
            foreach (Entidades.Reserva reserva in Dados.DadosLocais.Reservas)
            {
                string[] cpfHospedes = reserva.HospedesJSON.Split('/');
                if (String.IsNullOrEmpty(cpfHospedes[1]))
                {
                    reserva.Hospedes.Add(Dados.DadosLocais.ClienteCadastrados.Find(a => a.Cpf == cpfHospedes[0]));
                }
                else
                {
                    var hospede1 = Dados.DadosLocais.ClienteCadastrados.Find(a => a.Cpf == cpfHospedes[0]);
                    var hospede2 = Dados.DadosLocais.ClienteCadastrados.Find(a => a.Cpf == cpfHospedes[1]);
                    reserva.Hospedes.Add(hospede1);
                    reserva.Hospedes.Add(hospede2);
                }
                reserva.Quarto.Situacao = Servicos.Quarto.QuartoService.ParseSituacao(reserva.QuartoSituacaoID);
            }
        }
        public static bool ReservaValidaOut(int reservaId)
        {
            var reserva = Dados.DadosLocais.Reservas.Find(a => a.ReservaId == reservaId);

            if (reserva == null)
            {
                Console.WriteLine("\t\t Reserva não encontrada");

                Console.Write("\t\t Pressiona qualquer tecla para continuar");
                Console.ReadLine();
                return false;
            }
            if(reserva.Quarto.Situacao.SituacaoId != 2)
            {
                Console.WriteLine("\t\t Não foi efetuado Check Out, Não foi realizado check in para essa reserva");

                Console.Write("\t\t Pressiona qualquer tecla para continuar");
                Console.ReadLine();
                return false;
            }

            return true;
        }
        public static bool ReservaValidaIn(int reservaId)
        {
            var reserva = Dados.DadosLocais.Reservas.Find(a => a.ReservaId == reservaId);

            if (reserva == null)
            {
                Console.WriteLine("\t\t Reserva não encontrada");

                Console.Write("\t\t Pressiona qualquer tecla para continuar");
                Console.ReadLine();
                return false;
            }

            return true;
        }
        public static Quarto.QuartoModelo QuartoDaReserva(int reservaId)
        {
            var reserva = Dados.DadosLocais.Reservas.Find(a => a.ReservaId == reservaId);

            if (reserva == null)
                return null;

            var quartoReserva = new Quarto.QuartoModelo
            {
                QuartoId = reserva.Quarto.QuartoId,
                Situacao = reserva.Quarto.Situacao,
                Tipo = reserva.Quarto.Tipo
            };

            return quartoReserva;
        }*/
    }
}
