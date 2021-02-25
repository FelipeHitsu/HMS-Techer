using System;
using System.Collections.Generic;
using System.Text;
using HMS_Techer.Entidades;
using HMS_Techer.Dados;

namespace HMS_Techer.Servicos.Quarto
{
    class QuartoServico
    {
        public static void CriarQuarto(QuartoModelo modeloQuarto)
        {
            DadosLocais.Quartos.Add(new Entidades.Quarto
            {
                QuartoId = modeloQuarto.QuartoId,
                Tipo = modeloQuarto.Tipo,
                Situacao = new SituacaoQuarto { SituacaoId = 1,Descricao = "Livre"}
            });
        }
        private static void BuscarQuarto(int quartoId)
        {
            Entidades.Quarto quartoBusca = DadosLocais.Quartos.Find(a => a.QuartoId == quartoId);
            if (quartoBusca != null) {
                QuartoModelo quartoModelo = new QuartoModelo
                {
                    QuartoId = quartoBusca.QuartoId,
                    Tipo = quartoBusca.Tipo,
                    Situacao = quartoBusca.Situacao
                };
                Console.WriteLine(System.Environment.NewLine + quartoModelo);
            }
            else
                Console.WriteLine("Quarto invalido!");
        }
        public static void AlterarSituacao(int quartoId, SituacaoQuarto situacaoQuarto)
        {
            DadosLocais.Quartos.Find(a => a.QuartoId == quartoId).Situacao = situacaoQuarto;
        }


    }
}
