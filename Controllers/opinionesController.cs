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
    public class opinionesController : Controller
    {
        private readonly SupercinesAppContext _context;

        public opinionesController(SupercinesAppContext context)
        {
            _context = context;
        }

        // GET: opiniones
        public async Task<IActionResult> Index()
        {
            var supercinesAppContext = _context.Opiniones.Include(o => o.Pelicula);
            return View(await supercinesAppContext.ToListAsync());
        }

        // GET: opiniones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opinionesModel = await _context.Opiniones
                .Include(o => o.Pelicula)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (opinionesModel == null)
            {
                return NotFound();
            }

            return View(opinionesModel);
        }

        // GET: opiniones/Create
        public IActionResult Create()
        {
            ViewData["PeliculaId"] = new SelectList(_context.Peliculas, "IdPelicula", "TituloDistribucion");
            return View();
        }

        // POST: opiniones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Email,Edad,Fecha,Calificacion,Comentario,PeliculaId")] opinionesModel opinionesModel)
        {
            //if (ModelState.IsValid)
            //{
                _context.Add(opinionesModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
           // }
            ViewData["PeliculaId"] = new SelectList(_context.Peliculas, "IdPelicula", "TituloDistribucion", opinionesModel.PeliculaId);
            return View(opinionesModel);
        }

        // GET: opiniones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opinionesModel = await _context.Opiniones.FindAsync(id);
            if (opinionesModel == null)
            {
                return NotFound();
            }
            ViewData["PeliculaId"] = new SelectList(_context.Peliculas, "IdPelicula", "TituloDistribucion", opinionesModel.PeliculaId);
            return View(opinionesModel);
        }

        // POST: opiniones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Email,Edad,Fecha,Calificacion,Comentario,PeliculaId")] opinionesModel opinionesModel)
        {
            if (id != opinionesModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(opinionesModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!opinionesModelExists(opinionesModel.Id))
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
            ViewData["PeliculaId"] = new SelectList(_context.Peliculas, "IdPelicula", "TituloDistribucion", opinionesModel.PeliculaId);
            return View(opinionesModel);
        }

        // GET: opiniones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opinionesModel = await _context.Opiniones
                .Include(o => o.Pelicula)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (opinionesModel == null)
            {
                return NotFound();
            }

            return View(opinionesModel);
        }

        // POST: opiniones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var opinionesModel = await _context.Opiniones.FindAsync(id);
            if (opinionesModel != null)
            {
                _context.Opiniones.Remove(opinionesModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool opinionesModelExists(int id)
        {
            return _context.Opiniones.Any(e => e.Id == id);
        }
    }
}
