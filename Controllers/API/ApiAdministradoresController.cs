using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using admin_cms.Models.Domino.Entidades;
using admin_cms.Models.Infraestrutura.Database;
using admin_cms.Models.Infraestrutura.Autenticacao;

namespace admin_cms.Controllers.API
{
    public class ApiAdministradoresController : ControllerBase
    {
        private readonly ContextoCms _context;

        public ApiAdministradoresController(ContextoCms context)
        {
            _context = context;
        }

        // GET: Administradores
        [HttpGet]
        [Route("/api/administradores.json")]
        public async Task<IActionResult> Index()
        {  
            var adms = from adm in (await _context.Administradores.ToListAsync())
                select new {
                    Id = adm.Id,
                    Nome = adm.Nome,
                    Telefone = adm.Telefone,
                    Email = adm.Email
                };

            return StatusCode(200, adms);
        }

        [HttpPost]
        [Route("/api/administradores.json")]
        public async Task<IActionResult> Criar([FromBody] Administrador administrador)
        {  
            _context.Administradores.Add(administrador);
            await _context.SaveChangesAsync();
            return StatusCode(200, administrador);
        }
    }
}
