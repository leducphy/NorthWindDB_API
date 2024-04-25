using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PE_Trial.Models;

namespace PE_Trial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly PRN_Sum22_B1Context _context;
        private readonly IMapper _mapper;

        public CustomerController(PRN_Sum22_B1Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        [HttpPost("Delete/{customerId}")]
        public async Task<IActionResult> DeleteCustomer(string customerId)
        {
            try
            {
                var customer = await _context.Customers
                    .Include(c => c.Orders)
                    .ThenInclude(o => o.OrderDetails)
                    .FirstOrDefaultAsync(c => c.CustomerId == customerId);

                if (customer == null)
                {
                    return NotFound("");
                }

                _context.OrderDetails.RemoveRange(customer.Orders.SelectMany(o => o.OrderDetails));
                _context.Orders.RemoveRange(customer.Orders);
                _context.Customers.Remove(customer);

                int deletedCount = await _context.SaveChangesAsync();

                return Ok(new
                {
                    DeletedCustomers = 1,
                    DeletedOrders = customer.Orders.Count,
                    DeletedOrderDetails = customer.Orders.Sum(o => o.OrderDetails.Count)
                });
            }
            catch (Exception ex)
            {
                // Log the exception
                return Conflict("There was an unknown error when performing data deletion.");
            }
        }
    }
}
