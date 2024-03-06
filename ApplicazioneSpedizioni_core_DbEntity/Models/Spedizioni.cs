using System.ComponentModel.DataAnnotations;

namespace ApplicazioneSpedizioni_core_DbEntity.Models
{
    public class Spedizioni
    {
        [Key]
        public int IdSpedizione { get; set; }

        [Required]
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
        public decimal CostoSpedizione { get; set; }

        [Required]
        public DateOnly DataConsegnaPrevista { get; set; }
    }
}




