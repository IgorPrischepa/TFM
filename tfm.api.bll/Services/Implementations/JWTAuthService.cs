using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using tfm.api.bll.Models.User;
using tfm.api.bll.Services.Contract;
using tfm.api.bll.Services.Contracts;

namespace tfm.api.bll.Services.Implementations
{
    internal sealed class JwtAuthService : IJWTAuthService
    {
        private readonly IUserService _userService;
        private readonly ILogger<JwtAuthService> _logger;

        private readonly string _issuer;
        private readonly string _key;
        private readonly string _minutes;
        private readonly string _audience;

        public JwtAuthService(IUserService userService, ILogger<JwtAuthService> logger, IConfiguration configuration)
        {
            _userService = userService;
            _logger = logger;

            _audience = configuration["Jwt:audience"] ??
                        throw new ArgumentNullException(nameof(configuration),"Jwt:audience can't be null. Check appsettings.");
            _issuer = configuration["Jwt:issuer"] ??
                      throw new ArgumentNullException(nameof(configuration),"Jwt:issuer can't be null. Check appsettings.");
            _key = configuration["Jwt:secret"] ??
                   throw new ArgumentNullException(nameof(configuration),"Jwt:secret can't be null. Check appsettings.");
            _minutes = configuration["Jwt:accessTokenExpiration"] ??
                       throw new ArgumentNullException(nameof(configuration),"Jwt:accessTokenExpiration can't be null. Check appsettings.");
        }

        public async Task<string> GenerateTokenAsync(LoginUserModel user)
        {
            _logger.LogInformation("Start generation token");

            var targetUser = await _userService.GetUserAsync(user.Email, user.Password);

            if (targetUser == null)
            {
                _logger.LogWarning("User not founded or input is invalid");
                throw new ArgumentException($"{user} is not valid or doesn't exist.");
            }

            _logger.LogInformation("User exists");

            List<Claim> claims = new()
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, targetUser.Email)
            };

            foreach (var role in targetUser.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var jwt = new JwtSecurityToken(
                             issuer: _issuer,
                             audience: _audience,
                             claims: claims,
                             expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(Convert.ToDouble(_minutes))),
                             signingCredentials: new SigningCredentials(GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));


            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        private SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_key));
        }
    }
}