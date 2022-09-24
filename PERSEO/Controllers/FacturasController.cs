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
    public class FacturasController : Controller
    {
        private readonly TiendaContext _context;

        public FacturasController(TiendaContext context)
        {
            _context = context;
        }

        // GET: Facturas
        public async Task<IActionResult> Index()
        {
            var tiendaContext = _context.Facturas.Include(f => f.ClienteNavigation).Include(f => f.ProductoNavigation).Include(f => f.VendedorNavigation);
            return View(await tiendaContext.ToListAsync());
        }

        // GET: Facturas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Facturas == null)
            {
                return NotFound();
            }

            var factura = await _context.Facturas
                .Include(f => f.ClienteNavigation)
                .Include(f => f.ProductoNavigation)
                .Include(f => f.VendedorNavigation)
                .FirstOrDefaultAsync(m => m.Factura1 == id);
            if (factura == null)
            {
                return NotFound();
            }

            return View(factura);
        }

        // GET: Facturas/Create
        public IActionResult Create()
        {
            ViewData["Cliente"] = new SelectList(_context.Clientes, "Dni", "Dni");
            ViewData["Producto"] = new SelectList(_context.Productos, "Codigo", "Codigo");
            ViewData["Vendedor"] = new SelectList(_context.Vendedors, "CodigoVendedor", "CodigoVendedor");
            return View();
        }

        // POST: Facturas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Factura1,Vendedor,Cliente,Producto,Fecha,Total")] Factura factura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(factura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Cliente"] = new SelectList(_context.Clientes, "Dni", "Dni", factura.Cliente);
            ViewData["Producto"] = new SelectList(_context.Productos, "Codigo", "Codigo", factura.Producto);
            ViewData["Vendedor"] = new SelectList(_context.Vendedors, "CodigoVendedor", "CodigoVendedor", factura.Vendedor);
            return View(factura);
        }

        // GET: Facturas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Facturas == null)
            {
                return NotFound();
            }

            var factura = await _context.Facturas.FindAsync(id);
            if (factura == null)
            {
                return NotFound();
            }
            ViewData["Cliente"] = new SelectList(_context.Clientes, "Dni", "Dni", factura.Cliente);
            ViewData["Producto"] = new SelectList(_context.Productos, "Codigo", "Codigo", factura.Producto);
            ViewData["Vendedor"] = new SelectList(_context.Vendedors, "CodigoVendedor", "CodigoVendedor", factura.Vendedor);
            return View(factura);
        }

        // POST: Facturas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Factura1,Vendedor,Cliente,Producto,Fecha,Total")] Factura factura)
        {
            if (id != factura.Factura1)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(factura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacturaExists(factura.Factura1))
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
            ViewData["Cliente"] = new SelectList(_context.Clientes, "Dni", "Dni", factura.Cliente);
            ViewData["Producto"] = new SelectList(_context.Productos, "Codigo", "Codigo", factura.Producto);
            ViewData["Vendedor"] = new SelectList(_context.Vendedors, "CodigoVendedor", "CodigoVendedor", factura.Vendedor);
            return View(factura);
        }

        // GET: Facturas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Facturas == null)
            {
                return NotFound();
            }

            var factura = await _context.Facturas
                .Include(f => f.ClienteNavigation)
                .Include(f => f.ProductoNavigation)
                .Include(f => f.VendedorNavigation)
                .FirstOrDefaultAsync(m => m.Factura1 == id);
            if (factura == null)
            {
                return NotFound();
            }

            return View(factura);
        }

        // POST: Facturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Facturas == null)
            {
                return Problem("Entity set 'TiendaContext.Facturas'  is null.");
            }
            var factura = await _context.Facturas.FindAsync(id);
            if (factura != null)
            {
                _context.Facturas.Remove(factura);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacturaExists(int id)
        {
          return _context.Facturas.Any(e => e.Factura1 == id);
        }
    }
}
