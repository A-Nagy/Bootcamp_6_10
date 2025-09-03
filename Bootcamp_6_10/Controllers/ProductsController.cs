using Bootcamp_6_10.Data;
using Bootcamp_6_10.Dtos;
using Bootcamp_6_10.Models;
using Bootcamp_6_10.Repository.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bootcamp_6_10.Controllers
{
    public class ProductsController : Controller
    {
 
        private readonly IUnitOfWork _unitOfWork;
        public ProductsController(IUnitOfWork unitOfWork )
        {
            _unitOfWork=unitOfWork;
        }

        // GET: Products
        public IActionResult  Index()
        {
            IEnumerable<Product> products = _unitOfWork.Products.FindAllProducts();
            return View(products);
        }

        //public IActionResult GetAllProduct()
        //{
        //    IEnumerable<ProductDto> products = _context.Products.Include(p => p.Categoty)
        //                                                     .AsNoTracking()
        //                                                     .Select(p => new ProductDto
        //                                                     {
        //                                                         ProductId = p.ProductId,
        //                                                         ProductName = p.ProductName,
        //                                                         ProductDescription = p.ProductDescription,
        //                                                         ProductPrice = p.ProductPrice,
        //                                                         ProductQTY = p.ProductQTY,
        //                                                         CategotyId = p.CategotyId,
        //                                                         CategotyName = p.Categoty.Name
        //                                                     }).ToList();
        //    return Ok(products);
        //}

        // GET: Products/Details/5
       

        private void CreateSelectList() 
        {
            IEnumerable<Categoty> categoties = _unitOfWork.Categories.FindAll(); 
            SelectList selectlist = new SelectList(categoties, "Id", "Name", 0);
            ViewBag.categoties = selectlist;
        }

        // GET: Products/Create
        public IActionResult Create()
        {
             CreateSelectList();
             return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create( Product product)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Products.Insert(product);
                TempData["Create"] = "Products Added SuccessFully";
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            CreateSelectList();

            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProductName,ProductDescription,ProductPrice,ProductQTY,CategotyId")] Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.Products.Update(product);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["Update"] = "Product Updated SuccessFully";

                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _repoProduct.Delete(product);
                TempData["Remove"] = "Removed SuccessFully";
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }
    }
}
