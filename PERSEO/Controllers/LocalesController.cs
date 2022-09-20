using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PERSEO.Models;

namespace PERSEO.Controllers
{
    public class LocalesController : Controller
    {
        private readonly TiendaContext _context;

        public LocalesController(TiendaContext context)
        {
            _context = context;
        }

        // GET: Locales
        public async Task<IActionResult> Index()
        {
            var tiendaContext = _context.Locales.Include(l => l.CodigoProductoNavigation).Include(l => l.VendedorNavigation);
            return View(await tiendaContext.ToListAsync());
        }

        // GET: Locales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Locales == null)
            {
                return NotFound();
            }

            var locale = await _context.Locales
                .Include(l => l.CodigoProductoNavigation)
                .Include(l => l.VendedorNavigation)
                .FirstOrDefaultAsync(m => m.Movimiento == id);
            if (locale == null)
            {
                return NotFound();
            }

            return View(locale);
        }

        // GET: Locales/Create
        public IActionResult Create()
        {
            ViewData["CodigoProducto"] = new SelectList(_context.Productos, "Codigo", "Codigo");
            ViewData["Vendedor"] = new SelectList(_context.Vendedors, "CodigoVendedor", "CodigoVendedor");
            return View();
        }

        // POST: Locales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Movimiento,NLocal,Direccion,Telefono,CodigoProducto,Vendedor")] Locale locale)
        {
            if (ModelState.IsValid)
            {
                _context.Add(locale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodigoProducto"] = new SelectList(_context.Productos, "Codigo", "Codigo", locale.CodigoProducto);
            ViewData["Vendedor"] = new SelectList(_context.Vendedors, "CodigoVendedor", "CodigoVendedor", locale.Vendedor);
            return View(locale);
        }

        // GET: Locales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Locales == null)
            {
                return NotFound();
            }

            var locale = await _context.Locales.FindAsync(id);
            if (locale == null)
            {
                return NotFound();
            }
            ViewData["CodigoProducto"] = new SelectList(_context.Productos, "Codigo", "Codigo", locale.CodigoProducto);
            ViewData["Vendedor"] = new SelectList(_context.Vendedors, "CodigoVendedor", "CodigoVendedor", locale.Vendedor);
            return View(locale);
        }

        // POST: Locales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Movimiento,NLocal,Direccion,Telefono,CodigoProducto,Vendedor")] Locale locale)
        {
            if (id != locale.Movimiento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(locale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocaleExists(locale.Movimiento))
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
            ViewData["CodigoProducto"] = new SelectList(_context.Productos, "Codigo", "Codigo", locale.CodigoProducto);
            ViewData["Vendedor"] = new SelectList(_context.Vendedors, "CodigoVendedor", "CodigoVendedor", locale.Vendedor);
            return View(locale);
        }

        // GET: Locales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Locales == null)
            {
                return NotFound();
            }

            var locale = await _context.Locales
                .Include(l => l.CodigoProductoNavigation)
                .Include(l => l.VendedorNavigation)
                .FirstOrDefaultAsync(m => m.Movimiento == id);
            if (locale == null)
            {
                return NotFound();
            }

            return View(locale);
        }

        // POST: Locales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Locales == null)
            {
                return Problem("Entity set 'TiendaContext.Locales'  is null.");
            }
            var locale = await _context.Locales.FindAsync(id);
            if (locale != null)
            {
                _context.Locales.Remove(locale);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocaleExists(int id)
        {
          return _context.Locales.Any(e => e.Movimiento == id);
        }
    }
}
