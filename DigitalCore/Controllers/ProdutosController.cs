using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DigitalCore.Data;
using DigitalCore.Models;

namespace DigitalCore.Controllers
{
    /// <summary>
    /// Alteração do Controller p/ Gerir como vão ser apresentados os Produtos em Categorias
    /// </summary>
    public class ProdutosController : Controller
    {
        private readonly DigitalCoreDB _context;

        public ProdutosController(DigitalCoreDB context)
        {
            _context = context;
        }

        // GET: Produtos
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoProduto.ToListAsync());
        }

        // GET: Produtos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoProduto = await _context.TipoProduto
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tipoProduto == null)
            {
                return NotFound();
            }

            return View(tipoProduto);
        }

        // GET: Produtos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Descricao")] TipoProduto tipoProduto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoProduto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoProduto);
        }

        // GET: Produtos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoProduto = await _context.TipoProduto.FindAsync(id);
            if (tipoProduto == null)
            {
                return NotFound();
            }
            return View(tipoProduto);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Descricao")] TipoProduto tipoProduto)
        {
            if (id != tipoProduto.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoProduto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoProdutoExists(tipoProduto.ID))
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
            return View(tipoProduto);
        }

        // GET: Produtos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoProduto = await _context.TipoProduto
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tipoProduto == null)
            {
                return NotFound();
            }

            return View(tipoProduto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoProduto = await _context.TipoProduto.FindAsync(id);
            _context.TipoProduto.Remove(tipoProduto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoProdutoExists(int id)
        {
            return _context.TipoProduto.Any(e => e.ID == id);
        }
    }
}
