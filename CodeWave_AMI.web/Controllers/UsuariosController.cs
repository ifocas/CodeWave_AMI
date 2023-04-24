using CodeWave_AMI.Data.Entities;
using CodeWave_AMI.Service;
using CodeWave_AMI.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CodeWave_AMI.web.Controllers
{
        public class UsuariosController : Controller
        {

            private IUsuarioService _usuarioService;

            public UsuariosController(IUsuarioService usuarioService)
            {
                _usuarioService = usuarioService;
            }


            public IActionResult Default()
            {
                return View();
            }

            public IActionResult Registro()
            {
                return View();
            }

            [HttpPost]
            public IActionResult Registro(UsuarioViewModel usuariovm)
            {
                if (_usuarioService.CompararMails(usuariovm.Email))
                {
                    ViewBag.Msg = "La dirección de Email ya se encuentra registrada";
                    return View();
                }
                if (ModelState.IsValid)
                {
                    _usuarioService.Registrar(usuariovm);
                    return RedirectToAction(nameof(Login));
                }
                return RedirectToAction(nameof(Registro));
            }

            public IActionResult Login()
            {
                return View();
            }

            [HttpPost]
            public async Task<IActionResult> Login(string email, string password)
            {

                Usuario usuario = _usuarioService.VerificarLogin(email, password);               

                if (usuario != null)
                {

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name ,usuario.Nombre),
                         new Claim("Email" ,usuario.Email),
                          new Claim("IdUsuario" ,usuario.IdUsuario.ToString()),
                };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return View();
                }
                else
                {
                    ViewBag.Msg = "Usuario o contraseña incorrectos";
                    return View();
                }
            }

            public async Task<IActionResult> Logout()
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return RedirectToAction(nameof(Default));
            }



        
    }
}
