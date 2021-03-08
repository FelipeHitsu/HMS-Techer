using System;
using System.Collections.Generic;
using System.Text;

namespace HMS_Techer.Entidades
{
    public class TipoQuarto
    {
        /*
         * 1 - Solteiro - R$ 150.00
         * 2 - Duplo - R$ 200.00
         * 3 - Casal - R$ 250.00
         */
        public TipoQuarto()
        {

        }

        public int TipoQuartoId { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }

    }
}
