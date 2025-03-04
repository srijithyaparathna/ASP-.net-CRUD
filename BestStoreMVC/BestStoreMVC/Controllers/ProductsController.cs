using BestStoreMVC.Models;
using BestStoreMVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace BestStoreMVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext context;

        public ProductsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        // 📌 GET: List of Products
        public IActionResult Index()
        {
            var products = context.Products.ToList();
            return View(products);
        }

        // 📌 GET: Create Product Form
        public IActionResult Create()
        {
            return View();
        }

        // 📌 POST: Create a New Product
        [HttpPost]
        public IActionResult Create(ProductDto productDto)
        {
            if (productDto.ImageFileName == null || productDto.ImageFileName.Length == 0)
            {
                ModelState.AddModelError("ImageFile", "The image file is required.");
            }

            if (!ModelState.IsValid)
            {
                return View(productDto);
            }

            // Handle Image Upload
            string fileName = "";
            if (productDto.ImageFileName != null)
            {
                string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/products");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                fileName = Guid.NewGuid().ToString() + Path.GetExtension(productDto.ImageFileName.FileName);
                string filePath = Path.Combine(uploadsFolder, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    productDto.ImageFileName.CopyTo(fileStream);
                }
            }

            var product = new Product
            {
                Name = productDto.Name,
                Brand = productDto.Brand,
                Category = productDto.Category,
                Price = productDto.Price,
                Description = productDto.Description,
                ImageFileName = fileName,
                CreatedAt = DateTime.Now
            };

            context.Products.Add(product);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        // 📌 GET: Edit Product Form
        public IActionResult Edit(int id)
        {
            var product = context.Products.Find(id);
            if (product == null) return NotFound();

            var productDto = new ProductDto
            {
                Name = product.Name,
                Brand = product.Brand,
                Category = product.Category,
                Price = product.Price,
                Description = product.Description
            };

            return View(productDto);
        }

        // 📌 POST: Update a Product
        [HttpPost]
        public IActionResult Edit(int id, ProductDto productDto)
        {
            var product = context.Products.Find(id);
            if (product == null) return NotFound();

            if (!ModelState.IsValid)
            {
                return View(productDto);
            }

            // Handle Image Update
            if (productDto.ImageFileName != null)
            {
                string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/products");
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(productDto.ImageFileName.FileName);
                string filePath = Path.Combine(uploadsFolder, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    productDto.ImageFileName.CopyTo(fileStream);
                }

                product.ImageFileName = fileName;
            }

            product.Name = productDto.Name;
            product.Brand = productDto.Brand;
            product.Category = productDto.Category;
            product.Price = productDto.Price;
            product.Description = productDto.Description;

            context.Products.Update(product);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        // 📌 POST: Delete Product Immediately (No View)
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = context.Products.Find(id);
            if (product == null) return NotFound();

            // Delete image file from server
            if (!string.IsNullOrEmpty(product.ImageFileName))
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/products", product.ImageFileName);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
            }

            context.Products.Remove(product);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
