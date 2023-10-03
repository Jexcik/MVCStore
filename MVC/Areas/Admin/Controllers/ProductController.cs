﻿using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductsRepository productsRepository;
        public ProductController(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }
        public IActionResult Index()
        {
            var products = productsRepository.GetAll();
            return View(products);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(ProductViewModel newProduct)
        {
            var products=productsRepository.GetAll();
            products.Add(new Product(newProduct.Name,",ka",1234,1234,"egftg","fgfhbgjh"));
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            Product product = productsRepository.TryGetById(id);
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(ProductViewModel product, int id)
        {
            Product currentProduct=productsRepository.TryGetById(id);
            currentProduct.Name = product.Name;
            currentProduct.Cost = product.Cost;
            currentProduct.ImagePath = product.ImagePath;
            currentProduct.Description = product.Description;
            return RedirectToAction("Index");
        }
        public IActionResult Del(int id)
        {
            Product product = productsRepository.TryGetById(id);
            productsRepository.Del(product);
            return RedirectToAction("Index");
        }
    }
}
