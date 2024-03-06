using ApplicazioneSpedizioni_core_DbEntity.Models;
using Microsoft.EntityFrameworkCore;

namespace ApplicazioneSpedizioni_core_DbEntity.data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        //public DbSet<Spedizione> Spedizioni { get; set; }

        // qui inserisco le tabelle (BASATE SUI MODELLI ) che voglio creare nel database

        public DbSet<Utente> Utenti { get; set; }


        // in questo modo sto settando il campo numeroIdentificativo come unico
        public DbSet<Spedizioni> Spedizioni { get; set; }

        public DbSet<StatoSpedizione> StatoSpedizioni { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Spedizioni>()
                .HasIndex(u => u.NumeroIdentificativo)
                .IsUnique();

            modelBuilder.Entity<Spedizioni>()
                  .Property(b => b.CostoSpedizione)
                  .HasPrecision(18, 2); // Specifica la precisione e la scala

            // sto definendo delle configurazioni per la tabella spedizioni 
            // in particolare sto dicendo che la chiave esterna IdUtente, della tabella spedizioni,
            // è collegata alla chiave primaria IdUtente della tabella utenti
            modelBuilder.Entity<Spedizioni>()
                .HasOne(p => p.Utente)
                .WithMany()
                .HasForeignKey(p => p.IdUtente);



            //modelBuilder.Entity<StatoSpedizione>()
            // .HasOne(s => s.Spedizioni) // StatoSpedizione ha una Spedizione
            // .WithMany() // Una Spedizione può avere molti StatoSpedizione
            // .HasForeignKey(s => s.IdSpedizione); // La chiave esterna è IdSpedizione


        }

    }

}
