using System;
using System.Collections.Generic;
using System.Text;

namespace HMS_Techer.Entidades
{
    class Reserva
    {
        public int ReservaId { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataCheckIn { get; set; }
        public DateTime DataCheckOut { get; set; }
        public Servicos.Cliente.Modelos.ClienteFormularioModelo Cliente { get; set; }
        public List<Entidades.Cliente> Hospedes { get; set; }
        public string HospedesJSON { get; set; }
        public Servicos.Quarto.QuartoModelo Quarto { get; set; }
        public double ValorDiarias { get; set; }
        public double TaxasConsumo { get; set; }
        public double ValorFinal { get; set; }

    }
}
