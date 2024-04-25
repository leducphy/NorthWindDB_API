using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PE_PRN_Fall22B1.DTO;
using PE_PRN_Fall22B1.Models;

namespace PE_PRN_Fall22B1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        private readonly PE_PRN_Fall22B1Context _context;
        private readonly IMapper _mapper;

        public DirectorController(PE_PRN_Fall22B1Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("GetDirectors/{nationality}/{gender}")]
        public IActionResult GetDirectors(string nationality, string gender)
        {
            var list = _context.Directors.Include(x=>x.Movies)
                .ToList();
            var map = _mapper.Map<List<DirectorDTO>>(list);
            return Ok(map.Where(x=> x.Nationality.ToLower().Equals(nationality) && x.Gender.ToLower().Equals(gender)).ToList());
        }
        
        [HttpGet("GetDirector/{id}")]
        public IActionResult GetDirector(int id)
        {
            var director = _context.Directors
                .Include(x => x.Movies)
                .ThenInclude(x => x.Producer )
                .FirstOrDefault(x => x.Id == id);

            if (director == null)
            {
                return NotFound("Director not found.");
            }

            var directorDTO = _mapper.Map<DirectorDTO>(director);
            return Ok(directorDTO);
        }
        
        [HttpPost("create")]
        public IActionResult CreateDirector([FromBody] DirectorAddRequest directorRequest)
        {
            try
            {
                // Map the DirectorAddRequest to a Director entity
                var director = new Director
                {
                    FullName = directorRequest.FullName,
                    Male = directorRequest.Male,
                    Dob = directorRequest.Dob,
                    Nationality = directorRequest.Nationality,
                    Description = directorRequest.Description
                };

                // Add the director to the database
                _context.Directors.Add(director);
                int recordsAdded = _context.SaveChanges();

                // Return the number of records added
                return Ok(recordsAdded);
            }
            catch (Exception ex)
            {
                // Handle any exceptions and return a conflict response with an error message
                return Conflict($"There was an error while adding: {ex.Message}");
            }
        }

    }
}
