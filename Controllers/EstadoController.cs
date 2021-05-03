using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SCF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCF.Controllers
{
    public class EstadoController : Controller
    {
        private readonly Context _context;

        public EstadoController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var Estados = _context.Estados.Include(x => x.Pais).ToList();
            return View(Estados);
        }

        [HttpGet]
        public IActionResult CriarEstado()
        {
            ViewBag.Paises = new SelectList(_context.Paises, "PaisId", "Nome");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CriarEstado(Estado Estado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Estado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Estado);
        }

        [HttpGet]
        public IActionResult AtualizarEstado(int? id)
        {
            if (id != null)
            {
                ViewBag.Paises = new SelectList(_context.Paises, "PaisId", "Nome");
                Estado Estado = _context.Estados.Find(id);
                return View(Estado);
            }
            else
                return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AtualizarEstado(int? id, Estado Estado)
        {
            if (id != null)
            {
                if (ModelState.IsValid)
                {
                    _context.Update(Estado);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                    return View(Estado);
            }

            else
                return NotFound();
        }

        [HttpGet]
        public IActionResult ExcluirEstado(int? id)
        {
            if (id != null)
            {
                Estado Estado = _context.Estados.Find(id);
                return View(Estado);
            }
            else
                return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ExcluirEstado(int? id, Estado Estado)
        {
            if (id != null)
            {
                _context.Remove(Estado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
                return NotFound();
        }
    }
}
