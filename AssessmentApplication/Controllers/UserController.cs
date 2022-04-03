using AssessmentApplication.Models;
using AssessmentApplication.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AssessmentApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserController : BaseController<User>
    {
        private readonly IUserRepository _repository;

        public UserController(IUserRepository userRepository) : base(userRepository)
        {
            _repository = userRepository;
        }
    }
}
