using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestionEscolar.Models;

namespace GestionEscolar.Controllers
{
    public class AlumnosMateriasController : Controller
    {
        private readonly GestionEscolarContext _context;

        public AlumnosMateriasController(GestionEscolarContext context)
        {
            _context = context;
        }

        // GET: AlumnosMaterias
        public async Task<IActionResult> Index()
        {
            var gestionEscolarContext = _context.AlumnosMaterias.Include(a => a.IdAlumnoNavigation).Include(a => a.IdCalificacionNavigation).Include(a => a.IdMateriaNavigation);
            return View(await gestionEscolarContext.ToListAsync());
        }

        // GET: AlumnosMaterias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AlumnosMaterias == null)
            {
                return NotFound();
            }

            var alumnosMateria = await _context.AlumnosMaterias
                .Include(a => a.IdAlumnoNavigation)
                .Include(a => a.IdCalificacionNavigation)
                .Include(a => a.IdMateriaNavigation)
                .FirstOrDefaultAsync(m => m.IdAlumno == id);
            if (alumnosMateria == null)
            {
                return NotFound();
            }

            return View(alumnosMateria);
        }

        // GET: AlumnosMaterias/Create
        public IActionResult Create()
        {
            ViewData["IdAlumno"] = new SelectList(_context.Alumnos, "Id", "Id");
            ViewData["IdCalificacion"] = new SelectList(_context.Calificaciones, "Id", "Id");
            ViewData["IdMateria"] = new SelectList(_context.Materias, "Id", "Id");
            return View();
        }

        // POST: AlumnosMaterias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAlumno,IdMateria,IdCalificacion")] AlumnosMateria alumnosMateria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alumnosMateria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAlumno"] = new SelectList(_context.Alumnos, "Id", "Id", alumnosMateria.IdAlumno);
            ViewData["IdCalificacion"] = new SelectList(_context.Calificaciones, "Id", "Id", alumnosMateria.IdCalificacion);
            ViewData["IdMateria"] = new SelectList(_context.Materias, "Id", "Id", alumnosMateria.IdMateria);
            return View(alumnosMateria);
        }

        // GET: AlumnosMaterias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AlumnosMaterias == null)
            {
                return NotFound();
            }

            var alumnosMateria = await _context.AlumnosMaterias.FindAsync(id);
            if (alumnosMateria == null)
            {
                return NotFound();
            }
            ViewData["IdAlumno"] = new SelectList(_context.Alumnos, "Id", "Id", alumnosMateria.IdAlumno);
            ViewData["IdCalificacion"] = new SelectList(_context.Calificaciones, "Id", "Id", alumnosMateria.IdCalificacion);
            ViewData["IdMateria"] = new SelectList(_context.Materias, "Id", "Id", alumnosMateria.IdMateria);
            return View(alumnosMateria);
        }

        // POST: AlumnosMaterias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAlumno,IdMateria,IdCalificacion")] AlumnosMateria alumnosMateria)
        {
            if (id != alumnosMateria.IdAlumno)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alumnosMateria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlumnosMateriaExists(alumnosMateria.IdAlumno))
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
            ViewData["IdAlumno"] = new SelectList(_context.Alumnos, "Id", "Id", alumnosMateria.IdAlumno);
            ViewData["IdCalificacion"] = new SelectList(_context.Calificaciones, "Id", "Id", alumnosMateria.IdCalificacion);
            ViewData["IdMateria"] = new SelectList(_context.Materias, "Id", "Id", alumnosMateria.IdMateria);
            return View(alumnosMateria);
        }

        // GET: AlumnosMaterias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AlumnosMaterias == null)
            {
                return NotFound();
            }

            var alumnosMateria = await _context.AlumnosMaterias
                .Include(a => a.IdAlumnoNavigation)
                .Include(a => a.IdCalificacionNavigation)
                .Include(a => a.IdMateriaNavigation)
                .FirstOrDefaultAsync(m => m.IdAlumno == id);
            if (alumnosMateria == null)
            {
                return NotFound();
            }

            return View(alumnosMateria);
        }

        // POST: AlumnosMaterias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AlumnosMaterias == null)
            {
                return Problem("Entity set 'GestionEscolarContext.AlumnosMaterias'  is null.");
            }
            var alumnosMateria = await _context.AlumnosMaterias.FindAsync(id);
            if (alumnosMateria != null)
            {
                _context.AlumnosMaterias.Remove(alumnosMateria);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlumnosMateriaExists(int id)
        {
          return (_context.AlumnosMaterias?.Any(e => e.IdAlumno == id)).GetValueOrDefault();
        }
    }
}
