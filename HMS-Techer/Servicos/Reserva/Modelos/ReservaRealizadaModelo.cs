using System;
using System.Collections.Generic;
using System.Text;

namespace HMS_Techer.Servicos.Reserva.Modelos
{
    class ReservaRealizadaModelo
    {
        public int ReservaId { get; set; }
        public DateTime DataCriacao { get; set; }
        public Servicos.Cliente.Modelos.ClienteFormularioModelo Cliente { get; set; }
        public Servicos.Quarto.QuartoModelo Quarto { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\t\t     Numero da Reserva: ");
            sb.AppendLine(ReservaId.ToString());

            sb.Append("\t\t     Reserva Realizada em: ");
            sb.AppendLine(DataCriacao.ToString("f"));

            sb.AppendLine("\t\t     Cliente: ");
            sb.AppendLine(Cliente.ToString());

            sb.Append("\t\t     Quarto: ");
            sb.AppendLine(Quarto.ToString());

            return sb.ToString();
        }
    }
}
