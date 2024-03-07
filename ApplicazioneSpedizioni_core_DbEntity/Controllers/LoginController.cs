using ApplicazioneSpedizioni_core_DbEntity.data;
using ApplicazioneSpedizioni_core_DbEntity.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ApplicazioneSpedizioni_core_DbEntity.Controllers
{
    public class LoginController : Controller
    {

        private readonly ApplicationDbContext _db;
        private readonly IAuthenticationSchemeProvider _schemeProvider;
        public LoginController(ApplicationDbContext db, IAuthenticationSchemeProvider schemeProvider)
        {
            _db = db;
            _schemeProvider = schemeProvider;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost] // questo metodo è asincrono perchè fa una chiamata al database
        public async Task<IActionResult> MethodLogin(Login login)
        {
            if (login.nome != null && login.password != null)
            {
                // Creare una query SQL raw
                string sqlQuery = "SELECT * FROM Utenti" +
                    " WHERE Nome = @nome AND Password = @password";

                var nomeParam = new SqlParameter("@nome", login.nome);
                var passwordParam = new SqlParameter("@password", login.password);
                // Eseguire la query SQL raw
                var user = await _db.Utenti.FromSqlRaw(sqlQuery, nomeParam, passwordParam).FirstOrDefaultAsync();

                if (user != null)
                {
                    if (user.Nome == login.nome && user.Password == login.password)
                    {
                        TempData["Message"] = "Login effettuato con successo";

                        var claims = new List<Claim>
                        {
                        new Claim(ClaimTypes.Name, login.nome),
                        new Claim(ClaimTypes.Role, user.TipoUtente) ,
                        new Claim("Id" , user.IdUtente.ToString()) ,
                       
                        //new Claim(ClaimTypes.Thumbprint, user.Id.ToString())
                        };

                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                        var authProperties = new AuthenticationProperties();

                        await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);

                        return RedirectToAction("Index", "Home");
                    }


                }
                else
                {
                    TempData["Errore"] = "Nome o password non validi";
                    return RedirectToAction("Index", "Home");
                }
            }
            TempData["Errore"] = "Nome o password non validi";
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            TempData["Message"] = "Logout effettuato.";
            return RedirectToAction("Index", "Home");
        }
    }
}
