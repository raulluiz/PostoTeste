using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Posto.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Posto.Infrastructure.EntityConfig
{
    public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(c => c.Id_Usuario);
            builder.Property(c => c.Id_Usuario).ValueGeneratedOnAdd();
            builder.Property(c => c.Nome).HasMaxLength(200);
            builder.Property(c => c.Cpf).HasMaxLength(30);
            builder.Property(c => c.Ativo);
            builder.Property(c => c.Perfil);
            builder.Property(c => c.Id_Endereco).IsRequired(false);
        }
    }
}
