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
        public async Task<IActionResult> Search()
        {
            var listMovie = await _context.Movies
                .Include(i => i.Genres)
                .Include(i => i.Director)
                .ToListAsync();
            var map = _mapper.Map<List<MovieResponseDTO>>(listMovie);
            return Ok(map);
        }

        [HttpGet("GetAllMoviesByGenre/{genre}")]
        public async Task<IActionResult> GetByGenre(string genre)
        {
            var movie = await _context.Movies
                .Include(i => i.Genres)
                .Include(i => i.Director)
                .Where(i => i.Genres.Select(i => i.Title.ToLower().Trim()).Contains(genre.ToLower().Trim()))
                .ToListAsync();
            var map = _mapper.Map<List<MovieResponseDTO>>(movie);
            return Ok(map);
        }

    }
}
