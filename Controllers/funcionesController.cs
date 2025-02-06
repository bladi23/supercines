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
    public class funcionesController : Controller
    {
        private readonly SupercinesAppContext _context;

        public funcionesController(SupercinesAppContext context)
        {
            _context = context;
        }

        // GET: funciones
        public async Task<IActionResult> Index()
        {
            var supercinesAppContext = _context.Funciones.Include(f => f.Pelicula).Include(f => f.Sala);
            return View(await supercinesAppContext.ToListAsync());
        }

        // GET: funciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionesModel = await _context.Funciones
                .Include(f => f.Pelicula)
                .Include(f => f.Sala)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (funcionesModel == null)
            {
                return NotFound();
            }

            return View(funcionesModel);
        }

        // GET: funciones/Create
        public IActionResult Create()
        {
            ViewData["PeliculaId"] = new SelectList(_context.Peliculas, "IdPelicula", "TituloDistribucion");
            ViewData["SalaId"] = new SelectList(_context.Salas, "Id", "Id");
            return View();
        }

        // POST: funciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PeliculaId,SalaId,DiaSemana,HoraInicio")] funcionesModel funcionesModel)
        {
           // if (ModelState.IsValid)
            //{
                _context.Add(funcionesModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
           // }
            ViewData["PeliculaId"] = new SelectList(_context.Peliculas, "IdPelicula", "TituloDistribucion", funcionesModel.PeliculaId);
            ViewData["SalaId"] = new SelectList(_context.Salas, "Id", "Id", funcionesModel.SalaId);
            return View(funcionesModel);
        }

        // GET: funciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionesModel = await _context.Funciones.FindAsync(id);
            if (funcionesModel == null)
            {
                return NotFound();
            }
            ViewData["PeliculaId"] = new SelectList(_context.Peliculas, "IdPelicula", "TituloDistribucion", funcionesModel.PeliculaId);
            ViewData["SalaId"] = new SelectList(_context.Salas, "Id", "Id", funcionesModel.SalaId);
            return View(funcionesModel);
        }

        // POST: funciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PeliculaId,SalaId,DiaSemana,HoraInicio")] funcionesModel funcionesModel)
        {
            if (id != funcionesModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(funcionesModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!funcionesModelExists(funcionesModel.Id))
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
            ViewData["PeliculaId"] = new SelectList(_context.Peliculas, "IdPelicula", "TituloDistribucion", funcionesModel.PeliculaId);
            ViewData["SalaId"] = new SelectList(_context.Salas, "Id", "Id", funcionesModel.SalaId);
            return View(funcionesModel);
        }

        // GET: funciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionesModel = await _context.Funciones
                .Include(f => f.Pelicula)
                .Include(f => f.Sala)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (funcionesModel == null)
            {
                return NotFound();
            }

            return View(funcionesModel);
        }

        // POST: funciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var funcionesModel = await _context.Funciones.FindAsync(id);
            if (funcionesModel != null)
            {
                _context.Funciones.Remove(funcionesModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool funcionesModelExists(int id)
        {
            return _context.Funciones.Any(e => e.Id == id);
        }
    }
}
