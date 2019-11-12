using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Posto.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Posto.Infrastructure.EntityConfig
{
    public class ChamadoProdutoConfig : IEntityTypeConfiguration<ChamadoProduto>
    {
        public void Configure(EntityTypeBuilder<ChamadoProduto> builder)
        {
            builder.ToTable("ChamadoProduto");
            builder.HasKey(c => new { c.Id_Chamado, c.Id_Produto });
        }
    }
}