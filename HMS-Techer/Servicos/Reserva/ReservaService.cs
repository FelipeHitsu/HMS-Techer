using System;
using HMS_Techer.Dados;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using HMS_Techer.Servicos.Quarto;

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
            //Return Model
            Console.WriteLine(reservaModelo);
        }

        public static bool FazerCheckIn(int reservaId, string hospedeCpf)
        {
            var context = new HmsTecherContext();
            var hospede = context.Cliente.Where(a => a.Cpf == hospedeCpf).FirstOrDefault();

            if (hospede == null)
                return false;

            var reserva = context.Reserva.Where(r => r.ReservaId == reservaId).FirstOrDefault();

            var quarto = context.Quarto.Where(q => q.QuartoId == reserva.QuartoId).FirstOrDefault();
            reserva.HospedesJson = hospedeCpf + "/" + string.Empty;
            reserva.CheckIn = DateTime.Now;
            quarto.SituacaoId = 2;
            context.SaveChanges();

            return true;

        }
        //Repensar esse metodo 
        public static bool FazerCheckIn(int reservaId, string hospedeCpf1, string hospedeCpf2)
        {
            var context = new HmsTecherContext();
            var hospede = context.Cliente.Where(a => a.Cpf == hospedeCpf1).FirstOrDefault();
            var hospede2 = context.Cliente.Where(a => a.Cpf == hospedeCpf2).FirstOrDefault();

            if (hospede == null || hospede2 == null)
                return false;

            var reserva = context.Reserva.Where(r => r.ReservaId == reservaId).FirstOrDefault();
            var quarto = context.Quarto.Where(q => q.QuartoId == reserva.QuartoId).FirstOrDefault();

            reserva.HospedesJson = hospedeCpf1 + "/" + hospedeCpf2;
            reserva.CheckIn = DateTime.Now;
            quarto.SituacaoId = 2;
            context.SaveChanges();

            return true;
        }

        public static Modelos.ReservaFinalModel FazerCheckOut(int reservaId, double consumoETaxas)
        {
            var context = new HmsTecherContext();
            //INstanciar o quarto situação e tipo na reserva via query
            var reserva = context.Reserva.Where(a => a.ReservaId == reservaId).FirstOrDefault();
            var quarto = context.Quarto.Where(q => q.QuartoId == reserva.QuartoId).Include(q => q.Tipo).FirstOrDefault();

            reserva.CheckOut = DateTime.Now;
            int diasHospedagem = (reserva.CheckOut.Value - reserva.CheckIn.Value).Days;
            reserva.ValorDiarias = diasHospedagem * quarto.Tipo.Valor;
            reserva.TaxasConsumo = consumoETaxas;
            reserva.ValorFinal = reserva.ValorDiarias + reserva.TaxasConsumo;
            quarto.SituacaoId = 4;

            context.SaveChanges();

            List<Cliente.Modelos.ClienteFormularioModel> hospedes = new List<Cliente.Modelos.ClienteFormularioModel>();
            string[] cpfHospedes = reserva.HospedesJson.Split('/');

            hospedes.Add(Cliente.ClienteService.BuscarClienteCompleto(cpfHospedes[0]));

            if(!String.IsNullOrEmpty(cpfHospedes[1]))
                hospedes.Add(Cliente.ClienteService.BuscarClienteCompleto(cpfHospedes[1]));

            var reservaModel = new Modelos.ReservaFinalModel
            {
                ReservaId = reserva.ReservaId,
                DataCriacao = reserva.DataCriacao,
                DataCheckIn = reserva.CheckIn.Value,
                DataCheckOut = reserva.CheckOut.Value,
                Cliente = Cliente.ClienteService.BuscarClienteCompleto(reserva.CpfReserva),
                Hospedes = hospedes,
                Quarto = Quarto.QuartoService.BuscarQuarto(reserva.QuartoId),
                ValorDiarias = reserva.ValorDiarias.Value,
                TaxasConsumo = reserva.TaxasConsumo.Value,
                ValorFinal = reserva.ValorFinal.Value
            };
            return reservaModel;

        }

        public static bool ReservaValidaOut(int reservaId)
        {
            var context = new HmsTecherContext();
            var reserva = context.Reserva.Where(a => a.ReservaId == reservaId).FirstOrDefault();
            var quarto = context.Quarto.Where(q => q.QuartoId == reserva.QuartoId).FirstOrDefault();
            

            if (reserva == null)
            {
                Console.WriteLine("\t\t Reserva não encontrada");

                Console.Write("\t\t Pressiona qualquer tecla para continuar");
                Console.ReadLine();
                return false;
            }
            if (quarto.SituacaoId != 2)
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
            var context = new HmsTecherContext();
            var reserva = context.Reserva.Where(a => a.ReservaId == reservaId).FirstOrDefault();

            if (reserva == null)
                return false;

            return true;
        }
        public static QuartoModel QuartoDaReserva(int reservaId)
        {
            var context = new HmsTecherContext();

            var quartoReserva = context.Reserva
                .Where(a => a.ReservaId == reservaId)
                .Include(q => q.Quarto)
                .Select(q => new QuartoModel
                {
                    QuartoId = q.Quarto.QuartoId,
                    Situacao = q.Quarto.Situacao,
                    Tipo = q.Quarto.Tipo
                })
                .FirstOrDefault();

            if (quartoReserva == null)
                return null;

            return quartoReserva;
        }
    }
}
