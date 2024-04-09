using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NorthWindDB.DTO;
using NorthWindDB.Models;

namespace NorthWindDB.Controllers
{
    [Route("api")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private NorthWindContext _context;
        private IMapper _mapper;

        public CategoryController(NorthWindContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("Category")]
        public IActionResult ListCategory()
        {
            return Ok(_context.Categories.ToList());
        }

        [HttpGet("Category/{id}")]
        public IActionResult GetCategoryByID(int id)
        {
            return Ok(_context.Categories.Find(id));
        }

        [HttpPost("Category")]
        public async Task<ActionResult> AddCategory(CategoryDTO category)
        {
            Category cat = _mapper.Map<Category>(category);
            _context.Categories.Add(cat);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("Category/{id}")]
        public async Task<ActionResult> DelCate(int id)
        {
            var cate = _context.Categories.Find(id);
            _context.Categories.Remove(cate);
            await _context.SaveChangesAsync();
            return Ok();
        }
        
        [HttpPut("Category/{id}")]
        public async Task<ActionResult> UpdateCate(int id ,CategoryDTO cat)
        {
            var cate = _context.Categories.Find(id);
            if (cate != null)
            {
                cate.Description = cat.Description;
                cate.CategoryName = cat.CategoryName;
            }
            _context.Categories.Update(cate);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}