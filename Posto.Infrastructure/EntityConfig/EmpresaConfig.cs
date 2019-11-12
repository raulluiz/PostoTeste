using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Posto.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Posto.Infrastructure.EntityConfig
{
    public class EmpresaConfig : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("Empresa");
            builder.HasKey(c => c.IdEmpresa).HasName("ID_EMPRESA");
            builder.Property(c => c.IdEmpresa).HasColumnName("ID_EMPRESA").ValueGeneratedOnAdd();
            builder.Property(c => c.Nome);
            builder.Property(c => c.CNPJ);
            builder.Property(c => c.Ativo);
            builder.Property(c => c.Razao);
        }
    }
}
