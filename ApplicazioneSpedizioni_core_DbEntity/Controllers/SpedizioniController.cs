using ApplicazioneSpedizioni_core_DbEntity.data;
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
    }
}
