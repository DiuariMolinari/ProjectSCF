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
    public class ContatoController : Controller
    {
        private readonly Context _context;

        public ContatoController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var Contatos = _context.Contatos.Include(x => x.Fornecedor).ToList();
            return View(Contatos);
        }

        [HttpGet]
        public IActionResult CriarContato()
        {
            ViewBag.Fornecedores = new SelectList(_context.Fornecedores, "FornecedorId", "Nome");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CriarContato(Contato Contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(Contato);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(Contato);
            }
            catch (Exception)
            {
                ViewBag.ErrorMessage = "Não foi possível criar novo contato! \r\n Por favor entre em contato com o suporte!";
                return View("Error");
            }
        }

        [HttpGet]
        public IActionResult AtualizarContato(int? id)
        {
            if (id != null)
            {
                ViewBag.Fornecedores = new SelectList(_context.Fornecedores, "FornecedorId", "Nome");
                Contato Contato = _context.Contatos.Find(id);
                return View(Contato);
            }
            else
                return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AtualizarContato(int? id, Contato Contato)
        {
            try
            {
                if (id != null)
                {
                    if (ModelState.IsValid)
                    {
                        _context.Update(Contato);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                    else
                        return View(Contato);
                }

                else
                    return NotFound();
            }

            catch (Exception)
            {
                ViewBag.ErrorMessage = "Não foi possível atualizar contato! \r\n Por favor entre em contato com o suporte!";
                return View("Error");
            }
        }

        [HttpGet]
        public IActionResult ExcluirContato(int? id)
        {
            if (id != null)
            {
                Contato Contato = _context.Contatos.Include(x => x.Fornecedor).First(x => x.ContatoId == id);
                return View(Contato);
            }
            else
                return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ExcluirContato(int? id, Contato Contato)
        {
            try
            {
                if (id != null)
                {
                    _context.Remove(Contato);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                    return NotFound();
            }

            catch (Exception)
            {
                ViewBag.ErrorMessage = "Não foi possível excluir contato! \r\n Por favor entre em contato com o suporte!";
                return View("Error");
            }
        }
    }
}
