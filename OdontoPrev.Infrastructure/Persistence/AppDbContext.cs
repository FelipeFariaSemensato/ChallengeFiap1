using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OdontoPrev.Domain.Entities;
using OdontoPrev.Infrastructure.Mapping;

namespace OdontoPrev.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<FotoComprovacao> FotosComprovacao { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Mensagem> Mensagens { get; set; }
        public DbSet<Dentista> Dentistas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}

