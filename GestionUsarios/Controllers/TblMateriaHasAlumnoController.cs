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
    public class TblMateriaHasAlumnoController : Controller
    {
        private readonly BDS_SysGestContext _context;

        public TblMateriaHasAlumnoController(BDS_SysGestContext context)
        {
            _context = context;
        }

        // GET: TblMateriaHasAlumno
        public async Task<IActionResult> Index()
        {
            var bDS_SysGestContext = _context.TblMateriaHasAlumnos.Include(t => t.FkAlmIdAlumnoNavigation).Include(t => t.FkMtrIdMateriaNavigation);
            return View(await bDS_SysGestContext.ToListAsync());
        }

        // GET: TblMateriaHasAlumno/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblMateriaHasAlumno = await _context.TblMateriaHasAlumnos
                .Include(t => t.FkAlmIdAlumnoNavigation)
                .Include(t => t.FkMtrIdMateriaNavigation)
                .FirstOrDefaultAsync(m => m.PkAlmHasMtrIdAlumnoHasMateria == id);
            if (tblMateriaHasAlumno == null)
            {
                return NotFound();
            }

            return View(tblMateriaHasAlumno);
        }

        // GET: TblMateriaHasAlumno/Create
        public IActionResult Create()
        {
            ViewData["FkAlmIdAlumno"] = new SelectList(_context.TblAlumnos, "PkAlmIdAlumno", "PkAlmIdAlumno");
            ViewData["FkMtrIdMateria"] = new SelectList(_context.TblMateria, "PkMtrIdMateria", "PkMtrIdMateria");
            return View();
        }

        // POST: TblMateriaHasAlumno/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FkMtrIdMateria,FkAlmIdAlumno,PkAlmHasMtrIdAlumnoHasMateria")] TblMateriaHasAlumno tblMateriaHasAlumno)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblMateriaHasAlumno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkAlmIdAlumno"] = new SelectList(_context.TblAlumnos, "PkAlmIdAlumno", "PkAlmIdAlumno", tblMateriaHasAlumno.FkAlmIdAlumno);
            ViewData["FkMtrIdMateria"] = new SelectList(_context.TblMateria, "PkMtrIdMateria", "PkMtrIdMateria", tblMateriaHasAlumno.FkMtrIdMateria);
            return View(tblMateriaHasAlumno);
        }

        // GET: TblMateriaHasAlumno/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblMateriaHasAlumno = await _context.TblMateriaHasAlumnos.FindAsync(id);
            if (tblMateriaHasAlumno == null)
            {
                return NotFound();
            }
            ViewData["FkAlmIdAlumno"] = new SelectList(_context.TblAlumnos, "PkAlmIdAlumno", "PkAlmIdAlumno", tblMateriaHasAlumno.FkAlmIdAlumno);
            ViewData["FkMtrIdMateria"] = new SelectList(_context.TblMateria, "PkMtrIdMateria", "PkMtrIdMateria", tblMateriaHasAlumno.FkMtrIdMateria);
            return View(tblMateriaHasAlumno);
        }

        // POST: TblMateriaHasAlumno/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FkMtrIdMateria,FkAlmIdAlumno,PkAlmHasMtrIdAlumnoHasMateria")] TblMateriaHasAlumno tblMateriaHasAlumno)
        {
            if (id != tblMateriaHasAlumno.PkAlmHasMtrIdAlumnoHasMateria)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblMateriaHasAlumno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblMateriaHasAlumnoExists(tblMateriaHasAlumno.PkAlmHasMtrIdAlumnoHasMateria))
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
            ViewData["FkAlmIdAlumno"] = new SelectList(_context.TblAlumnos, "PkAlmIdAlumno", "PkAlmIdAlumno", tblMateriaHasAlumno.FkAlmIdAlumno);
            ViewData["FkMtrIdMateria"] = new SelectList(_context.TblMateria, "PkMtrIdMateria", "PkMtrIdMateria", tblMateriaHasAlumno.FkMtrIdMateria);
            return View(tblMateriaHasAlumno);
        }

        // GET: TblMateriaHasAlumno/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblMateriaHasAlumno = await _context.TblMateriaHasAlumnos
                .Include(t => t.FkAlmIdAlumnoNavigation)
                .Include(t => t.FkMtrIdMateriaNavigation)
                .FirstOrDefaultAsync(m => m.PkAlmHasMtrIdAlumnoHasMateria == id);
            if (tblMateriaHasAlumno == null)
            {
                return NotFound();
            }

            return View(tblMateriaHasAlumno);
        }

        // POST: TblMateriaHasAlumno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblMateriaHasAlumno = await _context.TblMateriaHasAlumnos.FindAsync(id);
            _context.TblMateriaHasAlumnos.Remove(tblMateriaHasAlumno);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblMateriaHasAlumnoExists(int id)
        {
            return _context.TblMateriaHasAlumnos.Any(e => e.PkAlmHasMtrIdAlumnoHasMateria == id);
        }
    }
}
