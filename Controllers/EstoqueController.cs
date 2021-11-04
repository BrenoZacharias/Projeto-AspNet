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
    public class EstoqueController : Controller
    {
        private readonly AppDbContext _context;

        public EstoqueController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Estoque
        public async Task<IActionResult> Index()
        {
            var estoques = await _context.Estoques.ToListAsync();
            List<EstoqueViewModel> estoquesViewModels = new List<EstoqueViewModel>();
            foreach (var estoque in estoques)
            {
                EstoqueViewModel estoqueViewModel = new EstoqueViewModel();
                estoqueViewModel.Id = estoque.Id;
                estoqueViewModel.Qtd = estoque.Qtd;
                var modelo = await _context.Modelos.FirstOrDefaultAsync(m => m.id == estoque.Id_Modelo);
                estoqueViewModel.Nome_Modelo = modelo.nome;
                estoquesViewModels.Add(estoqueViewModel);
            }

            return View(estoquesViewModels);
        }

        // GET: Estoque/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estoque = await _context.Estoques
                .Include(e => e.Modelo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estoque == null)
            {
                return NotFound();
            }

            return View(estoque);
        }

        // GET: Estoque/Create
        public IActionResult Create()
        {
            ViewData["Id_Modelo"] = new SelectList(_context.Modelos, "id", "nome");
            return View();
        }

        // POST: Estoque/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Id_Modelo,Qtd")] Estoque estoque)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estoque);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id_Modelo"] = new SelectList(_context.Modelos, "id", "codigoRef", estoque.Id_Modelo);
            return View(estoque);
        }

        // GET: Estoque/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estoque = await _context.Estoques.FindAsync(id);
            if (estoque == null)
            {
                return NotFound();
            }
            ViewData["Id_Modelo"] = new SelectList(_context.Modelos, "id", "codigoRef", estoque.Id_Modelo);
            return View(estoque);
        }

        // POST: Estoque/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Id_Modelo,Qtd")] Estoque estoque)
        {
            if (id != estoque.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estoque);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstoqueExists(estoque.Id))
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
            ViewData["Id_Modelo"] = new SelectList(_context.Modelos, "id", "codigoRef", estoque.Id_Modelo);
            return View(estoque);
        }

        // GET: Estoque/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estoque = await _context.Estoques
                .Include(e => e.Modelo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estoque == null)
            {
                return NotFound();
            }

            return View(estoque);
        }

        // POST: Estoque/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estoque = await _context.Estoques.FindAsync(id);
            _context.Estoques.Remove(estoque);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstoqueExists(int id)
        {
            return _context.Estoques.Any(e => e.Id == id);
        }
    }
}
