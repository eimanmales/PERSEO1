using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using PERSEO.Data;
using PERSEO.Models;
using System.Security.Claims;

namespace PERSEO.Controllers
{
    public class AccesoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Usuario _usuario)
        {
            DA_Logica _da_logica = new DA_Logica();

            var usuario = _da_logica.validarUsuario(_usuario.Correo, _usuario.Clave);

            if (usuario != null)//si el usuario es diferente de vacio
            {
                var claim = new List<Claim>
                {
                    new(ClaimTypes.Name, usuario.Clave),
                    new("Correo", usuario.Correo)

                };
                //Añadir y recorrer roles 
                foreach (string rol in usuario.Roles)
                {
                    claim.Add(new(ClaimTypes.Role, rol));
                }
                var ClaimsIdentity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(ClaimsIdentity));

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }


        }

        public async Task<IActionResult> Salir()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Acceso");
        }
    }
}
