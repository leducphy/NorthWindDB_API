using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PE_Trial.DTO;
using PE_Trial.Models;
using System.IO;

namespace PE_Trial.Controllers
{
    [Route("api/Director")]
    [ApiController]
    public class DirectorsController : ControllerBase
    {
        private readonly PE_PRN_Fall22B1Context _context;
        private readonly IMapper _mapper;

        public DirectorsController(PE_PRN_Fall22B1Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetDirectors/{nationally}/{gender}")]
        public async Task<ActionResult<IEnumerable<List<DirectorsDTO>>>> GetDirectorByNationally(string nationally, string gender)
        {
            if (_context.Directors == null)
            {
                return NotFound();
            }
            bool isMale = false;
            if( gender == "Male")
            {
                isMale = true;
            }

            var directors = await _context.Directors
                .Where(d => d.Nationality == nationally && d.Male == isMale )
            .ToListAsync();

            var directorDto = _mapper.Map<List<DirectorsDTO>>(directors).ToList();
            if (directors.Count == 0)
            {
                return NotFound("No directors found with the specified criteria.");
            }

            return Ok(directorDto);
        }


        [HttpGet]
        [Route("GetDirectorsByID/{id}")]
        public async Task<ActionResult> GetDirectorsByID([FromRoute] int id)
        {
            
            var directors = await _context.Directors.Include(d => d.Movies).ThenInclude(y => y.Producer).FirstOrDefaultAsync(d => d.Id == id);



             return Ok(directors);
        }

        [HttpPost]
        [Route("CreateDirector")]
        public async Task<ActionResult<IEnumerable<DirectorsDTO>>> CreateDir([FromBody] Director directorx)
        {

            if (directorx == null)
            {
                return BadRequest("Invalid data provided.");
            }

            var director = new Director
            {
                Id = directorx.Id,
                FullName = directorx.FullName,
                Male = directorx.Male ,
                Dob = directorx.Dob,
                Nationality = directorx.Nationality,
                Description = directorx.Description
            };

            _context.Directors.Add(director);
            await _context.SaveChangesAsync();

            var directorDto = _mapper.Map<DirectorsDTO>(director);

            return CreatedAtAction(nameof(GetDirectorsByID), new { id = directorDto.Id }, directorDto);



        }
    }
}
