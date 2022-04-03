using System;
using System.Text;
using Xunit;
using System.Net.Http;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using AssessmentApplication.Models;

namespace AssessmentApplication.Tests.IntegrationTests
{
    public class BaseIntegrationTests : IClassFixture<CustomWebApplicationFactory>
    {
        protected readonly CustomWebApplicationFactory _customWebApplicationFactory;
        protected HttpClient _httpClientWithFullIntegration;
        protected dynamic _token;
        string issuer = "https://localhost:5001";
        string audience = "https://localhost:5001";

        public BaseIntegrationTests(CustomWebApplicationFactory customWebApplicationFactory)
        {
            _customWebApplicationFactory = customWebApplicationFactory;
            _httpClientWithFullIntegration ??= _customWebApplicationFactory.CreateClient();
            var user = new User()
            {
                FirstName = "string",
                Password = "string"
            };
            _token = GetToken(user);
        }

        private string GetToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("key"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(issuer, audience, null, expires: DateTime.Now.AddMinutes(120), signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
