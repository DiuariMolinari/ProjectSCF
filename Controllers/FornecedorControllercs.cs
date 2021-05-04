using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public IActionResult Index(string Nome, string CpfCnpj, DateTime minData, DateTime maxData)
        {
            List<Fornecedor> fornecedores;
            if (!string.IsNullOrEmpty(Nome) && !string.IsNullOrEmpty(CpfCnpj) && minData != DateTime.MinValue && maxData != DateTime.MinValue)
            {
                fornecedores = _context.Fornecedores.Where(x => x.Nome.Contains(Nome) &&
                                                            x.CpfCnpj.Contains(CpfCnpj) && 
                                                            x.DataNascimento >= minData && 
                                                            x.DataNascimento <= maxData).ToList();
            }
            else if (!string.IsNullOrEmpty(CpfCnpj) && minData != DateTime.MinValue && maxData != DateTime.MinValue)
            {
                fornecedores = _context.Fornecedores.Where(x => x.CpfCnpj.Contains(CpfCnpj) &&
                                                                x.DataNascimento >= minData &&
                                                                x.DataNascimento <= maxData).ToList();
            }
            else if (!string.IsNullOrEmpty(Nome) && minData != DateTime.MinValue && maxData != DateTime.MinValue)
            {
                fornecedores = _context.Fornecedores.Where(x => x.Nome.Contains(Nome) &&
                                                                x.DataNascimento >= minData &&
                                                                x.DataNascimento <= maxData).ToList();
            }
            else if (!string.IsNullOrEmpty(Nome) && !string.IsNullOrEmpty(CpfCnpj))
            {
                fornecedores = _context.Fornecedores.Where(x => x.Nome.Contains(Nome) && x.CpfCnpj.Contains(CpfCnpj)).ToList();
            }
            else if (!string.IsNullOrEmpty(CpfCnpj))
            {
                fornecedores = _context.Fornecedores.Where(x => x.CpfCnpj.Contains(CpfCnpj)).ToList();
            }

            else if (!string.IsNullOrEmpty(Nome))
            {
                fornecedores = _context.Fornecedores.Where(x => x.Nome.Contains(Nome)).ToList();
            }

            else if (minData != DateTime.MinValue && maxData != DateTime.MinValue)
            {
                fornecedores = _context.Fornecedores.Where(x => x.DataNascimento >= minData &&
                                                                x.DataNascimento <= maxData).ToList();
            }

            else
             fornecedores = _context.Fornecedores.ToList();

            if (minData != DateTime.MinValue)
                ViewBag.minData = minData.ToString("yyyy-MM-dd");

            if (maxData != DateTime.MinValue)
                ViewBag.maxData = maxData.ToString("yyyy-MM-dd");

            ViewBag.Nome = Nome;
            ViewBag.CpfCnpj = CpfCnpj;

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
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(fornecedor);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(fornecedor);
            }
            catch (Exception)
            {
                ViewBag.ErrorMessage = "Não foi possível criar novo fornecedor! \r\n Por favor entre em contato com o suporte!";
                return View("Error");
            }
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
            try
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
            catch (Exception)
            {
                ViewBag.ErrorMessage = "Não foi possível atualizar fornecedor! \r\n Por favor entre em contato com o suporte!";
                return View("Error");
            }
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
            try
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
            catch (Exception)
            {
                ViewBag.ErrorMessage = "Não foi possível excluir fornecedor! \r\n Existem registros vinculados a ele!";
                return View("Error");
            }
        }
    }
}
