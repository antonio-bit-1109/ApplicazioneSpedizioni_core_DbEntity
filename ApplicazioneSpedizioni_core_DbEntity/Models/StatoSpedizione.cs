using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicazioneSpedizioni_core_DbEntity.Models
{
    public class StatoSpedizione
    {
        [Key]
        public int IdStatoSpedizione { get; set; }

        [Required]
        public string StatusSpedizione { get; set; }

        [Required]
        public string LuogoGiacenzaPacco { get; set; }

        public string? Descrizione { get; set; }

        [Required]
        public DateOnly DataAggiornamento { get; set; }

        [ForeignKey("Spedizioni")]
        //chiave esterna
        public int? IdSpedizione { get; set; }

        // proprietà di navigazione necessaria
        // per scrivere la relazione uno a molti nel modelBuilder
        public Spedizioni Spedizioni { get; set; }

    }
}
