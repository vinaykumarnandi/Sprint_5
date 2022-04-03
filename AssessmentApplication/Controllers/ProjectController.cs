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
    public class ProjectController : BaseController<Project>
    {
        public ProjectController(IProjectRepository projectRepository) : base(projectRepository)
        {

        }
    }
}
