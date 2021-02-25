using System;
using System.Collections.Generic;
using System.Text;

namespace HMS_Techer.Servicos.Reserva
{
    class ReservaServico
    {
        public static void CriarNovaReserva(Modelos.ReservaFormularioModelo reservaFormularioModelo)
        {
            Dados.DadosLocais.Reservas.Add(new Entidades.Reserva
            {
                ReservaId = Dados.DadosLocais.Reservas.Count + 1,
                DataCriacao = DateTime.Now,
                Cliente = Cliente.ClienteServico.BuscarCliente(reservaFormularioModelo.ClienteCpf),
                Quarto = Quarto.QuartoServico.BuscarQuarto(reservaFormularioModelo.QuartoNumero)
            }) ;
        }

        public static void FazerCheckIn()
        {

        }

        /*public static void FazerCheckIn()
        {

        }*/

        public static void FazerCheckOut()
        {

        }
    }
}
