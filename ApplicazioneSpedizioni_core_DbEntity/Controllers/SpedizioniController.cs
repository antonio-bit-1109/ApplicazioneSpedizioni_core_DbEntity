using ApplicazioneSpedizioni_core_DbEntity.data;
using ApplicazioneSpedizioni_core_DbEntity.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace ApplicazioneSpedizioni_core_DbEntity.Controllers
{
    public class SpedizioniController : Controller
    {

        private readonly ApplicationDbContext _db;
        private readonly IAuthenticationSchemeProvider _schemeProvider;
        public SpedizioniController(ApplicationDbContext db, IAuthenticationSchemeProvider schemeProvider)
        {
            _db = db;
            _schemeProvider = schemeProvider;
        }
        public IActionResult Index()
        {
            var TutteLeSpedizioni = _db.Spedizioni.ToList();

            return View(TutteLeSpedizioni);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Spedizioni spedizione)
        {
            if (ModelState.IsValid)
            {
                _db.Spedizioni.Add(spedizione);
                _db.SaveChanges();
                TempData["Message"] = "Spedizione Inserita con successo.";
                return RedirectToAction("Index");
            }
            TempData["Errore"] = "Errore nella creazione della spedizione.";
            return RedirectToAction("Index");
        }

        //public JsonResult NumIdentificativoUsed(int numIdentificativo)
        //{
        //    var controlloIdentificativo = _db.Spedizioni.FirstOrDefault(spedizioni => spedizioni.NumeroIdentificativo == numIdentificativo);

        //    // se il risulato è true significa che il numero identificativo è gia stato usato


        //}
    }
}
