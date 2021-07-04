using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Veterinaria.Data;
using Veterinaria.Models;

namespace Veterinaria.Controllers
{
    public class CitaController : Controller
    {
        private readonly VeterinariaContext _context;

        public CitaController(VeterinariaContext context)
        {
            _context = context;
        }

        // GET: Cita
        public async Task<IActionResult> Index()
        {
            var veterinariaContext = _context.Cita.Include(c => c.Mascota).Include(c => c.Medicamento).Include(c => c.Veterinario);
            return View(await veterinariaContext.ToListAsync());
        }

        // GET: Cita/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cita = await _context.Cita
                .Include(c => c.Mascota)
                .Include(c => c.Medicamento)
                .Include(c => c.Veterinario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cita == null)
            {
                return NotFound();
            }

            return View(cita);
        }

        // GET: Cita/Create
        public IActionResult Create()
        {
            ViewData["MascotaID"] = new SelectList(_context.Mascota, "Id", "Id");
            ViewData["MedicamentoID"] = new SelectList(_context.Medicamento, "Id", "Id");
            ViewData["VeterinarioID"] = new SelectList(_context.Veterinario, "Id", "Id");
            return View();
        }

        // POST: Cita/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fecha,Descripcion,MascotaID,VeterinarioID,MedicamentoID")] Cita cita)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cita);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MascotaID"] = new SelectList(_context.Mascota, "Id", "Id", cita.MascotaID);
            ViewData["MedicamentoID"] = new SelectList(_context.Medicamento, "Id", "Id", cita.MedicamentoID);
            ViewData["VeterinarioID"] = new SelectList(_context.Veterinario, "Id", "Id", cita.VeterinarioID);
            return View(cita);
        }

        // GET: Cita/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cita = await _context.Cita.FindAsync(id);
            if (cita == null)
            {
                return NotFound();
            }
            ViewData["MascotaID"] = new SelectList(_context.Mascota, "Id", "Id", cita.MascotaID);
            ViewData["MedicamentoID"] = new SelectList(_context.Medicamento, "Id", "Id", cita.MedicamentoID);
            ViewData["VeterinarioID"] = new SelectList(_context.Veterinario, "Id", "Id", cita.VeterinarioID);
            return View(cita);
        }

        // POST: Cita/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Fecha,Descripcion,MascotaID,VeterinarioID,MedicamentoID")] Cita cita)
        {
            if (id != cita.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cita);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CitaExists(cita.Id))
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
            ViewData["MascotaID"] = new SelectList(_context.Mascota, "Id", "Id", cita.MascotaID);
            ViewData["MedicamentoID"] = new SelectList(_context.Medicamento, "Id", "Id", cita.MedicamentoID);
            ViewData["VeterinarioID"] = new SelectList(_context.Veterinario, "Id", "Id", cita.VeterinarioID);
            return View(cita);
        }

        // GET: Cita/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cita = await _context.Cita
                .Include(c => c.Mascota)
                .Include(c => c.Medicamento)
                .Include(c => c.Veterinario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cita == null)
            {
                return NotFound();
            }

            return View(cita);
        }

        // POST: Cita/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cita = await _context.Cita.FindAsync(id);
            _context.Cita.Remove(cita);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CitaExists(int id)
        {
            return _context.Cita.Any(e => e.Id == id);
        }
    }
}
