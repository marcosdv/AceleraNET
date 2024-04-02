﻿// <auto-generated />
using System;
using CursoAtos.Repository.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CursoAtos.Repository.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240402224414_AddCampoTeste")]
    partial class AddCampoTeste
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CursoAtos.Domain.Entities.Noticia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("NotCodigo");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Teste")
                        .HasColumnType("varchar")
                        .HasColumnName("NotTeste");

                    b.Property<string>("Texto")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("NotTexto");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("NotTitulo");

                    b.Property<DateTime>("UltimaAtualizacao")
                        .HasColumnType("datetime")
                        .HasColumnName("NotUltimaAtualizacao");

                    b.HasKey("Id");

                    b.ToTable("TbNoticia", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
