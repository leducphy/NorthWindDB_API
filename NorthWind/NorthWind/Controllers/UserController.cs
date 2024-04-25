using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NorthWind.DTO;
using NorthWind.Helper;
using NorthWind.Models;
using NorthWind.Utility;

namespace NorthWind.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly NorthWindDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public UserController(NorthWindDbContext context, IConfiguration configuration,
            IMapper mapper, UserManager<AppUser> userManager)
        {
            _context = context;
            _configuration = configuration;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(UserAddRequest user)
        {
            try
            {
                // Create a new AppUser instance with provided user information
                var appUser = new AppUser
                {
                    FullName = user.FullName,
                    Address = user.Address,
                    Phone = user.Phone,
                    Gender = user.Gender,
                    DOB = user.DOB,
                    UserName = user.Email,
                    Email = user.Email
                };

                // Create the user using UserManager
                var result = await _userManager.CreateAsync(appUser, user.Password);

                if (result.Succeeded)
                {
                    // If user creation is successful, assign the role
                    await _userManager.AddToRoleAsync(appUser, RoleConstant.USER);
                    return Ok();
                }
                else
                {
                    // If user creation fails, return error messages
                    return BadRequest(result.Errors);
                }
            }
            catch (Exception e)
            {
                // Handle any exceptions
                Console.WriteLine(e);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error occurred while processing your request.");
            }
        }
        
        [HttpPost("SignIn")]
        [AllowAnonymous]
        public async Task<ActionResult> Login(LoginRequestModel model)
        {
            var user = await LoadUserByUsername(model.Email);
    
            if (user == null)
            {
                return Unauthorized(new { message = "User not found" });
            }

            if (await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var role = await _userManager.GetRolesAsync(user);

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("JwtKey"));
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Issuer = _configuration["JwtIssuer"],
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Sid, user.Id),
                        new Claim(ClaimTypes.Name, user.FullName),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.Role, role.FirstOrDefault())
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);
      
                return Ok(new 
                { 
                    token = tokenString,
                    expiresIn = tokenDescriptor.Expires,
                    role = role.FirstOrDefault(),
                    userid= user.Id
                });
            }
            else
            {
                return Unauthorized(new { message = "Username or password is incorrect" });
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetUserByJWT()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Unauthorized();
            }
            string username = User.Identity.Name;

            // Retrieve the current user's roles
            var user = await _userManager.FindByNameAsync(username);
            var roles = await _userManager.GetRolesAsync(user);
            
            return Ok(new
            {
                username,
                roles
            });
        }
        
        private async Task<AppUser> LoadUserByUsername(string email)
        {
            if (new EmailAddressAttribute().IsValid(email))
            {
                var userByEmail = await _userManager.FindByEmailAsync(email);
                if (userByEmail != null)
                    return userByEmail;
            }

            var lowerCaseLogin = email.ToLower(CultureInfo.GetCultureInfo("en-US"));
            var userByLogin = await _userManager.FindByNameAsync(email.ToLower());
            if (userByLogin == null)
                throw new UsernameNotFoundException($"User {lowerCaseLogin} was not found in the database");
            return userByLogin;
        }

    }
}
