using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Posto.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Posto.Infrastructure.EntityConfig
{
    public class ChamadoImagemConfig : IEntityTypeConfiguration<ChamadoImagem>
    {
        public void Configure(EntityTypeBuilder<ChamadoImagem> builder)
        {
            builder.ToTable("ChamadoImagem");
            builder.HasKey(c => new { c.Id_Chamado, c.Id_Imagem });
        }
    }
}