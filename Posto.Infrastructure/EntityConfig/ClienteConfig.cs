using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Posto.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Posto.Infrastructure.EntityConfig
{
    public class ClienteConfig : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");
            builder.HasKey(c => c.Id_Cliente);
            builder.Property(c => c.Id_Cliente).ValueGeneratedOnAdd();
            builder.Property(c => c.Id_Usuario);
            builder.Property(c => c.Cnpj);
            builder.Property(c => c.Data_Preventiva_Mes);
            builder.Property(c => c.Razao_Social);
            builder.Property(c => c.Prazo_Cliente);
            builder.Property(c => c.Programacao_Preventiva);
            builder.Property(c => c.Email);
            builder.Property(c => c.PhoneNumber);
            builder.Property(c => c.Id_Tecnico);
            builder.Property(c => c.Nome);
        }
    }
}
