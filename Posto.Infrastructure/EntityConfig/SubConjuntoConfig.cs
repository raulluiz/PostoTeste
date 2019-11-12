using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Posto.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Posto.Infrastructure.EntityConfig
{
    public class SubConjuntoConfig : IEntityTypeConfiguration<SubConjunto>
    {
        public void Configure(EntityTypeBuilder<SubConjunto> builder)
        {
            builder.ToTable("SubConjunto");
            builder.HasKey(c => c.Id_SubConjunto);
            builder.Property(c => c.Id_SubConjunto).ValueGeneratedOnAdd();
            builder.Property(c => c.Nome);
        }
    }
}
