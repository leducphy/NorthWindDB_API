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
    public class EmployeeController : ControllerBase
    {
        private NorthWindContext _context;
        private IMapper _mapper;

        public EmployeeController(NorthWindContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployee()
        {
            return Ok(_mapper.Map<List<EmployeeDTO>>( await _context.Employees.ToListAsync()));
        }
    }
}
