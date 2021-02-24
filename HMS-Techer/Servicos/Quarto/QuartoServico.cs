using System;
using System.Collections.Generic;
using System.Text;
using HMS_Techer.Entidades;

namespace HMS_Techer.Servicos.Quarto
{
    class QuartoServico
    {
        public QuartoServico() { }

        public void AlterarSituacao(Entidades.Quarto quarto, Entidades.SituacaoQuarto situacaoQuarto)
        {
            quarto.Situacao = situacaoQuarto;
        }

    }
}
