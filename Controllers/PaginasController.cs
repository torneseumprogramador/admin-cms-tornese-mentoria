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
using Microsoft.AspNetCore.Authorization;

namespace admin_cms.Controllers
{
    [AllowAnonymous]
    [Logado]
    public class PaginasController : Controller
    {
        private readonly ContextoCms _context;

        public PaginasController(ContextoCms context)
        {
            _context = context;
        }

        // GET: Paginas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Paginas.ToListAsync());
        }

        // GET: Paginas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagina = await _context.Paginas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pagina == null)
            {
                return NotFound();
            }

            return View(pagina);
        }

        // GET: Paginas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Paginas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Conteudo,AreaRestrita,Login,Home,Ordem")] Pagina pagina)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pagina);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pagina);
        }

        // GET: Paginas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagina = await _context.Paginas.FindAsync(id);
            if (pagina == null)
            {
                return NotFound();
            }
            return View(pagina);
        }

        // POST: Paginas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Conteudo,AreaRestrita,Login,Home,Ordem")] Pagina pagina)
        {
            if (id != pagina.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pagina);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaginaExists(pagina.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pagina);
        }

        // GET: Paginas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagina = await _context.Paginas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pagina == null)
            {
                return NotFound();
            }

            return View(pagina);
        }

        // POST: Paginas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pagina = await _context.Paginas.FindAsync(id);
            _context.Paginas.Remove(pagina);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaginaExists(int id)
        {
            return _context.Paginas.Any(e => e.Id == id);
        }
    }
}
