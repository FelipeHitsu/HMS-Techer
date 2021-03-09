﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using HMS_Techer.Entidades;

namespace HMS_Techer.Servicos.Quarto
{
    public class QuartoModel
    {
        public int QuartoId { get; set; }

        //Substituir a entidade por referencia ou por uma model
        public TipoQuarto Tipo { get; set; }
        public SituacaoQuarto Situacao { get; set; }

        public override string ToString()
        {
            return System.Environment.NewLine 
                + "\t\t     Numero do Quarto: "
                + QuartoId
                + System.Environment.NewLine
                + "\t\t     Tipo: "
                + Tipo.Descricao
                + System.Environment.NewLine
                + "\t\t     Valor: "
                + Tipo.Valor.ToString("F2",CultureInfo.InvariantCulture)
                + System.Environment.NewLine
                + "\t\t     Situacao: "
                + Situacao.Descricao
                + System.Environment.NewLine;
        }
    }
}
