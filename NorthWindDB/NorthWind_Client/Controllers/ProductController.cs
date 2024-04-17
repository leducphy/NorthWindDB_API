using Microsoft.AspNetCore.Mvc;
using NorthWind_Client.Models;
using NorthWind_Client.Services;

namespace NorthWind_Client.Controllers;

public class ProductController : Controller
{
    // GET
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var client = new ClientService(HttpContext);
        List<Response.CategoryDTO>? listCategory = await client.GetAll<List<Response.CategoryDTO>>("/api/Category");
        List<Response.ProductResponse>? listProduct =
            await client.GetAll<List<Response.ProductResponse>>($"api/Products");
        if (listProduct != null) ViewBag.Products = listProduct;
        if (listCategory != null) ViewBag.Categories = listCategory;
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> GetByCategory(int id)
    {
        List<Response.ProductResponse>? listProduct;
        var client = new ClientService(HttpContext);
        List<Response.CategoryDTO>? listCategory = await client.GetAll<List<Response.CategoryDTO>>("/api/Category");
        if (id == 0)
        {
            listProduct =
                await client.GetAll<List<Response.ProductResponse>>($"api/Products");
        }

        listProduct =
            await client.GetAll<List<Response.ProductResponse>>($"api/Products/Category/{id}");
        if (listProduct != null) ViewBag.Products = listProduct;
        if (listCategory != null) ViewBag.Categories = listCategory;
        return View("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Add()
    {
        var client = new ClientService(HttpContext);
        List<Response.CategoryDTO>? listCategory = await client.GetAll<List<Response.CategoryDTO>>("/api/Category");
        if (listCategory != null) ViewBag.Categories = listCategory;

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(Request.ProductAddRequest product)
    {
        var client = new ClientService(HttpContext);
        var res = await client.PostReturnResponse("/api/Products", product);
        if (res.IsSuccessStatusCode)
        {
            List<Response.CategoryDTO>? listCategory = await client.GetAll<List<Response.CategoryDTO>>("/api/Category");
            List<Response.ProductResponse>? listProduct =
                await client.GetAll<List<Response.ProductResponse>>($"api/Products");
            if (listProduct != null) ViewBag.Products = listProduct;
            if (listCategory != null) ViewBag.Categories = listCategory;
            return View("Index");
        }
        else
        {
            return View();
        }
       
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var client = new ClientService(HttpContext);
        var res = await client.GetAll<Response.ProductResponse>($"/api/Products/{id}");
        List<Response.CategoryDTO>? listCategory = await client.GetAll<List<Response.CategoryDTO>>("/api/Category");
        if (listCategory != null) ViewBag.Categories = listCategory;
        return View(res);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Request.ProductUpdateRequest product, int productUpdateId)
    {
        var client = new ClientService(HttpContext); 
        var res = await client.Put($"/api/Products/{productUpdateId}", product);
        
        List<Response.CategoryDTO>? listCategory = await client.GetAll<List<Response.CategoryDTO>>("/api/Category");
        List<Response.ProductResponse>? listProduct =
            await client.GetAll<List<Response.ProductResponse>>($"api/Products");
        if (listProduct != null) ViewBag.Products = listProduct;
        if (listCategory != null) ViewBag.Categories = listCategory;
        return View("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var client = new ClientService(HttpContext);
        var res = await client.Delete($"api/Products/{id}", "");
        
        List<Response.CategoryDTO>? listCategory = await client.GetAll<List<Response.CategoryDTO>>("/api/Category");
        List<Response.ProductResponse>? listProduct =
            await client.GetAll<List<Response.ProductResponse>>($"api/Products");
        if (listProduct != null) ViewBag.Products = listProduct;
        if (listCategory != null) ViewBag.Categories = listCategory;
        return View("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Detail(int id)
    {
        var client = new ClientService(HttpContext);
        var product = await client.GetAll<Response.ProductResponse>($"/api/Products/{id}");
        var order = await client.GetAll<List<Response.OrderDetailResponse>>($"api/Order/GetOrderByProductId/{id}");
        if (product != null) ViewBag.Products = product;
        if (order != null) ViewBag.Orders = order;
        return View();
    }
}