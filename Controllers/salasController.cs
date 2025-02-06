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
    public class salasController : Controller
    {
        private readonly SupercinesAppContext _context;

        public salasController(SupercinesAppContext context)
        {
            _context = context;
        }

        // GET: salas
        public async Task<IActionResult> Index()
        {
            var supercinesAppContext = _context.Salas.Include(s => s.Cine);
            return View(await supercinesAppContext.ToListAsync());
        }

        // GET: salas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salasModel = await _context.Salas
                .Include(s => s.Cine)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salasModel == null)
            {
                return NotFound();
            }

            return View(salasModel);
        }

        // GET: salas/Create
        public IActionResult Create()
        {
            ViewData["CineId"] = new SelectList(_context.Cines, "Id", "Direccion");
            return View();
        }

        // POST: salas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Numero,Capacidad,CineId")] salasModel salasModel)
        {
            //if (ModelState.IsValid)
           // {
                _context.Add(salasModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
           // }
            ViewData["CineId"] = new SelectList(_context.Cines, "Id", "Direccion", salasModel.CineId);
            return View(salasModel);
        }

        // GET: salas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salasModel = await _context.Salas.FindAsync(id);
            if (salasModel == null)
            {
                return NotFound();
            }
            ViewData["CineId"] = new SelectList(_context.Cines, "Id", "Direccion", salasModel.CineId);
            return View(salasModel);
        }

        // POST: salas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Numero,Capacidad,CineId")] salasModel salasModel)
        {
            if (id != salasModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salasModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!salasModelExists(salasModel.Id))
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
            ViewData["CineId"] = new SelectList(_context.Cines, "Id", "Direccion", salasModel.CineId);
            return View(salasModel);
        }

        // GET: salas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salasModel = await _context.Salas
                .Include(s => s.Cine)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salasModel == null)
            {
                return NotFound();
            }

            return View(salasModel);
        }

        // POST: salas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salasModel = await _context.Salas.FindAsync(id);
            if (salasModel != null)
            {
                _context.Salas.Remove(salasModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool salasModelExists(int id)
        {
            return _context.Salas.Any(e => e.Id == id);
        }
    }
}
