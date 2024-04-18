using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NorthWind_Client.Models;
using NorthWind_Client.Services;

namespace NorthWind_Client.Controllers
{
    public class OrderController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new ClientService(HttpContext);
            List<Response.CustomerDTO>? customerDtos = await client.GetAll<List<Response.CustomerDTO>>("api/Customer");
            List<Response.EmployeeDTO>? employeeDtos = await client.GetAll<List<Response.EmployeeDTO>>("api/Employee");
            List<Response.OrderDTO>? orderDtos = await client.GetAll<List<Response.OrderDTO>>("api/Order");
            ViewBag.Orders = orderDtos;
            ViewBag.Customers = customerDtos;
            ViewBag.Employees = employeeDtos;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string? CustomerID, int? EmployeeID, DateTime? dateTimeFrom, DateTime? dateTimeTo)
        {
            var client = new ClientService(HttpContext);
            string odataQuery = "api/order?$filter=";

            // Adding conditions based on non-null parameters
            List<string> conditions = new List<string>();

            if (!string.IsNullOrEmpty(CustomerID))
                conditions.Add($"CustomerID eq '{CustomerID}'");

            if (EmployeeID.HasValue)
                conditions.Add($"EmployeeID eq {EmployeeID}");

            if (dateTimeFrom.HasValue)
                conditions.Add($"OrderDate ge {dateTimeFrom:yyyy-MM-dd}");

            if (dateTimeTo.HasValue)
                conditions.Add($"OrderDate le {dateTimeTo:yyyy-MM-dd}");

            // Concatenating conditions with 'and' operator
            if (conditions.Count > 0)
                odataQuery += string.Join(" and ", conditions);
            else
                odataQuery += "true"; // If no conditions are specified, return all orders

            List<Response.OrderDTO>? orderDtos = await client.GetAll<List<Response.OrderDTO>>(odataQuery);
            List<Response.CustomerDTO>? customerDtos = await client.GetAll<List<Response.CustomerDTO>>("api/Customer");
            List<Response.EmployeeDTO>? employeeDtos = await client.GetAll<List<Response.EmployeeDTO>>("api/Employee");

            ViewBag.Orders = orderDtos;
            ViewBag.Customers = customerDtos;
            ViewBag.Employees = employeeDtos;

            return View("Index");
        }

        public async Task<IActionResult> Detail(int id)
        {
            var client = new ClientService(HttpContext);
            var orderdetails = await client.GetAll<Response.OrderDTO2>($"api/Order/{id}");
            ViewBag.OrderDetails = orderdetails;
            return View();
        }

    }
}