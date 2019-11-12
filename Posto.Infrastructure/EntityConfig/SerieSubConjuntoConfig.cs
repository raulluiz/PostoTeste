using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Posto.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Posto.Infrastructure.EntityConfig
{
    public class SerieSubConjuntoConfig : IEntityTypeConfiguration<SerieSubConjunto>
    {
        public void Configure(EntityTypeBuilder<SerieSubConjunto> builder)
        {
            builder.ToTable("SerieSubConjunto");
            builder.HasKey(c => new { c.Id_SubConjunto, c.Id_Serie });
        }
    }
}
