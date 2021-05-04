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
    public class EmpresaFornecedorController : Controller
    {
        private readonly Context _context;

        public EmpresaFornecedorController(Context context)
        {
            _context = context;
        }

        public IActionResult Index(int? idEmpresa)
        {
            List<EmpresaFornecedor> empresasFornecedores = new List<EmpresaFornecedor>();
            if (idEmpresa != null && idEmpresa != 0)
            {
                empresasFornecedores = _context.EmpresaFornecedor.Include(x => x.Fornecedor).Include(x => x.Empresa).Where(x => x.EmpresaId == idEmpresa).ToList();
                ViewBag.EmpresaId = idEmpresa;
                ViewBag.Empresa = _context.Empresas.Find(idEmpresa).NomeFantasia;
            }
            else
                empresasFornecedores = _context.EmpresaFornecedor.Include(x => x.Fornecedor).Include(x => x.Empresa).ToList();

            return View(empresasFornecedores);
        }

        [HttpGet]
        public IActionResult CriarEmpresaFornecedor(int idEmpresa)
        {
            ViewBag.Empresas = new SelectList(_context.Empresas, "EmpresaId", "NomeFantasia");
            ViewBag.Fornecedores = new SelectList(_context.Fornecedores, "FornecedorId", "Nome");

            ViewBag.Empresa = idEmpresa;
            ViewBag.Fornecedores = new SelectList(_context.Fornecedores, "FornecedorId", "Nome");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CriarEmpresaFornecedor(EmpresaFornecedor EmpresaFornecedor)
        {
            try
            {
                Empresa empresa = _context.Empresas.Include(x => x.Estado).First(x => x.EmpresaId == EmpresaFornecedor.EmpresaId);
                Fornecedor fornecedor = _context.Fornecedores.Find(EmpresaFornecedor.FornecedorId);
                ValidateFonecedor(empresa, fornecedor);
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                return View("Error");
            }
           
            if (ModelState.IsValid)
            {
                _context.Add(EmpresaFornecedor);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", new { idEmpresa = EmpresaFornecedor.EmpresaId });
            }
            return View();
        }

        private void ValidateFonecedor(Empresa empresa, Fornecedor fornecedor)
        {
            if (empresa is null  || fornecedor is null)
                throw new Exception("Não foi possível ler o dados da empresa ou fornecedor!");

            bool isCpf = fornecedor.CpfCnpj.Length <= 11;
            bool isMenorIdade = (DateTime.Now.Year - fornecedor.DataNascimento.Year) < 18;
            if (empresa.Estado.Nome.Equals("Paraná") && isCpf && isMenorIdade)
                throw new Exception("Não é possível vincular um fornecedor pessoa física menor de idade para esta empresa!");
        }

        [HttpGet]
        public IActionResult ExcluirEmpresaFornecedor(int? id)
        {
            if (id != null)
            {
                EmpresaFornecedor EmpresaFornecedor = _context.EmpresaFornecedor.Include(x => x.Empresa).Include(x => x.Fornecedor).First(x => x.Id == id);
                return View(EmpresaFornecedor);
            }
            else
                return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ExcluirEmpresaFornecedor(int? id, EmpresaFornecedor EmpresaFornecedor)
        {
            if (id != null)
            {
                try
                {
                    var empresaFornecedor = _context.EmpresaFornecedor.Include(x => x.Empresa).First(x => x.Id == id);
                    _context.Entry(empresaFornecedor).State = EntityState.Detached;

                    _context.Remove(EmpresaFornecedor);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", new { idEmpresa = empresaFornecedor.Empresa.EmpresaId });
                }
                catch (Exception)
                {
                    ViewBag.ErrorMessage = "Falha ao desvincular fornecedor! Por favor entre em contato com o suporte!";
                    return View("Error");
                }
            }
            else
                return NotFound();
        }
    }
}
