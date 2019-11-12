﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Posto.Infrastructure.Context;

namespace Posto.Infrastructure.Migrations
{
    [DbContext(typeof(PostoContext))]
    [Migration("20190907134117_Programacao_PreventivaTecnico")]
    partial class Programacao_PreventivaTecnico
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Posto.ApplicationCore.Entities.Cliente", b =>
                {
                    b.Property<int>("Id_Cliente")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("Cnpj");

                    b.Property<DateTime>("Data_Preventiva_Mes");

                    b.Property<string>("Email");

                    b.Property<int>("Id_Tecnico");

                    b.Property<int>("Id_Usuario");

                    b.Property<string>("PhoneNumber");

                    b.Property<DateTime>("Prazo_Cliente");

                    b.Property<int>("Programacao_Preventiva");

                    b.Property<string>("Razao_Social");

                    b.HasKey("Id_Cliente");

                    b.HasIndex("Id_Usuario");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("Posto.ApplicationCore.Entities.Empresa", b =>
                {
                    b.Property<int>("IdEmpresa")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_EMPRESA")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo");

                    b.Property<long>("CNPJ");

                    b.Property<string>("Nome")
                        .HasColumnName("NOME")
                        .HasMaxLength(200);

                    b.HasKey("IdEmpresa")
                        .HasName("ID_EMPRESA");

                    b.ToTable("EMPRESAS");
                });

            modelBuilder.Entity("Posto.ApplicationCore.Entities.EmpresaUsuario", b =>
                {
                    b.Property<int>("IdEmpresa");

                    b.Property<int>("Id_Usuario");

                    b.HasKey("IdEmpresa", "Id_Usuario");

                    b.HasIndex("Id_Usuario");

                    b.ToTable("EmpresaUsuario");
                });

            modelBuilder.Entity("Posto.ApplicationCore.Entities.Endereco", b =>
                {
                    b.Property<int>("Id_Endereco")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Endereco_Complemento");

                    b.Property<string>("LinkGoogleMaps");

                    b.HasKey("Id_Endereco");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("Posto.ApplicationCore.Entities.Exemplo", b =>
                {
                    b.Property<int>("ExemploId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_EXEMPLO")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataCadastro");

                    b.Property<string>("Nome")
                        .HasColumnName("NOME")
                        .HasMaxLength(200);

                    b.HasKey("ExemploId")
                        .HasName("ID_EXEMPLO");

                    b.ToTable("EXEMPLOS");
                });

            modelBuilder.Entity("Posto.ApplicationCore.Entities.ExemploItem", b =>
                {
                    b.Property<int>("ExemploItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ExemploId");

                    b.Property<string>("Nome")
                        .HasColumnName("NOME")
                        .HasMaxLength(200);

                    b.HasKey("ExemploItemId")
                        .HasName("ID");

                    b.HasIndex("ExemploId");

                    b.ToTable("EXEMPLOS_ITENS");
                });

            modelBuilder.Entity("Posto.ApplicationCore.Entities.Tecnico", b =>
                {
                    b.Property<int>("Id_Tecnico")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("Cpf");

                    b.Property<int>("Id_Usuario");

                    b.Property<DateTime>("Programacao_Preventiva");

                    b.HasKey("Id_Tecnico");

                    b.HasIndex("Id_Usuario");

                    b.ToTable("Tecnico");
                });

            modelBuilder.Entity("Posto.ApplicationCore.Entities.Usuario", b =>
                {
                    b.Property<int>("Id_Usuario")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo");

                    b.Property<string>("Cpf")
                        .HasMaxLength(30);

                    b.Property<int?>("Id_Endereco");

                    b.Property<string>("IdentityUser");

                    b.Property<string>("Nome")
                        .HasMaxLength(200);

                    b.Property<byte>("Perfil");

                    b.HasKey("Id_Usuario");

                    b.HasIndex("Id_Endereco");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Posto.ApplicationCore.Entities.Cliente", b =>
                {
                    b.HasOne("Posto.ApplicationCore.Entities.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("Id_Usuario")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Posto.ApplicationCore.Entities.EmpresaUsuario", b =>
                {
                    b.HasOne("Posto.ApplicationCore.Entities.Empresa", "Empresa")
                        .WithMany("EmpresaUsuarios")
                        .HasForeignKey("IdEmpresa")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Posto.ApplicationCore.Entities.Usuario", "Usuario")
                        .WithMany("EmpresaUsuarios")
                        .HasForeignKey("Id_Usuario")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Posto.ApplicationCore.Entities.ExemploItem", b =>
                {
                    b.HasOne("Posto.ApplicationCore.Entities.Exemplo", "Exemplo")
                        .WithMany("Itens")
                        .HasForeignKey("ExemploId");
                });

            modelBuilder.Entity("Posto.ApplicationCore.Entities.Tecnico", b =>
                {
                    b.HasOne("Posto.ApplicationCore.Entities.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("Id_Usuario")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Posto.ApplicationCore.Entities.Usuario", b =>
                {
                    b.HasOne("Posto.ApplicationCore.Entities.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("Id_Endereco");
                });
#pragma warning restore 612, 618
        }
    }
}
