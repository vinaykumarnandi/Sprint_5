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
    public class UserTaskController : BaseController<UserTask>
    {
        private readonly IUserTaskRepository _repository;

        public UserTaskController(IUserTaskRepository userTaskRepo) : base(userTaskRepo)
        {
            _repository = userTaskRepo;
        }
    }
}
