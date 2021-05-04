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
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(Estado);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(Estado);
            }
           
            catch (Exception)
            {
                ViewBag.ErrorMessage = "Não foi possível criar novo estado! \r\n Por favor entre em contato com o suporte!";
                return View("Error");
            }
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
            try
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
            catch (Exception)
            {
                ViewBag.ErrorMessage = "Não foi possível atualizar estado! \r\n Por favor entre em contato com o suporte!";
                return View("Error");
            }
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
            try
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
            catch (Exception)
            {
                ViewBag.ErrorMessage = "Não foi possível excluir estado! \r\n Existem registros vinculados a ele!";
                return View("Error");
            }
        }
    }
}
