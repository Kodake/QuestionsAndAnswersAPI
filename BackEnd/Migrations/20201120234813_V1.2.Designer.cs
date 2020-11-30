﻿// <auto-generated />
using System;
using BackEnd.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BackEnd.Migrations
{
    [DbContext(typeof(AplicationDbContext))]
    [Migration("20201120234813_V1.2")]
    partial class V12
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BackEnd.Domain.Models.Cuestionario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Activo")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasColumnType("varchar(100)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Cuestionario");
                });

            modelBuilder.Entity("BackEnd.Domain.Models.Pregunta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CuestionarioId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CuestionarioId");

                    b.ToTable("Pregunta");
                });

            modelBuilder.Entity("BackEnd.Domain.Models.Respuesta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("EsCorrecta")
                        .HasColumnType("bit");

                    b.Property<int>("PreguntaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PreguntaId");

                    b.ToTable("Respuesta");
                });

            modelBuilder.Entity("BackEnd.Domain.Models.RespuestaCuestionario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Activo")
                        .HasColumnType("int");

                    b.Property<int>("CuestionarioId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("NombreParticipante")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CuestionarioId");

                    b.ToTable("RespuestaCuestionario");
                });

            modelBuilder.Entity("BackEnd.Domain.Models.RespuestaCuestionarioDetalle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RespuestaCuestionarioId")
                        .HasColumnType("int");

                    b.Property<int>("RespuestaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RespuestaCuestionarioId");

                    b.HasIndex("RespuestaId");

                    b.ToTable("RespuestaCuestionarioDetalles");
                });

            modelBuilder.Entity("BackEnd.Domain.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasColumnType("Varchar(20)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("Varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("BackEnd.Domain.Models.Cuestionario", b =>
                {
                    b.HasOne("BackEnd.Domain.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BackEnd.Domain.Models.Pregunta", b =>
                {
                    b.HasOne("BackEnd.Domain.Models.Cuestionario", "Cuestionario")
                        .WithMany("ListPreguntas")
                        .HasForeignKey("CuestionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BackEnd.Domain.Models.Respuesta", b =>
                {
                    b.HasOne("BackEnd.Domain.Models.Pregunta", "Pregunta")
                        .WithMany("ListRespuestas")
                        .HasForeignKey("PreguntaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BackEnd.Domain.Models.RespuestaCuestionario", b =>
                {
                    b.HasOne("BackEnd.Domain.Models.Cuestionario", "Cuestionario")
                        .WithMany()
                        .HasForeignKey("CuestionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BackEnd.Domain.Models.RespuestaCuestionarioDetalle", b =>
                {
                    b.HasOne("BackEnd.Domain.Models.RespuestaCuestionario", "RespuestaCuestionario")
                        .WithMany("ListRtaCuestionarioDetalle")
                        .HasForeignKey("RespuestaCuestionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackEnd.Domain.Models.Respuesta", "Respuesta")
                        .WithMany()
                        .HasForeignKey("RespuestaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}