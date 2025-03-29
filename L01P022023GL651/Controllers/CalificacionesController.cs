using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using L01P022023GL651.Models;

namespace L01P022023GL651.Controllers
{
    public class CalificacionesController(BlogDbContext context) : Controller
    {
        private readonly BlogDbContext _context = context;

        public async Task<IActionResult> Index()
        {
            var calificaciones = _context.Calificaciones.Include(c => c.Usuario).Include(c => c.Publicacion);
            return View(await calificaciones.ToListAsync());
        }

        public IActionResult Create()
        {
            ViewData["Usuarios"] = _context.Usuarios.ToList();
            ViewData["Publicaciones"] = _context.Publicaciones.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Calificacion calificacion)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Usuarios"] = _context.Usuarios.ToList();
                ViewData["Publicaciones"] = _context.Publicaciones.ToList();
                return View(calificacion);
            }

            _context.Add(calificacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var calificacion = await _context.Calificaciones.FindAsync(id);
            return calificacion == null ? NotFound() : View(calificacion);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var calificacion = await _context.Calificaciones.FindAsync(id);
            _context.Calificaciones.Remove(calificacion!);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
