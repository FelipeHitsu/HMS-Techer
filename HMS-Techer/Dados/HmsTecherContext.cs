using HMS_Techer.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HMS_Techer.Dados
{
    public class HmsTecherContext : DbContext
    {
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Quarto> Quarto { get; set; }
        public virtual DbSet<Reserva> Reserva { get; set; }
        public virtual DbSet<SituacaoQuarto> SituacaoQuarto { get; set; }
        public virtual DbSet<TipoQuarto> TipoQuarto { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Dados.DadosLocais.DbDefault);
        }
    }
}

