using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HMS_Techer.Entidades
{
    public class Reserva
    {
        [Key]
        public int ReservaId { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        //FK
        public string CpfReserva { get; set; }

        [ForeignKey(nameof(CpfReserva))]
        public virtual Cliente ClienteReserva { get; set; }
        public string? HospedesJson { get; set; }
        //FK
        public int QuartoId { get; set; }
        
        [ForeignKey(nameof(QuartoId))]
        public virtual Quarto Quarto { get; set; }
        public double? ValorDiarias { get; set; }
        public double? TaxasConsumo { get; set; }
        public double? ValorFinal { get; set; }

        

    }
}
