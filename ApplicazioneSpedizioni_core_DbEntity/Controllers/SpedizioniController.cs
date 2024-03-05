using Microsoft.AspNetCore.Mvc;

namespace ApplicazioneSpedizioni_core_DbEntity.Controllers
{
    public class SpedizioniController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
