using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Posto.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Posto.Infrastructure.EntityConfig
{
    public class ChamadoSubConjuntoConfig : IEntityTypeConfiguration<ChamadoSubConjunto>
    {
        public void Configure(EntityTypeBuilder<ChamadoSubConjunto> builder)
        {
            builder.ToTable("ChamadoSubConjunto");
            builder.HasKey(c => new { c.Id_Chamado, c.Id_SubConjunto });
        }
    }
}