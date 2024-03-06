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

        public IActionResult Edit(int id)
        {
            var spedizioneDaMOdificare = _db.Spedizioni.Find(id);

            if (spedizioneDaMOdificare != null)
            {
                spedizioneDaMOdificare.CurrentAction = "Edit";
            }

            return View(spedizioneDaMOdificare);
        }

        [HttpPost]
        public IActionResult Edit(Spedizioni spedizione)
        {

            try
            {
                _db.Spedizioni.Update(spedizione);
                _db.SaveChanges();
                TempData["Message"] = "Spedizione modificata con successo.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Errore"] = $"Errore nella modifica della spedizione: problema {ex}";
                return RedirectToAction("Index");
            }
        }


        public IActionResult Details(int id)
        {
            var spedizione = _db.Spedizioni.Find(id);
            return View(spedizione);
        }



        public IActionResult Delete(int id)
        {
            var spedizione = _db.Spedizioni.Find(id);
            return View(spedizione);
        }



        [HttpPost]
        public IActionResult Delete(Spedizioni spedizione)
        {
            if (spedizione != null)
            {
                _db.Spedizioni.Remove(spedizione);
                _db.SaveChanges();
                TempData["Message"] = "Spedizione eliminata con successo.";
                return RedirectToAction("Index");
            }

            TempData["Errore"] = "Errore nell'eliminazione della spedizione.";
            return RedirectToAction("Index");
        }

        public JsonResult NumIdentificativoUsed(int NumeroIdentificativo, string CurrentAction)
        {
            if (CurrentAction != null)
            {
                if (CurrentAction == "Edit")
                {
                    // Non eseguire la validazione per questa azione
                    return Json(true);
                }
            }

            var numIdentificativoUsed = _db.Spedizioni.FirstOrDefault(table => table.NumeroIdentificativo == NumeroIdentificativo);

            if (numIdentificativoUsed != null)
            {
                // Restituisci false se il NumeroIdentificativo è già in uso
                return Json(false);
            }
            else
            {
                return Json(true);
            }
            // Restituisci true se il NumeroIdentificativo non è in uso
        }


    }
}
