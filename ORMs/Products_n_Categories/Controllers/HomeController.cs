using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Products_n_Categories.Models;

    namespace Products_n_Categories.Controllers     //be sure to use your own project's namespace!
    {
        public class HomeController : Controller   
        {
            private MyContext _context;

            public HomeController(MyContext context)
            {
                _context = context;
            }
            public indexWrapper WMod = new indexWrapper();

            [HttpGet("{id}")]
            public IActionResult Index(int? id)
            {
                WMod.oneCategory = _context.Categories
                .Include(ac => ac.ProductUnder)
                .ThenInclude(acc => acc.Product)
                .FirstOrDefault(c => c.CategoryId == id);

                WMod.ProductsList = _context.Products
                .Include(ip => ip.belongedCategory)
                .Where(ipw => !ipw.belongedCategory.Any(ap => ap.CategoryId == WMod.oneCategory.CategoryId))
                .ToList();
                return View("index", WMod);
            }

            [HttpPost("{id}/addproduct")]
            public IActionResult AddProduct(int id, indexWrapper addpro)
            {
                addpro.oneAssociation.CategoryId = id;
                _context.Add(addpro.oneAssociation);
                _context.SaveChanges();
                return RedirectToAction("index",new{id = id});
            }

            [HttpGet("products")]
            public IActionResult NewProductPage()
            {
                WMod.ProductsList = _context.Products.ToList();

                return View("products", WMod);
            }

            [HttpPost("newproduct")]
            public IActionResult NewProduct(indexWrapper newProduct)
            {
                if(ModelState.IsValid)
                {
                    _context.Add(newProduct.oneProduct);
                    _context.SaveChanges();
                    return RedirectToAction("NewProductPage");
                }
                return View();
            }

            [HttpGet("categories")]
            public IActionResult NewCategoryPage()
            {
                WMod.CategoryList = _context.Categories.ToList();

                return View("categories", WMod);
            }

            [HttpPost("newcategories")]
            public IActionResult NewCategory(indexWrapper newCategory)
            {
                if(ModelState.IsValid)
                {
                    _context.Add(newCategory.oneCategory);
                    _context.SaveChanges();
                    return RedirectToAction("NewCategoryPage");
                }
                return View();
            }

            [HttpGet("products/{id}")]
            public IActionResult Product(int? id)
            {
                
                WMod.oneProduct = _context.Products
                .Include(pp => pp.belongedCategory)
                .ThenInclude(pt => pt.Category)
                .FirstOrDefault(tp => tp.ProductId == id);

                WMod.CategoryList = _context.Categories
                .Include(c => c.ProductUnder)
                .Where(cc => !cc.ProductUnder.Any(cp => cp.ProductId == WMod.oneProduct.ProductId))
                .ToList();

                return View("showproduct", WMod);
            }

            [HttpPost("products/{id}/addcategories")]
            public IActionResult AddCategories(int id, indexWrapper addcategory)
            {
                addcategory.oneAssociation.ProductId = id;
                // WMod.oneProduct = _context.Products
                // .Include(op => op.belongedCategory)
                // .ThenInclude(top => top.Category)
                // .FirstOrDefault(o => o.ProductId == addcategory.oneProduct.ProductId);
                _context.Add(addcategory.oneAssociation);
                _context.SaveChanges();
                return RedirectToAction("Product", new{id = id});
            }

        
        }
    }