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
    public class EmpresaController : Controller
    {
        private readonly Context _context;

        public EmpresaController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var Empresas = _context.Empresas.Include(x => x.Estado).ToList();
            return View(Empresas);
        }

        [HttpGet]
        public IActionResult CriarEmpresa()
        {
            ViewBag.Estados = new SelectList(_context.Estados, "PaisId", "Nome");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CriarEmpresa(Empresa Empresa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Empresa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Empresa);
        }

        [HttpGet]
        public IActionResult AtualizarEmpresa(int? id)
        {
            if (id != null)
            {
                ViewBag.Estados = new SelectList(_context.Estados, "EstadoId", "Nome");
                var empresa = _context.Empresas.Find(id);
                return View(empresa);
            }
            else
                return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AtualizarEmpresa(int? id, Empresa Empresa)
        {
            if (id != null)
            {
                if (ModelState.IsValid)
                {
                    _context.Update(Empresa);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                    return View(Empresa);
            }

            else
                return NotFound();
        }

        [HttpGet]
        public IActionResult ExcluirEmpresa(int? id)
        {
            if (id != null)
            {
                Empresa empresa = _context.Empresas.Include(x => x.Estado).First(x => x.EmpresaId == id);
                return View(empresa);
            }
            else
                return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ExcluirEmpresa(int? id, Empresa Empresa)
        {
            if (id != null)
            {
                _context.Remove(Empresa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
                return NotFound();
        }

        [HttpGet]
        public IActionResult Fornecedores(int? id)
        {
            if (id != null)
            {
                return RedirectToAction("Index", "EmpresaFornecedor", new { idEmpresa = id });
            }
            else
                return NotFound();
        }
    }
}
