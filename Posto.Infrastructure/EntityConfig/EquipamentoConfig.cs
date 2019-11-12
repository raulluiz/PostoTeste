using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Posto.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Posto.Infrastructure.EntityConfig
{
    public class EquipamentoConfig : IEntityTypeConfiguration<Equipamento>
    {
        public void Configure(EntityTypeBuilder<Equipamento> builder)
        {
            builder.ToTable("Equipamento");
            builder.HasKey(c => new { c.Id_Equipamento, c.IdEmpresa });
            builder.Property(c => c.Id_Equipamento).ValueGeneratedOnAdd();
            builder.Property(c => c.Modelo_Bomba);
            builder.Property(c => c.Tipo);
            builder.Property(c => c.Numero_Serie);
            builder.Property(c => c.IdEmpresa);
            builder.Property(c => c.Ativo);
        }
    }
}
