using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PERSEO.Models;
using Microsoft.AspNetCore.Authorization;

namespace PERSEO.Controllers
{
    [Authorize]
    public class VendedorsController : Controller
    {
        private readonly TiendaContext _context;

        public VendedorsController(TiendaContext context)
        {
            _context = context;
        }

        // GET: Vendedors
        public async Task<IActionResult> Index()
        {
              return View(await _context.Vendedors.ToListAsync());
        }

        // GET: Vendedors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Vendedors == null)
            {
                return NotFound();
            }

            var vendedor = await _context.Vendedors
                .FirstOrDefaultAsync(m => m.CodigoVendedor == id);
            if (vendedor == null)
            {
                return NotFound();
            }

            return View(vendedor);
        }

        // GET: Vendedors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vendedors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoVendedor,Dni,Nombre,Apellido,Direccion,Email")] Vendedor vendedor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vendedor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vendedor);
        }

        // GET: Vendedors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Vendedors == null)
            {
                return NotFound();
            }

            var vendedor = await _context.Vendedors.FindAsync(id);
            if (vendedor == null)
            {
                return NotFound();
            }
            return View(vendedor);
        }

        // POST: Vendedors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoVendedor,Dni,Nombre,Apellido,Direccion,Email")] Vendedor vendedor)
        {
            if (id != vendedor.CodigoVendedor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vendedor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendedorExists(vendedor.CodigoVendedor))
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
            return View(vendedor);
        }

        // GET: Vendedors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Vendedors == null)
            {
                return NotFound();
            }

            var vendedor = await _context.Vendedors
                .FirstOrDefaultAsync(m => m.CodigoVendedor == id);
            if (vendedor == null)
            {
                return NotFound();
            }

            return View(vendedor);
        }

        // POST: Vendedors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Vendedors == null)
            {
                return Problem("Entity set 'TiendaContext.Vendedors'  is null.");
            }
            var vendedor = await _context.Vendedors.FindAsync(id);
            if (vendedor != null)
            {
                _context.Vendedors.Remove(vendedor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendedorExists(int id)
        {
          return _context.Vendedors.Any(e => e.CodigoVendedor == id);
        }
    }
}
