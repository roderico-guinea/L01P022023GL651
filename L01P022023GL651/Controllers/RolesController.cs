using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using L01P022023GL651.Models;

namespace L01P022023GL651.Controllers
{
    public class RolesController(BlogDbContext context) : Controller
    {
        private readonly BlogDbContext _context = context;

        public async Task<IActionResult> Index() => View(await _context.Roles.ToListAsync());

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Rol rol)
        {
            if (!ModelState.IsValid) return View(rol);

            _context.Add(rol);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var rol = await _context.Roles.FindAsync(id);
            return rol == null ? NotFound() : View(rol);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Rol rol)
        {
            if (id != rol.RolId) return NotFound();
            if (!ModelState.IsValid) return View(rol);

            _context.Update(rol);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var rol = await _context.Roles.FindAsync(id);
            return rol == null ? NotFound() : View(rol);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rol = await _context.Roles.FindAsync(id);
            _context.Roles.Remove(rol!);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
