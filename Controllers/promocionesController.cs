using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using supercines.Config;
using supercines.Models;

namespace supercines.Controllers
{
    public class promocionesController : Controller
    {
        private readonly SupercinesAppContext _context;

        public promocionesController(SupercinesAppContext context)
        {
            _context = context;
        }

        // GET: promociones
        public async Task<IActionResult> Index()
        {
            var supercinesAppContext = _context.Promociones.Include(p => p.Funcion);
            return View(await supercinesAppContext.ToListAsync());
        }

        // GET: promociones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promocionesModel = await _context.Promociones
                .Include(p => p.Funcion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (promocionesModel == null)
            {
                return NotFound();
            }

            return View(promocionesModel);
        }

        // GET: promociones/Create
        public IActionResult Create()
        {
            ViewData["FuncionId"] = new SelectList(_context.Funciones, "Id", "Id");
            return View();
        }

        // POST: promociones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion,Descuento,FuncionId")] promocionesModel promocionesModel)
        {
            //if (ModelState.IsValid)
            //{
                _context.Add(promocionesModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            //}
            ViewData["FuncionId"] = new SelectList(_context.Funciones, "Id", "Id", promocionesModel.FuncionId);
            return View(promocionesModel);
        }

        // GET: promociones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promocionesModel = await _context.Promociones.FindAsync(id);
            if (promocionesModel == null)
            {
                return NotFound();
            }
            ViewData["FuncionId"] = new SelectList(_context.Funciones, "Id", "Id", promocionesModel.FuncionId);
            return View(promocionesModel);
        }

        // POST: promociones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion,Descuento,FuncionId")] promocionesModel promocionesModel)
        {
            if (id != promocionesModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(promocionesModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!promocionesModelExists(promocionesModel.Id))
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
            ViewData["FuncionId"] = new SelectList(_context.Funciones, "Id", "Id", promocionesModel.FuncionId);
            return View(promocionesModel);
        }

        // GET: promociones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promocionesModel = await _context.Promociones
                .Include(p => p.Funcion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (promocionesModel == null)
            {
                return NotFound();
            }

            return View(promocionesModel);
        }

        // POST: promociones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var promocionesModel = await _context.Promociones.FindAsync(id);
            if (promocionesModel != null)
            {
                _context.Promociones.Remove(promocionesModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool promocionesModelExists(int id)
        {
            return _context.Promociones.Any(e => e.Id == id);
        }
    }
}
