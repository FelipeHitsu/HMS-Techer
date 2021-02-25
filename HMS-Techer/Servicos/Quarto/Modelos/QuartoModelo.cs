using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using HMS_Techer.Entidades;

namespace HMS_Techer.Servicos.Quarto
{
    class QuartoModelo
    {
        public int QuartoId { get; set; }
        public TipoQuarto Tipo { get; set; }
        public SituacaoQuarto Situacao { get; set; }

        public override string ToString()
        {
            return System.Environment.NewLine 
                +"Numero do Quarto: "
                + QuartoId
                + System.Environment.NewLine
                + "Tipo: "
                + Tipo.Descricao
                + System.Environment.NewLine
                + "Valor: "
                + Tipo.Valor.ToString("F2",CultureInfo.InvariantCulture)
                + System.Environment.NewLine
                + "Situacao: "
                + Situacao.Descricao
                + System.Environment.NewLine;
        }
    }
}
