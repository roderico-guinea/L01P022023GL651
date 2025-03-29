using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using L01P022023GL651.Models;

namespace L01P022023GL651.Controllers
{
    public class ComentariosController(BlogDbContext context) : Controller
    {
        private readonly BlogDbContext _context = context;

        public async Task<IActionResult> Index()
        {
            var comentarios = _context.Comentarios.Include(c => c.Usuario).Include(c => c.Publicacion);
            return View(await comentarios.ToListAsync());
        }

        public IActionResult Create()
        {
            ViewData["Usuarios"] = _context.Usuarios.ToList();
            ViewData["Publicaciones"] = _context.Publicaciones.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Comentario comentario)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Usuarios"] = _context.Usuarios.ToList();
                ViewData["Publicaciones"] = _context.Publicaciones.ToList();
                return View(comentario);
            }

            _context.Add(comentario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var comentario = await _context.Comentarios.FindAsync(id);
            return comentario == null ? NotFound() : View(comentario);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comentario = await _context.Comentarios.FindAsync(id);
            _context.Comentarios.Remove(comentario!);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
