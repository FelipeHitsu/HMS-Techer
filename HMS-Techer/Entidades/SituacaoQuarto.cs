using System;
using System.Collections.Generic;
using System.Text;

namespace HMS_Techer.Entidades
{
    class SituacaoQuarto
    {
        /*
         * 1 - Desocupado / Livre
         * 2 - Ocupado
         * 3 - Reservado
         * 4 - Em Manutenção
         */
        public int SituacaoId { get; set; }
        public string Descricao { get; set; }
    }
}
