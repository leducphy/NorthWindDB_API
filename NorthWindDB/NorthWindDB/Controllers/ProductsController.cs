using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NorthWindDB.DTO;
using NorthWindDB.Models;

namespace NorthWindDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private NorthWindContext _context;
        private IMapper _mapper;

        public ProductsController(NorthWindContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDTO>>> GetProducts()
        {
            return _mapper.Map<List<ProductDTO>>(
                _context.Products
                    .Include(p => p.Category)
                    .Include(s => s.Supplier)
                    .Include(od => od.OrderDetails)
                    .ToList()
            );
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProduct([FromRoute] int id)
        {
            Product p = _context.Products.Include(p => p.Category)
                .Include(s => s.Supplier)
                .Include(od => od.OrderDetails).FirstOrDefault(p => p.ProductId == id)!;

            return Ok(_mapper.Map<ProductDTO>(p));
        }

        [HttpGet("Category/{id}")]
        public async Task<ActionResult<List<ProductDTO>>> GetProductsByCategory([FromRoute] int id)
        {
            List<Product> products;
            products = _context.Products.Include(p => p.Category)
                .Include(s => s.Supplier)
                .Include(od => od.OrderDetails).Where(p => p.CategoryId == id).ToList();
            return _mapper.Map<List<ProductDTO>>(products);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDTO>> AddProduct([FromBody] AddProductDTO apd)
        {
            var c = _context.Categories.FirstOrDefault(c => c.CategoryName.Equals(apd.Category))!;

            var product = _mapper.Map<Product>(apd);
            product.Category = c;
            _context.Products.Add(product);
            _context.SaveChanges();
            return _mapper.Map<ProductDTO>(product);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDTO>> UpdateProduct([FromRoute] int id, [FromForm] UpdateProductDTO pd)
        {
            var p = _mapper.Map<Product>(pd);
            var cate = _context.Categories.Find(pd.CategoryId);
            if (cate == null)
            {
                return StatusCode(409, $"Category ID invalid");
            }
            p.ProductId = id;
            _context.Entry(p).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExist(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            try
            {
                var product = await _context.Products.FindAsync(id);
                if (product == null)
                {
                    return NotFound($"Product id {id} doesn't exist in database");
                }

                var orderDetailsCount = await _context.OrderDetails.Where(od => od.ProductId == id).CountAsync();

                if (orderDetailsCount > 0)
                {
                    var orderDetails = await _context.OrderDetails.Where(od => od.ProductId == id).ToListAsync();
                    _context.OrderDetails.RemoveRange(orderDetails);
                }

                _context.Products.Remove(product);
                await _context.SaveChangesAsync();

                return Ok($"Delete product successful with {orderDetailsCount} ORDER DETAILS deleted");
            }
            catch (DbUpdateException e)
            {
                return StatusCode(406, "Deletion is not possible due to database constraints.");
            }
            catch (Exception e)
            {
                return StatusCode(409, $"An error occurred while processing your request. Bug : {e}");
            }
        }

        private bool ProductExist(long id)
        {
            return (_context.Products?.Any(e => e.ProductId == id)).GetValueOrDefault();
        }
    }
}