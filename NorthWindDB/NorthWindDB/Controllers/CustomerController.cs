using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NorthWindDB.DTO;
using NorthWindDB.Models;

namespace NorthWindDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private NorthWindContext _context;
        private IMapper _mapper;

        public CustomerController(NorthWindContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCustomer()
        {
            var x= await _context.Customers.ToListAsync();
            var y = _mapper.Map<List<CustomerDTO>>(x);
            return Ok( y );
        }
    }
}
