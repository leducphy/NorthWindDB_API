using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NorthWind_Client.Models;
using NorthWind_Client.Services;

namespace NorthWind_Client.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
         public async Task<IActionResult> Index(LoginRequest loginRequest)
        {
            try
            {
                var client = new ClientService(HttpContext);
                var requestModel = new LoginRequest { Email = loginRequest.Email, Password = loginRequest.Password };
                var result = await client.PostReturnResponse("/api/User/SignIn", requestModel);

                if (result.IsSuccessStatusCode)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    var res = JsonConvert.DeserializeObject<LoginResponseModel>(content);

                    // Set the authentication cookie
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Sid, res!.UserId.ToString()),
                        new Claim(ClaimTypes.Role, res.Role)
                    };
                    var claimsIdentity = new ClaimsIdentity(claims, "login");
                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    HttpContext.Response.Cookies.Append("AccessToken", res.Token, new CookieOptions
                    {
                        Expires = DateTime.Now.AddHours(500)
                    });

                    await HttpContext.SignInAsync("CookieAuthentication", claimsPrincipal,
                        new AuthenticationProperties { IsPersistent = false });
                }
                else if (result.StatusCode == HttpStatusCode.BadRequest)
                {
                    
                    return RedirectToAction("Index", "Home");
                }

                //TempData["NotificationType"] = "error";
                //TempData["Message"] = "An unexpected error occurred during login.";
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                //TempData["NotificationType"] = "error";
                //TempData["Message"] = $"An error occurred during login {ex}.";
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
