using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Posto.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Posto.Infrastructure.EntityConfig
{
    public class ClienteSerieConfig : IEntityTypeConfiguration<ClienteSerie>
    {
        public void Configure(EntityTypeBuilder<ClienteSerie> builder)
        {
            builder.ToTable("ClienteSerie");
            builder.HasKey(c => new { c.Id_Cliente,c.Id_Serie});
        }
    }
}
