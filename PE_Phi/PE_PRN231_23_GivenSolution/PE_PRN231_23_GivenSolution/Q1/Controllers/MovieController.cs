using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Q1.DTO;
using Q1.Models;

namespace Q1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {

        private readonly PE_PRN_Fall2023B1Context _context;
        private readonly IMapper _mapper;

        public MovieController(PE_PRN_Fall2023B1Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
         
        }

        [HttpGet("GetAllMovies")]
        public async Task<IActionResult> GetAllMovies()
        {
            var list = await _context.Movies.Include(d => d.Director).Include(g => g.Genres).ToListAsync();
            return Ok(_mapper.Map<List<MovieDTO>>(list));
        }

        [HttpGet("GetAllMoviesByGenne/{genre}")]
        public async Task<IActionResult> GetAllMoviesByGenne(string genre)
        {
            var list = await _context.Movies.Include(d => d.Director).Include(g => g.Genres).Where(i => i.Genres.Select(i => i.Title).Contains(genre)).ToListAsync();
            return Ok(_mapper.Map<List<MovieDTO>>(list));
        }

    }
}
