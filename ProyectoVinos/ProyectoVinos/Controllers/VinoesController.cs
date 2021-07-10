using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoVinos.Data;
using ProyectoVinos.Models;

namespace ProyectoVinos.Controllers
{
    public class VinoesController : Controller
    {
        private readonly ProyectoVinosContext _context;

        public VinoesController(ProyectoVinosContext context)
        {
            _context = context;
        }

        // GET: Vinoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vino.ToListAsync());
        }

        // GET: Vinoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vino = await _context.Vino
                .FirstOrDefaultAsync(m => m.IdVino == id);
            if (vino == null)
            {
                return NotFound();
            }

            return View(vino);
        }

        // GET: Vinoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vinoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVino,Nombre,PrecioBase")] Vino vino)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vino);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vino);
        }

        // GET: Vinoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vino = await _context.Vino.FindAsync(id);
            if (vino == null)
            {
                return NotFound();
            }
            return View(vino);
        }

        // POST: Vinoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVino,Nombre,PrecioBase")] Vino vino)
        {
            if (id != vino.IdVino)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vino);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VinoExists(vino.IdVino))
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
            return View(vino);
        }

        // GET: Vinoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vino = await _context.Vino
                .FirstOrDefaultAsync(m => m.IdVino == id);
            if (vino == null)
            {
                return NotFound();
            }

            return View(vino);
        }

        // POST: Vinoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vino = await _context.Vino.FindAsync(id);
            _context.Vino.Remove(vino);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VinoExists(int id)
        {
            return _context.Vino.Any(e => e.IdVino == id);
        }
    }
}
