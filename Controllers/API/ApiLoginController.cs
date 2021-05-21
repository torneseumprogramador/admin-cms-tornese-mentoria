using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using admin_cms.Models.Domino.Entidades;
using admin_cms.Models.Domino.Services;
using admin_cms.Models.Infraestrutura.Database;
using X.PagedList;
using Microsoft.EntityFrameworkCore;
using admin_cms.Models.Infraestrutura.Autenticacao;
using Microsoft.AspNetCore.Authorization;

namespace admin_cms.Controllers.API
{
    public class ApiLoginController : ControllerBase
    {
        private readonly ContextoCms _context;

        public ApiLoginController(ContextoCms context)
        {
            _context = context;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("/api/login.json")]
        public async Task<IActionResult> Login([FromBody] Administrador adm)
        {
            try{
                var administrador = (await _context.Administradores.Where(a => a.Email == adm.Email && a.Senha == adm.Senha).FirstAsync());
                return StatusCode(200, new {
                    Id = administrador.Id,
                    Nome = administrador.Nome,
                    Email = administrador.Email,
                    Acesso = administrador.Acesso,
                    Telefone = administrador.Telefone,
                    Token = Token.GerarToken(administrador)
                });
            }
            catch(Exception err){
                return StatusCode(401, new {
                    Mensagem = "Usuário ou senha inválidos"
                });
            }
        }
    }
}
