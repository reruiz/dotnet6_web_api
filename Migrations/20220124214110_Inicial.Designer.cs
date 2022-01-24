﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using dotnet6_web_api.Contexts;

#nullable disable

namespace web_api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220124214110_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("dotnet6_web_api.Models.Dato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DispositivoId")
                        .HasColumnType("int")
                        .HasColumnName("Dispositivo_Id");

                    b.Property<decimal>("HumedadRelativa")
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal>("HumedadSuelo")
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal>("RadiacionSolar")
                        .HasColumnType("decimal(6,2)");

                    b.Property<decimal>("Temperatura")
                        .HasColumnType("decimal(5,2)");

                    b.Property<DateTime>("Tiempo")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "DispositivoId" }, "IX_datos_Dispositivos_Id");

                    b.ToTable("datos", (string)null);
                });

            modelBuilder.Entity("dotnet6_web_api.Models.Dispositivo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("Modelo")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<int?>("TipoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TipoId");

                    b.ToTable("dispositivos", (string)null);
                });

            modelBuilder.Entity("dotnet6_web_api.Models.Kit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Propietario")
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("kits", (string)null);
                });

            modelBuilder.Entity("dotnet6_web_api.Models.KitDispositivo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DispositivoId")
                        .HasColumnType("int")
                        .HasColumnName("Dispositivo_Id");

                    b.Property<int>("KitId")
                        .HasColumnType("int")
                        .HasColumnName("Kit_Id");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "DispositivoId" }, "IX_kitDispositivo_Dispositivos_Id");

                    b.HasIndex(new[] { "KitId" }, "IX_kitDispositivo_Kit_Id");

                    b.ToTable("kits_dispositivos", (string)null);
                });

            modelBuilder.Entity("dotnet6_web_api.Models.Tipo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("tipos", (string)null);
                });

            modelBuilder.Entity("dotnet6_web_api.Models.Dato", b =>
                {
                    b.HasOne("dotnet6_web_api.Models.Dispositivo", "Dispositivo")
                        .WithMany("Datos")
                        .HasForeignKey("DispositivoId")
                        .IsRequired()
                        .HasConstraintName("FK_datos_Dispositivos");

                    b.Navigation("Dispositivo");
                });

            modelBuilder.Entity("dotnet6_web_api.Models.Dispositivo", b =>
                {
                    b.HasOne("dotnet6_web_api.Models.Tipo", null)
                        .WithMany("Dipositivos")
                        .HasForeignKey("TipoId");
                });

            modelBuilder.Entity("dotnet6_web_api.Models.KitDispositivo", b =>
                {
                    b.HasOne("dotnet6_web_api.Models.Dispositivo", "Dispositivo")
                        .WithMany("KitsDispositivos")
                        .HasForeignKey("DispositivoId")
                        .IsRequired()
                        .HasConstraintName("FK_kitDispositivo_Dispositivos");

                    b.HasOne("dotnet6_web_api.Models.Kit", "Kit")
                        .WithMany("KitsDispositivos")
                        .HasForeignKey("KitId")
                        .IsRequired()
                        .HasConstraintName("FK_kitDispositivo_Kit");

                    b.Navigation("Dispositivo");

                    b.Navigation("Kit");
                });

            modelBuilder.Entity("dotnet6_web_api.Models.Dispositivo", b =>
                {
                    b.Navigation("Datos");

                    b.Navigation("KitsDispositivos");
                });

            modelBuilder.Entity("dotnet6_web_api.Models.Kit", b =>
                {
                    b.Navigation("KitsDispositivos");
                });

            modelBuilder.Entity("dotnet6_web_api.Models.Tipo", b =>
                {
                    b.Navigation("Dipositivos");
                });
#pragma warning restore 612, 618
        }
    }
}
