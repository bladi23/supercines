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
    public class repartosController : Controller
    {
        private readonly SupercinesAppContext _context;

        public repartosController(SupercinesAppContext context)
        {
            _context = context;
        }

        // GET: repartos
        public async Task<IActionResult> Index()
        {
            var supercinesAppContext = _context.Repartos.Include(r => r.Pelicula).Include(r => r.Persona);
            return View(await supercinesAppContext.ToListAsync());
        }

        // GET: repartos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repartosModel = await _context.Repartos
                .Include(r => r.Pelicula)
                .Include(r => r.Persona)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (repartosModel == null)
            {
                return NotFound();
            }

            return View(repartosModel);
        }

        // GET: repartos/Create
        public IActionResult Create()
        {
            ViewData["PeliculaId"] = new SelectList(_context.Peliculas, "IdPelicula", "TituloDistribucion");
            ViewData["PersonaId"] = new SelectList(_context.Personas, "Id", "Nombre");
            return View();
        }

        // POST: repartos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PeliculaId,PersonaId,Personaje")] repartosModel repartosModel)
        {
            //if (ModelState.IsValid)
            //{
                _context.Add(repartosModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            //}
            ViewData["PeliculaId"] = new SelectList(_context.Peliculas, "IdPelicula", "TituloDistribucion", repartosModel.PeliculaId);
            ViewData["PersonaId"] = new SelectList(_context.Personas, "Id", "Nombre", repartosModel.PersonaId);
            return View(repartosModel);
        }

        // GET: repartos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repartosModel = await _context.Repartos.FindAsync(id);
            if (repartosModel == null)
            {
                return NotFound();
            }
            ViewData["PeliculaId"] = new SelectList(_context.Peliculas, "IdPelicula", "TituloDistribucion", repartosModel.PeliculaId);
            ViewData["PersonaId"] = new SelectList(_context.Personas, "Id", "Nombre", repartosModel.PersonaId);
            return View(repartosModel);
        }

        // POST: repartos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PeliculaId,PersonaId,Personaje")] repartosModel repartosModel)
        {
            if (id != repartosModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(repartosModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!repartosModelExists(repartosModel.Id))
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
            ViewData["PeliculaId"] = new SelectList(_context.Peliculas, "IdPelicula", "TituloDistribucion", repartosModel.PeliculaId);
            ViewData["PersonaId"] = new SelectList(_context.Personas, "Id", "Nombre", repartosModel.PersonaId);
            return View(repartosModel);
        }

        // GET: repartos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repartosModel = await _context.Repartos
                .Include(r => r.Pelicula)
                .Include(r => r.Persona)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (repartosModel == null)
            {
                return NotFound();
            }

            return View(repartosModel);
        }

        // POST: repartos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var repartosModel = await _context.Repartos.FindAsync(id);
            if (repartosModel != null)
            {
                _context.Repartos.Remove(repartosModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool repartosModelExists(int id)
        {
            return _context.Repartos.Any(e => e.Id == id);
        }
    }
}
