using Microsoft.AspNetCore.Mvc;
using paraMvc.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using paraMvc.Data.ViewModels;
using paraMvc.Data.Services;
using System.Data.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;
using paraMvc.Models;

namespace paraMvc.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allProduct = await _service.GetAllAsync();
            return View(allProduct);
        }


        public async Task<IActionResult> Details(int id)
        {
            var productDetail = await _service.GetByIdAsync(id);
            return View(productDetail);
        }
        
        

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewProductVm product)
        {
            if (!ModelState.IsValid)
            {
               
                
                return View(product);
            }

            await _service.AddNewProductAsync(product);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var productDetail = await _service.GetByIdAsync(id);
            if (productDetail == null) return View("NotFound");

            var response = new NewProductVm()
            {
                Id = productDetail.Id,
                Name = productDetail.Name,
                Description = productDetail.Description,
                Price = productDetail.Price,
                ImageURL = productDetail.ImageURL,
                ProductCategory = productDetail.ProductCategory,

            };

            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewProductVm product)
        {
            if (id != product.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
               

                return View(product);
            }

            await _service.UpdateProductAsync(product);
            return RedirectToAction(nameof(Index));
        }

    }
}
 