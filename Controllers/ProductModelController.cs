using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using wepAppPractice.Data;
using wepAppPractice.Models;
using wepAppPractice.Repository;

namespace wepAppPractice.Controllers
{
    //Attribute routing
   // [Route("Product")]  
    public class ProductModelController : Controller
    {
        private readonly wepAppPracticeContext _context;
        private readonly IProductService _productService;

        public ProductModelController(wepAppPracticeContext context, IProductService productService)
        {
            _context = context;
            _productService = productService;
        }
        
        // GET: ProductModel
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProductModel.ToListAsync());

        }

        // GET: ProductModel/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var productModel = await _context.ProductModel
            //    .FirstOrDefaultAsync(m => m.Id == id);
            var productModel = _productService.GetProduct(id.Value);
            if (productModel == null)
            {
                return NotFound();
            }
            return View(productModel);
        }

        // GET: ProductModel/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductModel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] ProductModel productModel)
        {
            if (ModelState.IsValid)
                //here the IsValid provides the form validation from the entries we did in ProductModel.cs
            {
                _context.Add(productModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productModel);
        }

        // GET: ProductModel/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productModel = await _context.ProductModel.FindAsync(id);
            if (productModel == null)
            {
                return NotFound();
            }
            return View(productModel);
        }

        // POST: ProductModel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //Edit garda patch gareko
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] ProductModel productModel)
        {
            if (id != productModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductModelExists(productModel.Id))
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
            return View(productModel);
        }

        // GET: ProductModel/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productModel = await _context.ProductModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productModel == null)
            {
                return NotFound();
            }

            return View(productModel);
        }

        // POST: ProductModel/Delete/5
        [HttpPost, ActionName("Delete")]
        //HttpGet,post,patch,delete,put
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productModel = await _context.ProductModel.FindAsync(id);
            _context.ProductModel.Remove(productModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductModelExists(int id)
        {
            return _context.ProductModel.Any(e => e.Id == id);
        }
    }
}
