﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using L01P022023GL651.Models;

namespace L01P022023GL651.Controllers
{
    public class PublicacionesController(BlogDbContext context) : Controller
    {
        private readonly BlogDbContext _context = context;

        public async Task<IActionResult> Index()
        {
            var publicaciones = _context.Publicaciones.Include(p => p.Usuario);
            return View(await publicaciones.ToListAsync());
        }

        public IActionResult Create()
        {
            ViewData["Usuarios"] = _context.Usuarios.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Publicacion publicacion)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Usuarios"] = _context.Usuarios.ToList();
                return View(publicacion);
            }

            _context.Add(publicacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var publicacion = await _context.Publicaciones.FindAsync(id);
            if (publicacion == null) return NotFound();

            ViewData["Usuarios"] = _context.Usuarios.ToList();
            return View(publicacion);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Publicacion publicacion)
        {
            if (id != publicacion.PublicacionId) return NotFound();
            if (!ModelState.IsValid)
            {
                ViewData["Usuarios"] = _context.Usuarios.ToList();
                return View(publicacion);
            }

            _context.Update(publicacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var publicacion = await _context.Publicaciones.FindAsync(id);
            return publicacion == null ? NotFound() : View(publicacion);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var publicacion = await _context.Publicaciones.FindAsync(id);
            _context.Publicaciones.Remove(publicacion!);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
