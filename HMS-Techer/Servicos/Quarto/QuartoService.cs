using System;
using System.Collections.Generic;
using System.Text;
using HMS_Techer.Entidades;
using HMS_Techer.Dados;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HMS_Techer.Servicos.Quarto
{
    class QuartoService
    {
        public static QuartoModelo BuscarQuarto(int quartoId)
        {
            var context = new HmsTecherContext();
            Entidades.Quarto quartoBusca = context.Quarto.ToList().Find(q => q.QuartoId == quartoId);
            QuartoModelo quartoModelo = new QuartoModelo
            {
                QuartoId = quartoBusca.QuartoId,
                Tipo = quartoBusca.Tipo,
                Situacao = quartoBusca.Situacao
            };
            return quartoModelo;
        }

        public static List<QuartoModelo> ListarQuartosPorSituacao(int situacaoId)
        {
            var context = new HmsTecherContext();
            var quartos = context.Quarto
                .AsQueryable()
                .Include(c => c.Situacao)
                .Include(c => c.Tipo)
                .Where(q => q.Situacao.SituacaoQuartoId == situacaoId)
                .OrderBy(q => q.QuartoId)
                .Select(q => new QuartoModelo {
                    QuartoId = q.QuartoId,
                    Tipo = q.Tipo,
                    Situacao = q.Situacao
                })
                .ToList();

            return quartos;
        }

        /*public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }*/

        public static void AlterarSituacao(int quartoId, SituacaoQuarto situacaoQuarto)
        {
            DadosLocais.Quartos.Find(a => a.QuartoId == quartoId).Situacao = situacaoQuarto;
        }

    }
}
