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
            var UserId = User.Claims.FirstOrDefault(c => c.Type == "Id")?.Value;

            int idUtenteClaim = Convert.ToInt32(UserId);
            var spedizioniUtente = _db.Spedizioni.Where(t => t.IdUtente == idUtenteClaim).ToList();


            // var TutteLeSpedizioniDellUtente = _db.Spedizioni.Where().ToList();

            return View(spedizioniUtente);
        }

        public IActionResult Create()
        {
            //var IdUtenti = _db.Utenti.Where(t => t.Attivo == true).Select(table => table.IdUtente).ToList();
            var IdUtenti = _db.Utenti.Where(table => table.Attivo == true).Select(table => table.IdUtente).ToList();


            //var IdUtenti = _db.Utenti.FromSqlRaw("SELECT IdUtente FROM Utenti WHERE Attivo= 1").ToList();
            //var IdUtenti = _db.Utenti.Where(table => table.Attivo == true).Select(table => table.IdUtente).ToList();

            if (IdUtenti.Count == 0)
            {
                TempData["Errore"] = "Non ci sono utenti nel database. Inserire almeno un utente prima di creare una spedizione.";
                return RedirectToAction("Index");
            }


            ViewBag.ListaIDUtenti = IdUtenti;
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind(include: "Peso,IdUtente,CurrentAction,DataSpedizione,CostoSpedizione" +
            ",NomeDestinatario,cittaDiDestinazione,DataConsegnaPrevista,NumeroIdentificativo,IndirizzoDestinatario")] Spedizioni spedizione)
        {
            try
            {
                _db.Spedizioni.Add(spedizione);
                _db.SaveChanges();
                TempData["Message"] = "Spedizione Inserita con successo.";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["Errore"] = "Errore nella creazione della spedizione.";
                return RedirectToAction("Index");

            }

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


        public IActionResult AggiornaSpedizione(int id)
        {
            TempData["IdSpedizione"] = id;

            return View();
        }

        [HttpPost]
        public IActionResult AggiornaSpedizione([Bind(include: "StatusSpedizione , LuogoGiacenzaPacco , Descrizione , DataAggiornamento , IdSpedizione")] StatoSpedizione AggiornamentoSpedizione)
        {
            if (AggiornamentoSpedizione != null)
            {

                try
                {
                    _db.StatoSpedizioni.Add(AggiornamentoSpedizione);
                    _db.SaveChanges();
                    TempData["Message"] = "Spedizione Aggiornata con Successo.";
                    return RedirectToAction("Index");
                }

                catch
                {
                    TempData["Errore"] = "Errore nell'aggiornamento dello stato della spedizione. Modello non valido.";
                    return RedirectToAction("Index");
                }


            }

            TempData["Errore"] = "Errore nell'aggiornamento dello stato della spedizione. Oggetto null.";
            return RedirectToAction("Details");
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
