using Microsoft.AspNetCore.Mvc;
using SCF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCF.Controllers
{
    public class PaisController : Controller
    {
        private readonly Context _context;

        public PaisController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var Paises = _context.Paises.ToList();
            return View(Paises);
        }

        [HttpGet]
        public IActionResult CriarPais()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CriarPais(Pais Pais)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Pais);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Pais);
        }

        [HttpGet]
        public IActionResult AtualizarPais(int? id)
        {
            if (id != null)
            {
                Pais Pais = _context.Paises.Find(id);
                return View(Pais);
            }
            else
                return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AtualizarPais(int? id, Pais Pais)
        {
            if (id != null)
            {
                if (ModelState.IsValid)
                {
                    _context.Update(Pais);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                    return View(Pais);
            }

            else
                return NotFound();
        }

        [HttpGet]
        public IActionResult ExcluirPais(int? id)
        {
            if (id != null)
            {
                Pais Pais = _context.Paises.Find(id);
                return View(Pais);
            }
            else
                return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ExcluirPais(int? id, Pais Pais)
        {
            if (id != null)
            {
                _context.Remove(Pais);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
                return NotFound();
        }
    }
}
