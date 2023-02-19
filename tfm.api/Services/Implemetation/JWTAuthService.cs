using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using tfm.api.bll.DTO;
using tfm.api.bll.Services.Contracts;
using tfm.api.Services.Contract;

namespace tfm.api.Services.Implemetation
{
    public class JWTAuthService : IJWTAuthService
    {
        private readonly IUserService _userService;
        private readonly ILogger<JWTAuthService> _logger;

        private readonly string _issuer;
        private readonly string _key;
        private readonly string _hours;
        private readonly string _audience;

        public JWTAuthService(IUserService userService, ILogger<JWTAuthService> logger, IConfiguration configuration)
        {
            _userService = userService;
            _logger = logger;

            _audience = configuration["Jwt:audience"];
            _issuer = configuration["Jwt:issuer"];
            _key = configuration["Jwt:secret"];
            _hours = configuration["Jwt:accessTokenExpiration"];
        }

        [HttpGet]
        public async Task<string> GenerateTokenAsync([FromQuery] LoginDto user)
        {
            _logger.LogInformation("Start generation token.");

            var userx = await _userService.GetUserAsync(user.Email, user.Password);

            if (userx == null)
            {
                _logger.LogWarning("User is not found.");
                return null;
            }

            _logger.LogInformation("User exists.");

            List<Claim> claims = new List<Claim>();

            claims.Add(new Claim(ClaimsIdentity.DefaultNameClaimType, userx.Email));

            foreach (var role in userx.Roles)
            {
                claims.Add(
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, role)
                    );
            }


            var jwt = new JwtSecurityToken(
                             issuer: _issuer,
                             audience: _audience,
                             claims: claims,
                             expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(Convert.ToDouble(_hours))),
                             signingCredentials: new SigningCredentials(GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));


            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        private SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_key));
        }
    }
}
