using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FrimaxComedor.Models;

namespace FrimaxComedor.Controllers
{
    public class MenuLunesController : Controller
    {
        private readonly MenuContext _context;

        public MenuLunesController(MenuContext context)
        {
            _context = context;
        }

        // GET: MenuLunes
        public async Task<IActionResult> Index()
        {
            var menuContext = _context.MenuLunes.Include(m => m.IdNavigation);
            return View(await menuContext.ToListAsync());
        }

        // GET: MenuLunes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MenuLunes == null)
            {
                return NotFound();
            }

            var menuLune = await _context.MenuLunes
                .Include(m => m.IdNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (menuLune == null)
            {
                return NotFound();
            }

            return View(menuLune);
        }

        // GET: MenuLunes/Create
        public IActionResult Create()
        {
            ViewData["Id"] = new SelectList(_context.Registromenus, "Idmenu", "Idmenu");
            return View();
        }

        // POST: MenuLunes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Caldosa,Platillo1,Platillo2,Guarnicion1,Guarnicion2,Guarnicion3,Complemento,Postre,Agua")] MenuLune menuLune)
        {
            if (ModelState.IsValid)
            {
                _context.Add(menuLune);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.Registromenus, "Idmenu", "Idmenu", menuLune.Id);
            return View(menuLune);
        }

        // GET: MenuLunes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MenuLunes == null)
            {
                return NotFound();
            }

            var menuLune = await _context.MenuLunes.FindAsync(id);
            if (menuLune == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.Registromenus, "Idmenu", "Idmenu", menuLune.Id);
            return View(menuLune);
        }

        // POST: MenuLunes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Caldosa,Platillo1,Platillo2,Guarnicion1,Guarnicion2,Guarnicion3,Complemento,Postre,Agua")] MenuLune menuLune)
        {
            if (id != menuLune.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(menuLune);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenuLuneExists(menuLune.Id))
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
            ViewData["Id"] = new SelectList(_context.Registromenus, "Idmenu", "Idmenu", menuLune.Id);
            return View(menuLune);
        }

        // GET: MenuLunes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MenuLunes == null)
            {
                return NotFound();
            }

            var menuLune = await _context.MenuLunes
                .Include(m => m.IdNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (menuLune == null)
            {
                return NotFound();
            }

            return View(menuLune);
        }

        // POST: MenuLunes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MenuLunes == null)
            {
                return Problem("Entity set 'MenuContext.MenuLunes'  is null.");
            }
            var menuLune = await _context.MenuLunes.FindAsync(id);
            if (menuLune != null)
            {
                _context.MenuLunes.Remove(menuLune);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MenuLuneExists(int id)
        {
          return (_context.MenuLunes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
