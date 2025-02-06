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
    public class cinesController : Controller
    {
        private readonly SupercinesAppContext _context;

        public cinesController(SupercinesAppContext context)
        {
            _context = context;
        }

        // GET: cines
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cines.ToListAsync());
        }

        // GET: cines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cinesModel = await _context.Cines
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cinesModel == null)
            {
                return NotFound();
            }

            return View(cinesModel);
        }

        // GET: cines/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: cines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Direccion,Telefono")] cinesModel cinesModel)
        {
            //if (ModelState.IsValid)
            //{
                _context.Add(cinesModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            //}
            return View(cinesModel);
        }

        // GET: cines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cinesModel = await _context.Cines.FindAsync(id);
            if (cinesModel == null)
            {
                return NotFound();
            }
            return View(cinesModel);
        }

        // POST: cines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Direccion,Telefono")] cinesModel cinesModel)
        {
            if (id != cinesModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cinesModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!cinesModelExists(cinesModel.Id))
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
            return View(cinesModel);
        }

        // GET: cines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cinesModel = await _context.Cines
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cinesModel == null)
            {
                return NotFound();
            }

            return View(cinesModel);
        }

        // POST: cines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cinesModel = await _context.Cines.FindAsync(id);
            if (cinesModel != null)
            {
                _context.Cines.Remove(cinesModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool cinesModelExists(int id)
        {
            return _context.Cines.Any(e => e.Id == id);
        }
    }
}
