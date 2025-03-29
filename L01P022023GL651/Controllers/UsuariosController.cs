using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using L01P022023GL651.Models;

namespace L01P022023GL651.Controllers
{
    public class UsuariosController(BlogDbContext context) : Controller
    {
        private readonly BlogDbContext _context = context;

        public async Task<IActionResult> Index()
        {
            var usuarios = _context.Usuarios.Include(u => u.Rol);
            return View(await usuarios.ToListAsync());
        }

        public IActionResult Create()
        {
            ViewData["Roles"] = _context.Roles.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Roles"] = _context.Roles.ToList();
                return View(usuario);
            }

            _context.Add(usuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null) return NotFound();

            ViewData["Roles"] = _context.Roles.ToList();
            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Usuario usuario)
        {
            if (id != usuario.UsuarioId) return NotFound();
            if (!ModelState.IsValid)
            {
                ViewData["Roles"] = _context.Roles.ToList();
                return View(usuario);
            }

            _context.Update(usuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var usuario = await _context.Usuarios.FindAsync(id);
            return usuario == null ? NotFound() : View(usuario);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            _context.Usuarios.Remove(usuario!);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
