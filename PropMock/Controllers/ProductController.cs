using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PropDatabaseCore;
using PropMockModels;

namespace PropMock.Controllers
{
    public class ProductController : Controller
    {
        private readonly PropDbContext _context;

        public ProductController(PropDbContext context)
        {
            _context = context;
        }

        // GET: Product
        public async Task<IActionResult> Index()
        {
            var propDbContext = _context.Products.Include(p => p.Order);
            return View(await propDbContext.ToListAsync());
        }

        // GET: Product/Details/5
        [HttpGet("FindOrder/{filenumber}")]
        public async Task<IActionResult> Details(int filenumber)
        {
            var product = await _context.Products
                .Include(p => p.Lien)
                .Include(p => p.Estoppel)
                .Include(p => p.Tax)
                .Include(p => p.CS)
                .Include(p => p.RT)
                .Where(o => o.filenumber == filenumber)
                .FirstOrDefaultAsync();
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            ViewData["orderNumber"] = new SelectList(_context.Orders, "ordernumber", "ordernumber");
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("filenumber,ProductType,OrderStatus,orderNumber")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["orderNumber"] = new SelectList(_context.Orders, "ordernumber", "ordernumber", product.orderNumber);
            return View(product);
        }

        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["orderNumber"] = new SelectList(_context.Orders, "ordernumber", "ordernumber", product.orderNumber);
            return View(product);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("filenumber,ProductType,OrderStatus,orderNumber")] Product product)
        {
            if (id != product.filenumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.filenumber))
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
            ViewData["orderNumber"] = new SelectList(_context.Orders, "ordernumber", "ordernumber", product.orderNumber);
            return View(product);
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Order)
                .FirstOrDefaultAsync(m => m.filenumber == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'PropDbContext.Products'  is null.");
            }
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
          return (_context.Products?.Any(e => e.filenumber == id)).GetValueOrDefault();
        }
    }
}
