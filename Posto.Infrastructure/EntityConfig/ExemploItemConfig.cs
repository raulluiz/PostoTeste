using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Posto.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Posto.Infrastructure.EntityConfig
{
    public class ExemploItemConfig : IEntityTypeConfiguration<ExemploItem>
    {
        public void Configure(EntityTypeBuilder<ExemploItem> builder)
        {
            builder.ToTable("EXEMPLOS_ITENS");
            builder.HasKey(p => p.ExemploItemId).HasName("ID");
            builder.Property(p => p.ExemploItemId).HasColumnName("ID").ValueGeneratedOnAdd();
            builder.Property(p => p.Nome).HasColumnName("NOME").HasMaxLength(200);

            builder.HasOne(c => c.Exemplo).WithMany(c => c.Itens);
        }
    }
}
