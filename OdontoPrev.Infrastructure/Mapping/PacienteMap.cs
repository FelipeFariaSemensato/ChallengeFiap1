using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OdontoPrev.Domain.Entities;

namespace OdontoPrev.Infrastructure.Mapping
{
    public class PacienteMap : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Email).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Pontos).HasDefaultValue(0);
            builder.Property(p => p.NivelRecompensa).HasDefaultValue(NivelRecompensa.Bronze);

            builder.HasMany(p => p.Tarefas)
                   .WithMany(); // Configuração simplificada

            builder.HasMany(p => p.Feedbacks)
                   .WithOne(f => f.Paciente)
                   .HasForeignKey(f => f.PacienteId);

            builder.HasMany(p => p.Mensagens)
                   .WithOne(m => m.Paciente)
                   .HasForeignKey(m => m.PacienteId);
        }
    }
}

