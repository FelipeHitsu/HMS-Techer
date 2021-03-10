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
        private readonly HmsTecherContext _context;

        public QuartoService(HmsTecherContext context)
        {
            _context = context;
        }

        public QuartoModel BuscarQuarto(int quartoId)
        {
            var context = new HmsTecherContext();
            var quarto = context.Quarto.Where(q => q.QuartoId == quartoId)
                .Select(q => new QuartoModel
                {
                    QuartoId = q.QuartoId,
                    Tipo = q.Tipo,
                    Situacao = q.Situacao
                }).FirstOrDefault();
            return quarto;
        }
        //Situacao quarto id - de int para ENUM
        public List<QuartoModel> ListarQuartosPorSituacao(Quarto.SituacaoEnum situacao)
        {
            var context = new HmsTecherContext();
            var quartos = context.Quarto
                .AsQueryable()
                .Include(c => c.Situacao)
                .Include(c => c.Tipo)
                .Where(q => q.Situacao.SituacaoQuartoId == (int)situacao)
                .OrderBy(q => q.QuartoId)
                .Select(q => new QuartoModel {
                    QuartoId = q.QuartoId,
                    Tipo = q.Tipo,
                    Situacao = q.Situacao
                })
                .ToList();

            return quartos;
        }

        public void AlterarSituacao(int quartoId, Quarto.SituacaoEnum situacao)
        {
            var context = new HmsTecherContext();
            var quarto = context.Quarto.Where(q => q.QuartoId == quartoId).FirstOrDefault();
            quarto.SituacaoId = (int)situacao;
            context.SaveChanges();
        }

        public void ResetQuartosEmManutencao()
        {
            var context = new HmsTecherContext();
            var quartosEmManutencao = context.Quarto.Where(q => q.SituacaoId == (int)SituacaoEnum.Manutencao).ToList();
            foreach (Entidades.Quarto q in quartosEmManutencao)
                q.SituacaoId = (int)SituacaoEnum.Livre;
            context.SaveChanges();
        }
    }
}
