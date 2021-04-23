using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using admin_cms.Models;
using Microsoft.AspNetCore.Http;
using admin_cms.Models.Infraestrutura.Autenticacao;
using admin_cms.Models.Infraestrutura.Database;
using Microsoft.AspNetCore.Authorization;

namespace admin_cms.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("/login/logar")]
        [HttpPost]
        public IActionResult Logar(string email, string senha)
        {
            if(string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
            {
                ViewBag.erro = "Digite o e-mail e a senha";
            }
            else
            {
                var adms = new ContextoCms().Administradores.Where(a => a.Email == email && a.Senha == senha).ToList();
                if(adms.Count > 0)
                {
                    this.HttpContext.Response.Cookies.Append("adm_cms", adms.First().Id.ToString(), new CookieOptions
                    {
                        Expires = DateTimeOffset.UtcNow.AddDays(1),
                        HttpOnly = true,
                    });

                    Response.Redirect("/");
                }
                else
                {
                    ViewBag.erro = "Usuário ou senha inválidos";
                }

            }
            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
