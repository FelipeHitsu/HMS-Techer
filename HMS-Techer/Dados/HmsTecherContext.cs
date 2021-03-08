using HMS_Techer.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HMS_Techer.Dados
{
    public class HmsTecherContext : DbContext
    {
        public HmsTecherContext(DbContextOptions<HmsTecherContext> optionsBuilder):base(optionsBuilder)
        {

        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Quarto> Quartos { get; set; }
        public virtual DbSet<Reserva> Reservas { get; set; }
        public virtual DbSet<SituacaoQuarto> SituacaoQuartos { get; set; }
        public virtual DbSet<TipoQuarto> TipoQuartos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Dados.DadosLocais.DbDefault);
        }
    }
}

