using AssessmentApplication.Authentication;
using AssessmentApplication.Models;
using AssessmentApplication.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AssessmentApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationManager _authenticationmanager;
        private readonly IUserRepository _repository;

        public AuthController(IAuthenticationManager authenticationmanager, IUserRepository repo)
        {
            _authenticationmanager = authenticationmanager;
            _repository = repo;
        }

        [HttpPost]
        [Route("api/[controller]/login")]
        public IActionResult Login(UserAuth user)
        {
            var token = _authenticationmanager.Authenticate(user);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }
    }
}
 