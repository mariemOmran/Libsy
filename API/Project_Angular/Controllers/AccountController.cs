using Azure.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Project_Angular.DTO;
using Project_Angular.Models;
using Project_Angular.UniteOfwork;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Project_Angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly _uniteOfwork uniteOfwork;

        private UserManager<ApplicationUser> _UserManager;
        public AccountController(_uniteOfwork uniteOfwork,UserManager<ApplicationUser> userManager)
        {
            this.uniteOfwork = uniteOfwork;
            _UserManager = userManager;
        }


        [HttpPost]
        [Produces("application/json")]
        public async Task<IActionResult>Register(UserRegisterDTO userDto)
        {
            ApplicationUser user = new ApplicationUser()
            {
                UserName = userDto.Username,
                Email = userDto.Email,
                PasswordHash = userDto.Password,
                Address = userDto.address
            };
         IdentityResult result =   await _UserManager.CreateAsync(user,userDto.Password);
            if (result.Succeeded)
            {
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim ( "userName",userDto.Username));

                var secrite = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("i am mairem graduated from factly of commerce al azhar university "));
                var signCirdintional = new SigningCredentials(secrite, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(claims:claims,signingCredentials: signCirdintional);
                //convert token to string 
                var tokenHandler = new JwtSecurityTokenHandler().WriteToken(token);
                return Ok(tokenHandler);
            }
            else {
                return BadRequest("Data is Not Valid");
            }
        }

        [HttpPost("login")]
        [Produces("application/json")]
        public async Task<IActionResult> Login(UserLoginDTO userDto)
        {
           
            ApplicationUser userAp = await _UserManager.FindByNameAsync(userDto.UserName);
            if (userAp!=null)
            {
            bool found =   await  _UserManager.CheckPasswordAsync(userAp, userDto.Password);

                if (found) { 
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim("userName", userDto.UserName));

                var secrite = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("i am mairem graduated from factly of commerce al azhar university "));
                var signCirdintional = new SigningCredentials(secrite, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(claims: claims, signingCredentials: signCirdintional);
                //convert token to string 
                var tokenHandler = new JwtSecurityTokenHandler().WriteToken(token);
                    bool isAdmin =await _UserManager.IsInRoleAsync(userAp, "Admin");

                return Ok(new{token= tokenHandler ,isAdmin=isAdmin});
                }
                return Unauthorized();
            }
            else
            {
                return BadRequest("Data is Not Valid");
            }
        }
    }
}
