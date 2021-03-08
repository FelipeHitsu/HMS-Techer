using System;
using System.Collections.Generic;
using System.Text;

namespace HMS_Techer.Entidades
{
    public class SituacaoQuarto
    {
        /*
         * 1 - Desocupado / Livre
         * 2 - Ocupado
         * 3 - Reservado
         * 4 - Em Manutenção
         */
        public SituacaoQuarto()
        {

        }

        public int SituacaoQuartoId { get; set; }
        public string Descricao { get; set; }
    }
}
