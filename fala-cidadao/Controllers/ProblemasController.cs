using fala_cidadao.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace fala_cidadao.Controllers
{
    [Authorize]
    public class ProblemasController : Controller
    {
        private readonly AppDbContext _context;

        public ProblemasController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var dados = await _context.Problemas.ToListAsync();
            return View(dados);
        }

        public IActionResult Create()
        {
            ViewBag.Categorias = new SelectList(Enum.GetValues(typeof(Categoria)).Cast<Categoria>());
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Problema problema)
        {
            if (ModelState.IsValid)
            {
                _context.Problemas.Add(problema);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            // Repassa a lista de categorias para a view caso a validação falhe
            ViewBag.Categorias = new SelectList(Enum.GetValues(typeof(Categoria)).Cast<Categoria>());
            return View(problema);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Problemas.FindAsync(id);
            if (dados == null)
                return NotFound();

            // Passa a lista de categorias para a view
            ViewBag.Categorias = new SelectList(Enum.GetValues(typeof(Categoria)).Cast<Categoria>());
            return View(dados);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Problema problema)
        {
            if (id != problema.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Problemas.Update(problema);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Categorias = new SelectList(Enum.GetValues(typeof(Categoria)).Cast<Categoria>());
            return View(problema);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Problemas.FindAsync(id);

            if (dados == null)
                return NotFound();

            return View(dados);


        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Problemas.FindAsync(id);

            if (dados == null)
                return NotFound();

            return View(dados);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Problemas.FindAsync(id);

            if (dados == null)
                return NotFound();

            _context.Problemas.Remove(dados);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
