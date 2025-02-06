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
    public class peliculasController : Controller
    {
        private readonly SupercinesAppContext _context;

        public peliculasController(SupercinesAppContext context)
        {
            _context = context;
        }

        // GET: peliculas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Peliculas.ToListAsync());
        }

        // GET: peliculas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peliculasModel = await _context.Peliculas
                .FirstOrDefaultAsync(m => m.IdPelicula == id);
            if (peliculasModel == null)
            {
                return NotFound();
            }

            return View(peliculasModel);
        }

        // GET: peliculas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: peliculas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPelicula,TituloDistribucion,TituloOriginal,Genero,IdiomaOriginal,Subtitulada,PaisOrigen,AñoProduccion,UrlSitioWeb,Duracion,Clasificacion,FechaEstreno,Resumen")] peliculasModel peliculasModel)
        {
            //if (ModelState.IsValid)
            //{
                _context.Add(peliculasModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
           // }
            return View(peliculasModel);
        }

        // GET: peliculas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peliculasModel = await _context.Peliculas.FindAsync(id);
            if (peliculasModel == null)
            {
                return NotFound();
            }
            return View(peliculasModel);
        }

        // POST: peliculas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPelicula,TituloDistribucion,TituloOriginal,Genero,IdiomaOriginal,Subtitulada,PaisOrigen,AñoProduccion,UrlSitioWeb,Duracion,Clasificacion,FechaEstreno,Resumen")] peliculasModel peliculasModel)
        {
            if (id != peliculasModel.IdPelicula)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(peliculasModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!peliculasModelExists(peliculasModel.IdPelicula))
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
            return View(peliculasModel);
        }

        // GET: peliculas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peliculasModel = await _context.Peliculas
                .FirstOrDefaultAsync(m => m.IdPelicula == id);
            if (peliculasModel == null)
            {
                return NotFound();
            }

            return View(peliculasModel);
        }

        // POST: peliculas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var peliculasModel = await _context.Peliculas.FindAsync(id);
            if (peliculasModel != null)
            {
                _context.Peliculas.Remove(peliculasModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool peliculasModelExists(int id)
        {
            return _context.Peliculas.Any(e => e.IdPelicula == id);
        }
    }
}
