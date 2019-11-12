using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Posto.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Posto.Infrastructure.EntityConfig
{
    public class EnderecoConfig : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Endereco");
            builder.HasKey(c => c.Id_Endereco);
            builder.Property(c => c.Id_Endereco).ValueGeneratedOnAdd();
            builder.Property(c => c.Endereco_Complemento);
            builder.Property(c => c.LinkGoogleMaps);
        }
    }
}
