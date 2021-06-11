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
using X.PagedList;
using admin_cms.Models.Domino.Services;
using Microsoft.AspNetCore.Authorization;

namespace admin_cms.Controllers.API
{

    [ApiController]
    public class ApiPaginasController : ControllerBase
    {
        private readonly ContextoCms _context;

        public ApiPaginasController(ContextoCms context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("/api/paginas/home.json")]
        [AllowAnonymous]
        public async Task<IActionResult> Home()
        {
            var pagina = await _context.Paginas.Where(p => p.Home).FirstAsync();
            return StatusCode(200, pagina);
        }

        [HttpGet]
        [Route("/api/paginas/{slug}.json")]
        [AllowAnonymous]
        public async Task<IActionResult> Slug(string slug)
        {
            var pagina = await _context.Paginas.Where(p => p.Nome.ToLower() == slug.ToLower()).FirstAsync();
            return StatusCode(200, pagina);
        }

        [HttpGet]
        [Route("/api/paginas.json")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index(int page = 1)
        {
            return StatusCode(200, await _context.Paginas.ToPagedListAsync(page, PaginaService.ITENS_POR_PAGINA));
        }

        [HttpPost]
        [Route("/api/paginas.json")]
        public async Task<IActionResult> Create([FromBody] Pagina pagina)
        {
            _context.Add(pagina);
            await _context.SaveChangesAsync();
            return StatusCode(201);
        }

        [HttpPut]
        [Route("/api/paginas/{id}.json")]
        public async Task<IActionResult> Update(int id, [FromBody] Pagina pagina)
        {
            pagina.Id = id;
            _context.Update(pagina);
            await _context.SaveChangesAsync();
            return StatusCode(200);
        }

        [HttpDelete]
        [Route("/api/paginas/{id}.json")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return StatusCode(400, new { Mensagem = "O Id é obrigatório" });
            }

            var pagina = await _context.Paginas.FirstOrDefaultAsync(m => m.Id == id);
            if (pagina == null)
            {
                return StatusCode(404, new { Mensagem = "A página não foi encontrada" });
            }

            _context.Paginas.Remove(pagina);
            await _context.SaveChangesAsync();
            return StatusCode(204);
        }
    }
}
