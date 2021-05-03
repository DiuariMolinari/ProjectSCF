using Microsoft.AspNetCore.Mvc;
using SCF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCF.Controllers
{
    public class FornecedorController : Controller
    {
        private readonly Context _context;

        public FornecedorController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var fornecedores = _context.Fornecedores.ToList();
            return View(fornecedores);
        }

        [HttpGet]
        public IActionResult CriarFornecedor()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CriarFornecedor(Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fornecedor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fornecedor);
        }

        [HttpGet]
        public IActionResult AtualizarFornecedor(int? id)
        {
            if (id != null)
            {
                Fornecedor Fornecedor = _context.Fornecedores.Find(id);
                return View(Fornecedor);
            }
            else
                return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AtualizarFornecedor(int? id, Fornecedor fornecedor)
        {
            if (id != null)
            {
                if (ModelState.IsValid)
                {
                    _context.Update(fornecedor);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                    return View(fornecedor);
            }

            else
                return NotFound();
        }

        [HttpGet]
        public IActionResult ExcluirFornecedor(int? id)
        {
            if (id != null)
            {
                Fornecedor Fornecedor = _context.Fornecedores.Find(id);
                return View(Fornecedor);
            }
            else
                return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ExcluirFornecedor(int? id, Fornecedor Fornecedor)
        {
            if (id != null)
            {
                _context.Remove(Fornecedor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
                return NotFound();
        }
    }
}
