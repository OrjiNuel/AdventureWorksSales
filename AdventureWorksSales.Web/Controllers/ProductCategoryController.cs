using AdventureWorksSales.Core;
using AdventureWorksSales.Core.Abstract;
using AdventureWorksSales.Web.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AdventureWorksSales.Web.Controllers
{
    public class ProductCategoryController : Controller
    {
        private IProductCategoryRepository _prodCategory;
        public int pageSize = 5;
        public ProductCategoryController(IProductCategoryRepository productCategory)
        {
            _prodCategory = productCategory;
        }
        // GET: ProductCategory
        public ActionResult Index(int page = 1)
        {
            var productCategories = _prodCategory.Query()
                .ToList();

            var prod = new ProductCategoryViewModel
            {
                ProductCategories = productCategories
                .OrderBy(p => p.ProductCategoryID)
                .Skip((page - 1) * pageSize)
                .Take(pageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = productCategories.Count()
                },
            };

            return View(prod);
        }

        public ActionResult Create()
        {
            return View(new ProductCategory());
        }

        [HttpPost]
        public async Task<ActionResult> Create(string Name)
        {
            try
            {
                var data = new ProductCategory
                {
                    Name = Name,
                    ModifiedDate = DateTime.Now,
                    rowguid = Guid.NewGuid()
                };

                await _prodCategory.InsertAsync(data);
                TempData["message"] = string.Format("{0} has been created!", Name);

                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                ModelState.AddModelError($"{ex}", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                return View();
            }
            
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            ProductCategory productCategory = await _prodCategory.GetAsync(id);
            return View(productCategory);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(ProductCategory productCategory)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _prodCategory.UpdateAsync(productCategory);

                    TempData["message"] = string.Format("{0} has been updated!", productCategory.Name);

                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(productCategory);
        }

    }
}