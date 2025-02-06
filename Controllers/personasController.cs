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
    public class personasController : Controller
    {
        private readonly SupercinesAppContext _context;

        public personasController(SupercinesAppContext context)
        {
            _context = context;
        }

        // GET: personas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Personas.ToListAsync());
        }

        // GET: personas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personasModel = await _context.Personas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personasModel == null)
            {
                return NotFound();
            }

            return View(personasModel);
        }

        // GET: personas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: personas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Nacionalidad,CantidadPeliculas")] personasModel personasModel)
        {
            //if (ModelState.IsValid)
            //{
                _context.Add(personasModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            //}
            return View(personasModel);
        }

        // GET: personas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personasModel = await _context.Personas.FindAsync(id);
            if (personasModel == null)
            {
                return NotFound();
            }
            return View(personasModel);
        }

        // POST: personas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Nacionalidad,CantidadPeliculas")] personasModel personasModel)
        {
            if (id != personasModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personasModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!personasModelExists(personasModel.Id))
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
            return View(personasModel);
        }

        // GET: personas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personasModel = await _context.Personas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personasModel == null)
            {
                return NotFound();
            }

            return View(personasModel);
        }

        // POST: personas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personasModel = await _context.Personas.FindAsync(id);
            if (personasModel != null)
            {
                _context.Personas.Remove(personasModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool personasModelExists(int id)
        {
            return _context.Personas.Any(e => e.Id == id);
        }
    }
}
