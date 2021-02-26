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
                Situacao = new SituacaoQuarto { SituacaoId = 1, Descricao = "Livre" }
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

            foreach (QuartoModelo quartoModelo in quartosModelo)
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

        public static SituacaoQuarto ParseSituacao(int id)
        {
            string descricao = "";

            if (id == 1)
                descricao = "Livre";

            if (id == 2)
                descricao = "Ocupado";

            if (id == 3)
                descricao = "Reservado";

            if(id == 4)
                descricao = "Em Manutenção";

            return new SituacaoQuarto { SituacaoId = id, Descricao = descricao };
        }

        public static TipoQuarto ParseTipoQuarto(int id)
        {
            string descricao = "";
            double valor = 0;

            if(id == 1)
            {
                descricao = "Solteiro";
                valor = 150;
            }

            if (id == 2)
            {
                descricao = "Duplo";
                valor = 200;
            }

            if(id == 3)
            {
                descricao = "Casal";
                valor = 250;
            }

            return new TipoQuarto { TipoId = id, Descricao = descricao, Valor = valor };
        }

        public static void AlterarSituacao(int quartoId, SituacaoQuarto situacaoQuarto)
        {
            DadosLocais.Quartos.Find(a => a.QuartoId == quartoId).Situacao = situacaoQuarto;
        }

        public static void PrimeiraInstanciaQuartos()
        {
            //Instancia inicial dos quartos solteiro
            for (int i = 1; i <= 20; i++)
            {
                DadosLocais.Quartos.Add(new Entidades.Quarto
                {
                    QuartoId = i,
                    Situacao = new SituacaoQuarto
                    {
                        SituacaoId = 1,
                        Descricao = "Livre"
                    },
                    Tipo = new TipoQuarto
                    {
                        TipoId = 1,
                        Descricao = "Solteiro",
                        Valor = 150
                    }
                });
            }

            //Instancia incial quartos duplos
            for (int i = 21; i <= 30; i++)
            {
                DadosLocais.Quartos.Add(new Entidades.Quarto
                {
                    QuartoId = i,
                    Situacao = new SituacaoQuarto
                    {
                        SituacaoId = 1,
                        Descricao = "Livre"
                    },
                    Tipo = new TipoQuarto
                    {
                        TipoId = 2,
                        Descricao = "Duplo",
                        Valor = 200
                    }
                });
            }

            //Instancia incial quartos Casal
            for (int i = 31; i <= 50; i++)
            {
                DadosLocais.Quartos.Add(new Entidades.Quarto
                {
                    QuartoId = i,
                    Situacao = new SituacaoQuarto
                    {
                        SituacaoId = 1,
                        Descricao = "Livre"
                    },
                    Tipo = new TipoQuarto
                    {
                        TipoId = 3,
                        Descricao = "Casal",
                        Valor = 250
                    }
                });
            }
        }

    }
}
