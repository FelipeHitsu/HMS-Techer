using System;
using System.Collections.Generic;
using System.Text;

namespace HMS_Techer.Entidades
{
    public class Quarto
    {
        public Quarto()
        {

        }

        public int QuartoId { get; set; }
        public int TipoId { get; set; }
        public int SituacaoId { get; set; }

        public virtual SituacaoQuarto Situacao { get; set; }
        public virtual TipoQuarto Tipo { get; set; }
    }
}
