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
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(Pais);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(Pais);
            }
            catch (Exception)
            {
                ViewBag.ErrorMessage = "Não foi possível criar novo país! \r\n Por favor entre em contato com o suporte!";
                return View("Error");
            }
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
            try
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
            catch (Exception)
            {
                ViewBag.ErrorMessage = "Não foi possível atualizar país! \r\n Por favor entre em contato com o suporte!";
                return View("Error");
            }
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
            try
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
            catch (Exception)
            {
                ViewBag.ErrorMessage = "Não foi possível Excluir país! \r\n Existem registros vinculados a ele!";
                return View("Error");
            }
        }
    }
}
