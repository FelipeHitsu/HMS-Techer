using System;
using System.Collections.Generic;
using System.Globalization;
using HMS_Techer.Entidades;
using System.Text;

namespace HMS_Techer.Servicos.Reserva.Modelos
{
    class ReservaFinalModel
    {
        public int ReservaId { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataCheckIn { get; set; }
        public DateTime DataCheckOut { get; set; }
        public Servicos.Cliente.Modelos.ClienteFormularioModel Cliente { get; set; }
        public List<Entidades.Cliente> Hospedes { get; set; }
        public string HospedesJSON { get; set; }
        public Servicos.Quarto.QuartoModel Quarto { get; set; }
        public double ValorDiarias { get; set; }
        public double TaxasConsumo { get; set; }
        public double ValorFinal { get; set; }

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

            sb.AppendLine("\t\t     Hospedes: ");
            
            foreach(Entidades.Cliente cliente in Hospedes)
            {
                sb.AppendLine(Servicos.Cliente.ClienteService.BuscarCliente(cliente.Cpf).ToString());
            }

            sb.Append("\t\t     Check in Realizado em: ");
            sb.AppendLine(DataCheckIn.ToString("f"));

            sb.Append("\t\t     Check out Realizado em: ");
            sb.AppendLine(DataCheckOut.ToString("f"));

            sb.Append("\t\t     Quantidade de Diarias: ");
            sb.AppendLine(((DataCheckOut - DataCheckIn).Days).ToString());

            sb.Append("\t\t     Valor das Diarias: ");
            sb.AppendLine(ValorDiarias.ToString("F2", CultureInfo.InvariantCulture));

            sb.Append("\t\t     Valor de taxas e consumo: ");
            sb.AppendLine(TaxasConsumo.ToString("F2", CultureInfo.InvariantCulture));

            sb.Append("\t\t     Valor Total da Hospedagem: ");
            sb.AppendLine(ValorFinal.ToString("F2", CultureInfo.InvariantCulture));

            return sb.ToString();
        }
    }
}
