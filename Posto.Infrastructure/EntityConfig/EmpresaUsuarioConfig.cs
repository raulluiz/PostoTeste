using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Posto.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Posto.Infrastructure.EntityConfig
{
    public class EmpresaUsuarioConfig : IEntityTypeConfiguration<EmpresaUsuario>
    {
        public void Configure(EntityTypeBuilder<EmpresaUsuario> builder)
        {
            builder.ToTable("EmpresaUsuario");
            builder.HasKey(c => new { c.IdEmpresa,c.Id_Usuario});
        }
    }
}
