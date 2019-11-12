using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Posto.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Posto.Infrastructure.EntityConfig
{
    public class TecnicoConfig : IEntityTypeConfiguration<Tecnico>
    {
        public void Configure(EntityTypeBuilder<Tecnico> builder)
        {
            builder.ToTable("Tecnico");
            builder.HasKey(c => c.Id_Tecnico);
            builder.Property(c => c.Id_Tecnico).ValueGeneratedOnAdd();
            builder.Property(c => c.Id_Usuario);
            builder.Property(c => c.Cpf);
            builder.Property(c => c.Programacao_Preventiva);
            builder.Property(c => c.Id_Empresa);
            builder.Property(c => c.Nome);
        }
    }
}
