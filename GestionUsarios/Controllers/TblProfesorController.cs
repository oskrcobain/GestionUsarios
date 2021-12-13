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
    public class TblProfesorController : Controller
    {
        private readonly BDS_SysGestContext _context;

        public TblProfesorController(BDS_SysGestContext context)
        {
            _context = context;
        }

        // GET: TblProfesor
        public async Task<IActionResult> Index()
        {
            var bDS_SysGestContext = _context.TblProfesors.Include(t => t.FkPgmIdProgramaNavigation);
            return View(await bDS_SysGestContext.ToListAsync());
        }

        // GET: TblProfesor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblProfesor = await _context.TblProfesors
                .Include(t => t.FkPgmIdProgramaNavigation)
                .FirstOrDefaultAsync(m => m.PkPfsIdProfesor == id);
            if (tblProfesor == null)
            {
                return NotFound();
            }

            return View(tblProfesor);
        }

        // GET: TblProfesor/Create
        public IActionResult Create()
        {
            ViewData["FkPgmIdPrograma"] = new SelectList(_context.TblProgramas, "PkPgmIdPrograma", "PkPgmIdPrograma");
            return View();
        }

        // POST: TblProfesor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PfsNombres,PfsApellidos,PfsEspecialidad,PfsCargo,FkPgmIdPrograma,PkPfsIdProfesor")] TblProfesor tblProfesor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblProfesor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkPgmIdPrograma"] = new SelectList(_context.TblProgramas, "PkPgmIdPrograma", "PkPgmIdPrograma", tblProfesor.FkPgmIdPrograma);
            return View(tblProfesor);
        }

        // GET: TblProfesor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblProfesor = await _context.TblProfesors.FindAsync(id);
            if (tblProfesor == null)
            {
                return NotFound();
            }
            ViewData["FkPgmIdPrograma"] = new SelectList(_context.TblProgramas, "PkPgmIdPrograma", "PkPgmIdPrograma", tblProfesor.FkPgmIdPrograma);
            return View(tblProfesor);
        }

        // POST: TblProfesor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PfsNombres,PfsApellidos,PfsEspecialidad,PfsCargo,FkPgmIdPrograma,PkPfsIdProfesor")] TblProfesor tblProfesor)
        {
            if (id != tblProfesor.PkPfsIdProfesor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblProfesor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblProfesorExists(tblProfesor.PkPfsIdProfesor))
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
            ViewData["FkPgmIdPrograma"] = new SelectList(_context.TblProgramas, "PkPgmIdPrograma", "PkPgmIdPrograma", tblProfesor.FkPgmIdPrograma);
            return View(tblProfesor);
        }

        // GET: TblProfesor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblProfesor = await _context.TblProfesors
                .Include(t => t.FkPgmIdProgramaNavigation)
                .FirstOrDefaultAsync(m => m.PkPfsIdProfesor == id);
            if (tblProfesor == null)
            {
                return NotFound();
            }

            return View(tblProfesor);
        }

        // POST: TblProfesor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblProfesor = await _context.TblProfesors.FindAsync(id);
            _context.TblProfesors.Remove(tblProfesor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblProfesorExists(int id)
        {
            return _context.TblProfesors.Any(e => e.PkPfsIdProfesor == id);
        }
    }
}
