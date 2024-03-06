using ApplicazioneSpedizioni_core_DbEntity.data;
using ApplicazioneSpedizioni_core_DbEntity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApplicazioneSpedizioni_core_DbEntity.Controllers
{
    public class UtenteController : Controller
    {


        private readonly ApplicationDbContext _db;
        public UtenteController(ApplicationDbContext db)
        {
            _db = db;
        }
        // GET: UtenteController
        public ActionResult Index()
        {
            var ListaUtentiAttivi = _db.Utenti.Where(u => u.Attivo == true);
            return View(ListaUtentiAttivi);
        }


        // GET: UtenteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UtenteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Utente utente)
        {
            utente.Attivo = true;

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Utenti.Add(utente);
                    _db.SaveChanges();
                    TempData["Message"] = "Utente creato con successo.";
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }

            TempData["Error"] = "Errore nella creazione dell'utente.";
            return RedirectToAction("Index");
        }

        // GET: UtenteController/Edit/5
        public ActionResult Edit(int id)
        {
            if (id > 0 && id != 0)
            {
                var UtenteDaModificare = _db.Utenti.Find(id);
                return View(UtenteDaModificare);

            }
            return NotFound();
        }

        // POST: UtenteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ModificaUtente(Utente utente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.Entry(utente).State = EntityState.Modified;
                    _db.SaveChanges();
                    TempData["Message"] = "Utente modificato con successo.";
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                TempData["Error"] = "Errore nella modifica dell'utente.";
            }
            return RedirectToAction("Index");
        }


        //[ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                var utente = _db.Utenti.Find(id);
                if (utente == null)
                {
                    return NotFound();
                }

                // Set the 'Attivo' field to false instead of removing the user
                utente.Attivo = false;
                _db.Entry(utente).State = EntityState.Modified;
                _db.SaveChanges();

                TempData["Message"] = "Utente disattivato con successo.";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["Error"] = "Errore nella disattivazione dell'utente.";
                return RedirectToAction("Index");
            }
        }


        // RISCRIVI IL REMOTE PER VERIFICARE SE IL NOME UTENTE E' GIA' UTILIZZATO

        public JsonResult NameAlreadyInUse(string nome)
        {
            var utente = _db.Utenti.FirstOrDefault(u => u.Nome == nome);

            if (utente != null)
            {
                // Il nome è già in uso
                return Json(false);
            }
            else
            {
                // Il nome non è in uso
                return Json(true);
            }

        }
    }
}
