using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicazioneSpedizioni_core_DbEntity.Models
{
    public class Spedizioni
    {
        [Key]
        public int IdSpedizione { get; set; }

        [Required]
        [Remote("NumIdentificativoUsed", "Spedizioni", AdditionalFields = "CurrentAction ", ErrorMessage = "Questo Numero Identificativo  è già in uso.")]
        // è impostato come unico In ApplicationDbContext
        public int NumeroIdentificativo { get; set; }

        [Required]
        public DateOnly DataSpedizione { get; set; }

        [Required]
        public int Peso { get; set; }

        [Required]
        public string cittaDiDestinazione { get; set; }

        [Required]
        public string IndirizzoDestinatario { get; set; }

        [Required]
        public string NomeDestinatario { get; set; }

        [Required]
        public int CostoSpedizione { get; set; }

        [Required]
        public DateOnly DataConsegnaPrevista { get; set; }

        [NotMapped]
        public string CurrentAction { get; set; }

        //chiave esterna//
        public int? IdUtente { get; set; }


        //proprietà di navigazione
        public Utente Utente { get; set; }
    }

}




