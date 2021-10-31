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
    public class ModeloController : Controller
    {
        private readonly AppDbContext _context;

        public ModeloController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Modelo
        public async Task<IActionResult> Index()
        {
            //var modelo = await _context.Modelos.ToListAsync();
            //var fornecedor = await _context.Modelos.ToListAsync(m => m.Id==Modelo);
            //var categoria = await _context.Modelos.ToListAsync();
            var appDbContext = _context.Modelos.Include(m => m.Categoria).Include(m => m.Fornecedor);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Modelo/Details/5
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

        // GET: Modelo/Create
        public IActionResult Create()
        {
            ViewData["id_categoria"] = new SelectList(_context.Categorias, "Id", "Nome");
            ViewData["id_fornecedor"] = new SelectList(_context.Fornecedores, "Id", "CNPJ");
            return View();
        }

        // POST: Modelo/Create
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

        // GET: Modelo/Edit/5
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

        // POST: Modelo/Edit/5
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

        // GET: Modelo/Delete/5
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

        // POST: Modelo/Delete/5
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
