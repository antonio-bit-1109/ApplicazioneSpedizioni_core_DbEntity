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

	}

}
