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
    public class TarefaMap : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Descricao).IsRequired().HasMaxLength(200);
            builder.Property(t => t.Pontos).IsRequired();
            builder.Property(t => t.Concluida).HasDefaultValue(false);

            builder.HasMany(t => t.FotosComprovacao)
                   .WithOne(f => f.Tarefa)
                   .HasForeignKey(f => f.TarefaId);
        }
    }
}

