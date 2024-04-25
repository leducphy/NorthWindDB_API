using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PE_Trial.DTO;
using PE_Trial.Models;

namespace PE_Trial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly PRN_Sum22_B1Context _context;
        private readonly IMapper _mapper;

        public OrderController(PRN_Sum22_B1Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("GetAllOrder")]
        public async Task<IActionResult> GetAllOrder()
        {
            var x = await _context.Orders
                .Include(x=>x.Customer)
                .Include(x=>x.Employee)
                .ThenInclude(x => x.Department)
                .ToListAsync();
            var y = _mapper.Map<List<OrderDTO>>(x);
            return Ok(y);
        }
        
        [HttpGet("GetOrderByDate/{from}/{to}")]
        public async Task<IActionResult> GetOrdersByDateRange(DateTime from, DateTime to)
        {
            var orders = await _context.Orders
                .Include(x => x.Customer)
                .Include(x => x.Employee)
                .ThenInclude(x => x.Department)
                .Where(x => x.OrderDate >= from && x.OrderDate <= to)
                .ToListAsync();

            var orderDTOs = _mapper.Map<List<OrderDTO>>(orders);
            return Ok(orderDTOs);
        }

        
    }
}