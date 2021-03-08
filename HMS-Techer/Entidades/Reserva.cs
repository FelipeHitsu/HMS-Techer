using System;
using System.Collections.Generic;
using System.Text;

namespace HMS_Techer.Entidades
{
    public class Reserva
    {
        public int ReservaId { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        public string CpfReserva { get; set; }
        public string? HospedesJson { get; set; }
        public int QuartoId { get; set; }
        public double? ValorDiarias { get; set; }
        public double? TaxasConsumo { get; set; }
        public double? ValorFinal { get; set; }

        public virtual Cliente ClienteReserva { get; set; }
        public virtual Quarto Quarto { get; set; }

    }
}
