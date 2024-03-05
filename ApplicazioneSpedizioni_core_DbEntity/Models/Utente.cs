using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ApplicazioneSpedizioni_core_DbEntity.Models
{
    public class Utente
    {
        [Key]
        public int IdUtente { get; set; }

        public int? PartitaIva { get; set; }

        public string? CodiceFiscale { get; set; }

        [Required]
        public string TipoUtente { get; set; }

        public bool Attivo { get; set; } = true;

        [Remote("NameAlreadyInUse", "Utente", ErrorMessage = "Questo nome è gia utilizzato.")]
        public string? Nome { get; set; }

        public string? Password { get; set; }

    }
}
