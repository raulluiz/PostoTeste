using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Posto.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Posto.Infrastructure.EntityConfig
{
    public class DistribuidoraConfig : IEntityTypeConfiguration<Distribuidora>
    {
        public void Configure(EntityTypeBuilder<Distribuidora> builder)
        {
            builder.ToTable("Distribuidora");
            builder.HasKey(c => c.Id_Distribuidora);
            builder.Property(c => c.Id_Distribuidora).ValueGeneratedOnAdd();
            builder.Property(c => c.Id_Usuario);
            builder.Property(c => c.Cpf);
            builder.Property(c => c.Email);
            builder.Property(c => c.Nome);
            builder.Property(c => c.Telefone);
        }
    }
}
