﻿// <auto-generated />
using System;
using ApplicazioneSpedizioni_core_DbEntity.data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApplicazioneSpedizioni_core_DbEntity.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240305180018_AddTabellaUtentiLogin")]
    partial class AddTabellaUtentiLogin
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApplicazioneSpedizioni_core_DbEntity.Models.Login", b =>
                {
                    b.Property<int>("IdUtente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUtente"));

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUtente");

                    b.ToTable("UtentiCredenzialiAccesso");
                });

            modelBuilder.Entity("ApplicazioneSpedizioni_core_DbEntity.Models.Utente", b =>
                {
                    b.Property<int>("IdUtente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUtente"));

                    b.Property<bool>("Attivo")
                        .HasColumnType("bit");

                    b.Property<string>("CodiceFiscale")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PartitaIva")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoUtente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUtente");

                    b.ToTable("Utenti");
                });
#pragma warning restore 612, 618
        }
    }
}
