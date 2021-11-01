using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projeto_Loja_Sapatos.Data;
using Projeto_Loja_Sapatos.Models;

namespace Projeto_Loja_Sapatos.Controllers
{
    public class ModelosController : Controller
    {
        private readonly AppDbContext _context;

        public ModelosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Modelos
        public async Task<IActionResult> Index()
        {
            var modelos = await _context.Modelos.ToListAsync();
            var fornecedores = await _context.Fornecedores.ToListAsync();
            var categorias = await _context.Categorias.ToListAsync();
            List<ModeloViewModel> modelosViewModels = new List<ModeloViewModel>();
            foreach (var modelo in modelos)
            {
                ModeloViewModel modeloViewModel = new ModeloViewModel();
                modeloViewModel.id = modelo.id;
                modeloViewModel.id_fornecedor = modelo.id_fornecedor;
                modeloViewModel.id_categoria = modelo.id_categoria;
                modeloViewModel.nome = modelo.nome;
                modeloViewModel.codigoRef = modelo.codigoRef;
                modeloViewModel.cor = modelo.cor;
                modeloViewModel.tamanho = modelo.tamanho;
                modeloViewModel.valor = modelo.valor;
                var fornecedor = await _context.Fornecedores
               .FirstOrDefaultAsync(m => m.Id == modelo.id_fornecedor);
                modeloViewModel.nome_fornecedor = fornecedor.Nome;
                var categoria = await _context.Categorias
               .FirstOrDefaultAsync(m => m.Id == modelo.id_categoria);
                modeloViewModel.nome_categoria = categoria.Nome;
                modelosViewModels.Add(modeloViewModel);
            }
            
            return View(modelosViewModels);
        }

        // GET: Modelos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modelo = await _context.Modelos
                .Include(m => m.Categoria)
                .Include(m => m.Fornecedor)
                .FirstOrDefaultAsync(m => m.id == id);
            if (modelo == null)
            {
                return NotFound();
            }

            return View(modelo);
        }

        // GET: Modelos/Create
        public IActionResult Create()
        {
            ViewData["id_categoria"] = new SelectList(_context.Categorias, "Id", "Nome");
            ViewData["id_fornecedor"] = new SelectList(_context.Fornecedores, "Id", "Nome");
            return View();
        }

        // POST: Modelos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,id_fornecedor,id_categoria,codigoRef,cor,tamanho,valor")] Modelo modelo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modelo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["id_categoria"] = new SelectList(_context.Categorias, "Id", "Nome", modelo.id_categoria);
            ViewData["id_fornecedor"] = new SelectList(_context.Fornecedores, "Id", "CNPJ", modelo.id_fornecedor);
            return View(modelo);
        }

        // GET: Modelos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modelo = await _context.Modelos.FindAsync(id);
            if (modelo == null)
            {
                return NotFound();
            }
            ViewData["id_categoria"] = new SelectList(_context.Categorias, "Id", "Nome", modelo.id_categoria);
            ViewData["id_fornecedor"] = new SelectList(_context.Fornecedores, "Id", "CNPJ", modelo.id_fornecedor);
            return View(modelo);
        }

        // POST: Modelos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,id_fornecedor,id_categoria,codigoRef,cor,tamanho,valor")] Modelo modelo)
        {
            if (id != modelo.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modelo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModeloExists(modelo.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["id_categoria"] = new SelectList(_context.Categorias, "Id", "Nome", modelo.id_categoria);
            ViewData["id_fornecedor"] = new SelectList(_context.Fornecedores, "Id", "CNPJ", modelo.id_fornecedor);
            return View(modelo);
        }

        // GET: Modelos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modelo = await _context.Modelos
                .Include(m => m.Categoria)
                .Include(m => m.Fornecedor)
                .FirstOrDefaultAsync(m => m.id == id);
            if (modelo == null)
            {
                return NotFound();
            }

            return View(modelo);
        }

        // POST: Modelos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var modelo = await _context.Modelos.FindAsync(id);
            _context.Modelos.Remove(modelo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModeloExists(int id)
        {
            return _context.Modelos.Any(e => e.id == id);
        }
    }
}
