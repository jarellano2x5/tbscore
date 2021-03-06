﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using tbscore.Data;

namespace tbscore.Migrations
{
    [DbContext(typeof(BatiaCtx))]
    [Migration("20200820195535_initial2")]
    partial class initial2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("tbscore.Models.BTDato", b =>
                {
                    b.Property<int>("BTDatoID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Contenido")
                        .HasMaxLength(3000)
                        .IsUnicode(false);

                    b.Property<DateTime>("Fecha");

                    b.Property<string>("Origen")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.HasKey("BTDatoID");

                    b.ToTable("BTDatos");
                });

            modelBuilder.Entity("tbscore.Models.BTDatoBin", b =>
                {
                    b.Property<int>("BTDatoID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Contenido");

                    b.Property<DateTime>("Fecha");

                    b.Property<string>("Origen")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.HasKey("BTDatoID");

                    b.ToTable("BTDatoBins");
                });

            modelBuilder.Entity("tbscore.Models.TGUsuario", b =>
                {
                    b.Property<int>("TGUsuarioID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .HasMaxLength(120)
                        .IsUnicode(false);

                    b.Property<string>("Contrasena")
                        .HasMaxLength(15)
                        .IsUnicode(false);

                    b.Property<string>("Correo")
                        .HasMaxLength(70)
                        .IsUnicode(false);

                    b.Property<short>("EstatusID");

                    b.Property<DateTime>("FecAlta");

                    b.Property<string>("Nombre")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("Usuario")
                        .HasMaxLength(15)
                        .IsUnicode(false);

                    b.HasKey("TGUsuarioID");

                    b.ToTable("TGUsuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
