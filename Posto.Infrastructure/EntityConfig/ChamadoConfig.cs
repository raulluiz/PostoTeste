using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Posto.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Posto.Infrastructure.EntityConfig
{
    public class ChamadoConfig : IEntityTypeConfiguration<Chamado>
    {
        public void Configure(EntityTypeBuilder<Chamado> builder)
        {
            builder.ToTable("Chamado");
            builder.HasKey(c => c.Id_Chamado);
            builder.Property(c => c.Id_Chamado).ValueGeneratedOnAdd();
            builder.Property(c => c.Id_Cliente);
            builder.Property(c => c.Id_Tecnico);
            builder.Property(c => c.Id_Empresa);
            builder.Property(c => c.Id_Serie);
            builder.Property(c => c.Data_Inicial);
            builder.Property(c => c.Data_Prazo);
            builder.Property(c => c.Data_Final);
            builder.Property(c => c.Descricao_Problema_Cliente);
            builder.Property(c => c.Defeito_Encontrado_Tecnico);
            builder.Property(c => c.Nota_Tempo);
            builder.Property(c => c.Nota_Tecnico);
            builder.Property(c => c.Nota_Eficacia);
            builder.Property(c => c.Status);
            builder.Property(c => c.Nome_Cliente);
            builder.Property(c => c.Nome_Tecnico);
            builder.Property(c => c.Corretiva);
        }
    }
}