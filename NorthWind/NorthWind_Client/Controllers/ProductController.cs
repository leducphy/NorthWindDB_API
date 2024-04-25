using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NorthWind_Client.Models;
using NorthWind_Client.Services;

namespace NorthWind_Client.Controllers
{
    public class ProductController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new ClientService(HttpContext);
            List<ProductResponse>? listProduct =
                await client.GetAll<List<ProductResponse>>($"api/Product");
            if (listProduct != null) ViewBag.Products = listProduct;
            return View();
        }

        [HttpGet, Authorize(Roles = "User")]
        public async Task<IActionResult> Update(Guid id)
        {
            var client = new ClientService(HttpContext);
            var res = await client.GetAll<ProductResponse>($"api/Product/{id}");
            var listcate = await client.GetAll<List<CategoryDTO>>($"api/Category");
            
            if (res != null)
            {
                ViewBag.Product = res;
            }

            if (listcate != null)
            {
                ViewBag.Categories = listcate;
            }
            return View(res);

        }

        [HttpPost, Authorize(Roles = "User")]
        public async Task<IActionResult> Update(ProductUpdateRequest product, Guid productid)
        {
            var client = new ClientService(HttpContext);
            var res = await client.Put($"api/Product/{productid}", product);
            
            List<ProductResponse>? listProduct =
                await client.GetAll<List<ProductResponse>>($"api/Product");
            if (listProduct != null) ViewBag.Products = listProduct;
            return View("Index");
        }
        
        [HttpGet, Authorize(Roles = "User")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var client = new ClientService(HttpContext);
            var res = await client.Delete($"api/Product/{id}", "");
        
            List<ProductResponse>? listProduct =
                await client.GetAll<List<ProductResponse>>($"api/Product");
            if (listProduct != null) ViewBag.Products = listProduct;
            return View("Index");
        }
        
    }
}
