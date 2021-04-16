using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using admin_cms.Models.Domino.Entidades;
using admin_cms.Models.Domino.Services;
using admin_cms.Models.Infraestrutura.Database;
using X.PagedList;

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
        public async Task<IActionResult> Index(int page = 1)
        {
            var adms = from adm in ( await _context.Administradores.ToPagedListAsync(page, AdministradorService.ITENS_POR_PAGINA))
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

        [HttpPut]
        [Route("/api/administradores/{id}.json")]
        public async Task<IActionResult> Change([FromBody] Administrador administrador)
        {  
            _context.Administradores.Update(administrador);
            await _context.SaveChangesAsync();
            return StatusCode(200, administrador);
        }

        [HttpDelete]
        [Route("/api/administradores/{id}.json")]
        public async Task<IActionResult> Destroy(int id)
        {  
            Administrador adm = await _context.Administradores.FindAsync(id);
            _context.Administradores.Remove(adm);
            await _context.SaveChangesAsync();
            return StatusCode(204);
        }
    }
}
