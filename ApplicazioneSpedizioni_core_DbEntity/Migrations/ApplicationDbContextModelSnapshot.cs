﻿// <auto-generated />
using System;
using ApplicazioneSpedizioni_core_DbEntity.data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApplicazioneSpedizioni_core_DbEntity.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApplicazioneSpedizioni_core_DbEntity.Models.Spedizioni", b =>
                {
                    b.Property<int>("IdSpedizione")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSpedizione"));

                    b.Property<int>("CostoSpedizione")
                        .HasPrecision(18, 2)
                        .HasColumnType("int");

                    b.Property<DateOnly>("DataConsegnaPrevista")
                        .HasColumnType("date");

                    b.Property<DateOnly>("DataSpedizione")
                        .HasColumnType("date");

                    b.Property<int?>("IdUtente")
                        .HasColumnType("int");

                    b.Property<string>("IndirizzoDestinatario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeDestinatario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumeroIdentificativo")
                        .HasColumnType("int");

                    b.Property<int>("Peso")
                        .HasColumnType("int");

                    b.Property<string>("cittaDiDestinazione")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdSpedizione");

                    b.HasIndex("IdUtente");

                    b.HasIndex("NumeroIdentificativo")
                        .IsUnique();

                    b.ToTable("Spedizioni");
                });

            modelBuilder.Entity("ApplicazioneSpedizioni_core_DbEntity.Models.StatoSpedizione", b =>
                {
                    b.Property<int>("IdStatoSpedizione")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdStatoSpedizione"));

                    b.Property<DateOnly>("DataAggiornamento")
                        .HasColumnType("date");

                    b.Property<string>("Descrizione")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdSpedizione")
                        .HasColumnType("int");

                    b.Property<string>("LuogoGiacenzaPacco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StatusSpedizione")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdStatoSpedizione");

                    b.HasIndex("IdSpedizione");

                    b.ToTable("StatoSpedizioni");
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

            modelBuilder.Entity("ApplicazioneSpedizioni_core_DbEntity.Models.Spedizioni", b =>
                {
                    b.HasOne("ApplicazioneSpedizioni_core_DbEntity.Models.Utente", "Utente")
                        .WithMany()
                        .HasForeignKey("IdUtente");

                    b.Navigation("Utente");
                });

            modelBuilder.Entity("ApplicazioneSpedizioni_core_DbEntity.Models.StatoSpedizione", b =>
                {
                    b.HasOne("ApplicazioneSpedizioni_core_DbEntity.Models.Spedizioni", "Spedizioni")
                        .WithMany()
                        .HasForeignKey("IdSpedizione")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Spedizioni");
                });
#pragma warning restore 612, 618
        }
    }
}
