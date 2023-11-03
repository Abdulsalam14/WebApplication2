using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Entities;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public ProductController(IProductService productService, IWebHostEnvironment hostingEnvironment)
        {
            _productService = productService;
            _hostingEnvironment = hostingEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _productService.GetAllProductsAsync();
            var vm = new ProductViewModel()
            {
                Products = data
            };
            return View(vm);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var vm = new ProductAddViewModel
            {
                Product = new Product()
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductAddViewModel vm, IFormFile productImage)
        {
            if (ModelState.IsValid)
            {
                if (productImage != null && productImage.Length > 0)
                {
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + productImage.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await productImage.CopyToAsync(fileStream);
                    }
                    vm.Product.ImagePath = "/images/" + uniqueFileName;

                    await _productService.AddProductAsync(vm.Product);
                    return RedirectToAction("Index");
                }
            }
            return View(vm);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var DeletedProduct = await _productService.GetProductByIdAsync(id);
            if (DeletedProduct != null)
            {
                await _productService.DeleteProductAsync(DeletedProduct);
            }
            string webRootPath = _hostingEnvironment.WebRootPath;
            string deletefilePath = Path.Combine(webRootPath, DeletedProduct.ImagePath.TrimStart('/'));

            if (System.IO.File.Exists(deletefilePath))
            {
                System.IO.File.Delete(deletefilePath);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var updatedProduct = await _productService.GetProductByIdAsync(id);
            var vm = new ProductUpdateViewModel
            {
                Product = updatedProduct
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductUpdateViewModel vm, IFormFile newImage)
        {
            if (ModelState.IsValid)
            {
                if (newImage != null && newImage.Length > 0)
                {
                    string webRootPath = _hostingEnvironment.WebRootPath;
                    string deletefilePath = Path.Combine(webRootPath, vm.Product.ImagePath.TrimStart('/'));

                    if (System.IO.File.Exists(deletefilePath))
                    {
                        System.IO.File.Delete(deletefilePath);
                    }


                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + newImage.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await newImage.CopyToAsync(fileStream);
                    }


                    vm.Product.ImagePath = "/images/" + uniqueFileName;
                }
                await _productService.UpdateProductAsync(vm.Product);
                return RedirectToAction("Index");
            }
            return View(vm);
        }


    }
}
