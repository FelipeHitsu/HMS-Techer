using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HMS_Techer.Entidades
{
    public class Quarto
    {
        public Quarto()
        {

        }
        [Key]
        public int QuartoId { get; set; }
        //FK
        public int TipoId { get; set; }
        [ForeignKey(nameof(TipoId))]
        public TipoQuarto Tipo { get; set; }
        //FK
        public int SituacaoId { get; set; }
        [ForeignKey(nameof(SituacaoId))]
        public virtual SituacaoQuarto Situacao { get; set; }
        
    }
}
