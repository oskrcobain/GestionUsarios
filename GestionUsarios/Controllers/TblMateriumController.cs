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
    public class TblMateriumController : Controller
    {
        private readonly BDS_SysGestContext _context;

        public TblMateriumController(BDS_SysGestContext context)
        {
            _context = context;
        }

        // GET: TblMaterium
        public async Task<IActionResult> Index()
        {
            var bDS_SysGestContext = _context.TblMateria.Include(t => t.FkPgmIdProgramaNavigation);
            return View(await bDS_SysGestContext.ToListAsync());
        }

        // GET: TblMaterium/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblMaterium = await _context.TblMateria
                .Include(t => t.FkPgmIdProgramaNavigation)
                .FirstOrDefaultAsync(m => m.PkMtrIdMateria == id);
            if (tblMaterium == null)
            {
                return NotFound();
            }

            return View(tblMaterium);
        }

        // GET: TblMaterium/Create
        public IActionResult Create()
        {
            ViewData["FkPgmIdPrograma"] = new SelectList(_context.TblProgramas, "PkPgmIdPrograma", "PkPgmIdPrograma");
            return View();
        }

        // POST: TblMaterium/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MtrNombre,MtrModulo,MtrCurso,FkPgmIdPrograma,PkMtrIdMateria")] TblMaterium tblMaterium)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblMaterium);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkPgmIdPrograma"] = new SelectList(_context.TblProgramas, "PkPgmIdPrograma", "PkPgmIdPrograma", tblMaterium.FkPgmIdPrograma);
            return View(tblMaterium);
        }

        // GET: TblMaterium/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblMaterium = await _context.TblMateria.FindAsync(id);
            if (tblMaterium == null)
            {
                return NotFound();
            }
            ViewData["FkPgmIdPrograma"] = new SelectList(_context.TblProgramas, "PkPgmIdPrograma", "PkPgmIdPrograma", tblMaterium.FkPgmIdPrograma);
            return View(tblMaterium);
        }

        // POST: TblMaterium/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MtrNombre,MtrModulo,MtrCurso,FkPgmIdPrograma,PkMtrIdMateria")] TblMaterium tblMaterium)
        {
            if (id != tblMaterium.PkMtrIdMateria)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblMaterium);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblMateriumExists(tblMaterium.PkMtrIdMateria))
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
            ViewData["FkPgmIdPrograma"] = new SelectList(_context.TblProgramas, "PkPgmIdPrograma", "PkPgmIdPrograma", tblMaterium.FkPgmIdPrograma);
            return View(tblMaterium);
        }

        // GET: TblMaterium/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblMaterium = await _context.TblMateria
                .Include(t => t.FkPgmIdProgramaNavigation)
                .FirstOrDefaultAsync(m => m.PkMtrIdMateria == id);
            if (tblMaterium == null)
            {
                return NotFound();
            }

            return View(tblMaterium);
        }

        // POST: TblMaterium/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblMaterium = await _context.TblMateria.FindAsync(id);
            _context.TblMateria.Remove(tblMaterium);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblMateriumExists(int id)
        {
            return _context.TblMateria.Any(e => e.PkMtrIdMateria == id);
        }
    }
}
