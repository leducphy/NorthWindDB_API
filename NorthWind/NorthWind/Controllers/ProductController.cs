using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NorthWind.DTO;
using NorthWind.Helper;
using NorthWind.Models;

namespace NorthWind.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly NorthWindDbContext _context;
        private readonly IMapper _mapper;

        public ProductController(NorthWindDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Product
        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var list = _mapper.Map<List<ProductResponse>>(await _context.Products.Include(x=> x.Category).ToListAsync());
            return Ok(list);
        }

        // GET: api/Product/5
        [HttpGet("{id}"), Authorize(Roles = RoleConstant.USER)]
        public async Task<ActionResult<ProductResponse>> GetProduct(Guid id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ProductResponse>(product));
        }

        // PUT: api/Product/5
        [HttpPut("{id}"), Authorize(Roles = RoleConstant.USER)]
        public async Task<IActionResult> PutProduct(Guid id, ProductUpdateRequest product)
        {
            var p = await _context.Products.FindAsync(id);
            if (p!= null)
            {
                p.Name = product.Name;
                p.Price = product.Price;
                p.CategoryId = p.CategoryId;
            }
            else
            {
                return BadRequest("Product ID not found");
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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

        // POST: api/Product
        [HttpPost, Authorize(Roles = RoleConstant.USER)]
        public async Task<ActionResult<Product>> PostProduct(ProductAddRequest product)
        {
            var map = _mapper.Map<Product>(product);
            _context.Products.Add(map);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}"), Authorize(Roles = RoleConstant.USER)]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(Guid id)
        {
            return _context.Products.Any(e => e.Id.Equals(id));
        }
    }
}