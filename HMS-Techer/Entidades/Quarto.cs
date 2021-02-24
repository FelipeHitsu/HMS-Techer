using System;
using System.Collections.Generic;
using System.Text;

namespace HMS_Techer.Entidades
{
    class Quarto
    {
        public int QuartoId { get; set; }
        public TipoQuarto Tipo { get; set; }
        public SituacaoQuarto Situacao { get; set; }
    }
}
