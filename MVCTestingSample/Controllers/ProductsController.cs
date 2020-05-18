using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCTestingSample.Models;
using MVCTestingSample.Models.Interfaces;

namespace MVCTestingSample.Controllers
{
    public class ProductsController : Controller
    {
        // Field
        // Go through interface to access DB
        private readonly IProductRespository _repo;

        // Constructor
        public ProductsController(IProductRespository repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            List<Product> products = await _repo.GetAllProductsAsync();
            return View(products);
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Product p)
        {
            if (ModelState.IsValid)
            {
                await _repo.AddProductAsync(p);
                return RedirectToAction("Index");
            }
            return View(p);
        }
    }
}