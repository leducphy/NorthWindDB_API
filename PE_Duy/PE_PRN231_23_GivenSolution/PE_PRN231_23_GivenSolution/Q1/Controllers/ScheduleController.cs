using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Q1.DTO;
using Q1.Models;

namespace Q1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly PE_PRN_Fall2023B1Context _context;
        private readonly IMapper _mapper;

        public ScheduleController(PE_PRN_Fall2023B1Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddSchedule([FromBody] ScheduleRequestDTO request)
        {
            if (request.EndDate > request.StartDate) return StatusCode(409, "Conflict time !");
            var map = _mapper.Map<Schedule>(request);
            await _context.Schedules.AddAsync(map);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
