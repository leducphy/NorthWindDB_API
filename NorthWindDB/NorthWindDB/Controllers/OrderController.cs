using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NorthWindDB.DTO;
using NorthWindDB.Models;

namespace NorthWindDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private NorthWindContext _context;
        private IMapper _mapper;

        public OrderController(NorthWindContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet, EnableQuery]
        public async Task<IActionResult> GetOrders()
        {
            // Retrieve orders with related entities included
            var orders = await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.Employee)
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Product) 
                .Include(o => o.ShipViaNavigation)
                .ToListAsync();

            // Map the orders to DTOs
            var orderDTOs = _mapper.Map<List<OrderDTO>>(orders);

            return Ok(orderDTOs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var f = _context.Orders
                .Include(i => i.Customer)
                .Include(i => i.Employee)
                .Include(i => i.OrderDetails)
                .ThenInclude(p=> p.Product)
                .ThenInclude(p=> p.Category)
                .Include(i => i.ShipViaNavigation)
                .FirstOrDefault(i => i.OrderId == id);
            var o =  _mapper.Map<OrderDTO2>(f);
            if (o == null)
            {
                return NotFound();
            }

            return Ok(o);
        }

        [HttpGet("ByEmployee/{id}")]
        public async Task<IActionResult> ByEmployee(int id)
        {
            var f = _context.Orders
                .Include(i => i.Customer)
                .Include(i => i.Employee)
                .Include(i => i.OrderDetails)
                .Include(i => i.ShipViaNavigation)
                .Where(i => i.EmployeeId == id);
            var o =  _mapper.Map<List<OrderDTO>>(f);
            return Ok(o);
        }
        
        [HttpGet("ByCustomer/{id}")]
        public async Task<IActionResult> ByCustomer(string id)
        {
            var f = _context.Orders
                .Include(i => i.Customer)
                .Include(i => i.Employee)
                .Include(i => i.OrderDetails)
                .Include(i => i.ShipViaNavigation)
                .Where(i => i.CustomerId == id);
            var o =  _mapper.Map<List<OrderDTO>>(f);
            return Ok(o);
        }
        
        [HttpGet("ByDate/{from}/{to}")]
        public async Task<IActionResult> ByDate(DateTime from, DateTime to)
        {
            var f = _context.Orders
                .Include(i => i.Customer)
                .Include(i => i.Employee)
                .Include(i => i.OrderDetails)
                .Include(i => i.ShipViaNavigation)
                .Where(o => o.OrderDate >= from && o.OrderDate <= to);
            var o =  _mapper.Map<List<OrderDTO>>(f);
            return Ok(o);
        }
        
        [HttpGet("Filter/{key}/{value}")]
        public async Task<IActionResult> Filter(string key, string value)
        {
            try
            {
                IQueryable<Order> query = _context.Orders
                    .Include(i => i.Customer)
                    .Include(i => i.Employee)
                    .Include(i => i.OrderDetails)
                    .Include(i => i.ShipViaNavigation);

                switch (key.ToLower())
                {
                    case "customerid":
                        query = query.Where(o => o.CustomerId == value);
                        break;
                    case "employeeid":
                        if (int.TryParse(value, out int employeeId))
                            query = query.Where(o => o.EmployeeId == employeeId);
                        else
                            return BadRequest("Invalid EmployeeID");
                        break;
                    default:
                        return StatusCode(440,"Invalid key");
                }

                var orders = await query.ToListAsync();
                var orderDTOs = _mapper.Map<List<OrderDTO>>(orders);

                return Ok(orderDTOs);
            }
            catch (Exception e)
            {
                return StatusCode(440, "fail to load");
            }
        }

        [HttpGet("GetOrderByProductId/{id}")]
        public async Task<IActionResult> GetOrderByProductId(int id)
        {
            var orders = _context.OrderDetails
                .Include(x => x.Product)
                .Where(x => x.ProductId == id).ToList();
            var map = _mapper.Map<List<OrderDetailDTO>>(orders);
            Console.WriteLine(map);
            return Ok(map);
        }
        
    }
}