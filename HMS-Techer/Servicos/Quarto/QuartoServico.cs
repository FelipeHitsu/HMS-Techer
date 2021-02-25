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
        public static QuartoModelo BuscarQuarto(int quartoId)
        {
            Entidades.Quarto quartoBusca = DadosLocais.Quartos.Find(a => a.QuartoId == quartoId);
            QuartoModelo quartoModelo = new QuartoModelo
            {
                QuartoId = quartoBusca.QuartoId,
                Tipo = quartoBusca.Tipo,
                Situacao = quartoBusca.Situacao
            };
            return quartoModelo;
        }
        public static void MostrarQuarto(int quartoId)
        {
            QuartoModelo quartoBusca = BuscarQuarto(quartoId);
            if (quartoBusca != null)
            {
                Console.WriteLine(System.Environment.NewLine + quartoBusca);
            }
            else
                Console.WriteLine("Quarto invalido!");
        }
        public static void ListarQuartos()
        {
            List<QuartoModelo> quartosModelo = new List<QuartoModelo>();
            foreach (Entidades.Quarto quarto in DadosLocais.Quartos)
            {
                quartosModelo.Add(new QuartoModelo
                {
                    QuartoId = quarto.QuartoId,
                    Tipo = quarto.Tipo,
                    Situacao = quarto.Situacao
                });
            }

            foreach(QuartoModelo quartoModelo in quartosModelo)
                Console.WriteLine(quartoModelo);
           
        }

        public static void ListarQuartosPorSituacao(SituacaoQuarto situacao)
        {
            List<QuartoModelo> quartosModelo = new List<QuartoModelo>();
            foreach (Entidades.Quarto quarto in DadosLocais.Quartos)
            {
                if (quarto.Situacao == situacao)
                {
                    quartosModelo.Add(new QuartoModelo
                    {
                        QuartoId = quarto.QuartoId,
                        Tipo = quarto.Tipo,
                        Situacao = quarto.Situacao
                    });
                }
            }

            foreach (QuartoModelo quartoModelo in quartosModelo)
                Console.WriteLine(quartoModelo);
        }

        public static void AlterarSituacao(int quartoId, SituacaoQuarto situacaoQuarto)
        {
            DadosLocais.Quartos.Find(a => a.QuartoId == quartoId).Situacao = situacaoQuarto;
        }


    }
}
