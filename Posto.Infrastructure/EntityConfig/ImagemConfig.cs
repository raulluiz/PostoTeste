using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Posto.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Posto.Infrastructure.EntityConfig
{
    public class ImagemConfig : IEntityTypeConfiguration<Imagem>
    {
        public void Configure(EntityTypeBuilder<Imagem> builder)
        {
            builder.ToTable("Imagem");
            builder.HasKey(c => c.Id_Imagem);
            builder.Property(c => c.Id_Imagem).ValueGeneratedOnAdd();
            builder.Property(c => c.Id_Usuario);
            builder.Property(c => c.Tipo);
            builder.Property(c => c.ImagemByte);
        }
    }
}
