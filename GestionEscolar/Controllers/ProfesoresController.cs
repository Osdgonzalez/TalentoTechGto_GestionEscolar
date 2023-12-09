﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestionEscolar.Models;

namespace GestionEscolar.Controllers
{
    public class ProfesoresController : Controller
    {
        private readonly GestionEscolarContext _context;

        public ProfesoresController(GestionEscolarContext context)
        {
            _context = context;
        }

        // GET: Profesores
        public async Task<IActionResult> Index()
        {
              return _context.Profesores != null ? 
                          View(await _context.Profesores.ToListAsync()) :
                          Problem("Entity set 'GestionEscolarContext.Profesores'  is null.");
        }

        // GET: Profesores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Profesores == null)
            {
                return NotFound();
            }

            var profesore = await _context.Profesores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profesore == null)
            {
                return NotFound();
            }

            return View(profesore);
        }

        // GET: Profesores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Profesores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Telefono")] Profesore profesore)
        {
            if (ModelState.IsValid)
            {
                _context.Add(profesore);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(profesore);
        }

        // GET: Profesores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Profesores == null)
            {
                return NotFound();
            }

            var profesore = await _context.Profesores.FindAsync(id);
            if (profesore == null)
            {
                return NotFound();
            }
            return View(profesore);
        }

        // POST: Profesores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Telefono")] Profesore profesore)
        {
            if (id != profesore.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profesore);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfesoreExists(profesore.Id))
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
            return View(profesore);
        }

        // GET: Profesores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Profesores == null)
            {
                return NotFound();
            }

            var profesore = await _context.Profesores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profesore == null)
            {
                return NotFound();
            }

            return View(profesore);
        }

        // POST: Profesores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Profesores == null)
            {
                return Problem("Entity set 'GestionEscolarContext.Profesores'  is null.");
            }
            var profesore = await _context.Profesores.FindAsync(id);
            if (profesore != null)
            {
                _context.Profesores.Remove(profesore);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfesoreExists(int id)
        {
          return (_context.Profesores?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
