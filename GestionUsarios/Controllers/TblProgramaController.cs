using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestionUsarios.Models;

namespace GestionUsarios.Controllers
{
    public class TblProgramaController : Controller
    {
        private readonly BDS_SysGestContext _context;

        public TblProgramaController(BDS_SysGestContext context)
        {
            _context = context;
        }

        // GET: TblPrograma
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblProgramas.ToListAsync());
        }

        // GET: TblPrograma/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPrograma = await _context.TblProgramas
                .FirstOrDefaultAsync(m => m.PkPgmIdPrograma == id);
            if (tblPrograma == null)
            {
                return NotFound();
            }

            return View(tblPrograma);
        }

        // GET: TblPrograma/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblPrograma/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PgmNombre,PgmDuracion,PgmCosto,PgmAula,PkPgmIdPrograma")] TblPrograma tblPrograma)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblPrograma);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblPrograma);
        }

        // GET: TblPrograma/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPrograma = await _context.TblProgramas.FindAsync(id);
            if (tblPrograma == null)
            {
                return NotFound();
            }
            return View(tblPrograma);
        }

        // POST: TblPrograma/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PgmNombre,PgmDuracion,PgmCosto,PgmAula,PkPgmIdPrograma")] TblPrograma tblPrograma)
        {
            if (id != tblPrograma.PkPgmIdPrograma)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblPrograma);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblProgramaExists(tblPrograma.PkPgmIdPrograma))
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
            return View(tblPrograma);
        }

        // GET: TblPrograma/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPrograma = await _context.TblProgramas
                .FirstOrDefaultAsync(m => m.PkPgmIdPrograma == id);
            if (tblPrograma == null)
            {
                return NotFound();
            }

            return View(tblPrograma);
        }

        // POST: TblPrograma/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblPrograma = await _context.TblProgramas.FindAsync(id);
            _context.TblProgramas.Remove(tblPrograma);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblProgramaExists(int id)
        {
            return _context.TblProgramas.Any(e => e.PkPgmIdPrograma == id);
        }
    }
}
