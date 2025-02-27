﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CadastroProtocolo.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250227135317_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCliente"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCliente");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Protocolo", b =>
                {
                    b.Property<int>("IdProtocolo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProtocolo"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataAbertura")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataFechamento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProtocoloStatusId")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdProtocolo");

                    b.HasIndex("ClienteId");

                    b.HasIndex("ProtocoloStatusId");

                    b.ToTable("Protocolos");
                });

            modelBuilder.Entity("ProtocoloFollow", b =>
                {
                    b.Property<int>("IdFollow")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdFollow"));

                    b.Property<DateTime>("DataAcao")
                        .HasColumnType("datetime2");

                    b.Property<string>("DescricaoAcao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProtocoloId")
                        .HasColumnType("int");

                    b.HasKey("IdFollow");

                    b.HasIndex("ProtocoloId");

                    b.ToTable("ProtocoloFollows");
                });

            modelBuilder.Entity("StatusProtocolo", b =>
                {
                    b.Property<int>("IdStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdStatus"));

                    b.Property<string>("NomeStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdStatus");

                    b.ToTable("StatusProtocolos");
                });

            modelBuilder.Entity("Protocolo", b =>
                {
                    b.HasOne("Cliente", "Cliente")
                        .WithMany("Protocolos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StatusProtocolo", "ProtocoloStatus")
                        .WithMany()
                        .HasForeignKey("ProtocoloStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("ProtocoloStatus");
                });

            modelBuilder.Entity("ProtocoloFollow", b =>
                {
                    b.HasOne("Protocolo", "Protocolo")
                        .WithMany("Follows")
                        .HasForeignKey("ProtocoloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Protocolo");
                });

            modelBuilder.Entity("Cliente", b =>
                {
                    b.Navigation("Protocolos");
                });

            modelBuilder.Entity("Protocolo", b =>
                {
                    b.Navigation("Follows");
                });
#pragma warning restore 612, 618
        }
    }
}
