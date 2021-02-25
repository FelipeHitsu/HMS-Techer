using System;
using System.Collections.Generic;
using System.Text;

namespace HMS_Techer.Servicos.Reserva.Modelos
{
    class ReservaFormularioModelo
    {
        public int ReservaId { get; set; }
        public DateTime DataCriacao { get; set; }
        public string ClienteCpf { get; set; }
        public int QuartoNumero { get; set; }
    }
}
