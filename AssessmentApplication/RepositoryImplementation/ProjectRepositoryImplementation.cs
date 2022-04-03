using AssessmentApplication.Models;
using AssessmentApplication.Repository;
using AssessmentApplication.Repository.DBContext;
using System.Collections.Generic;
using System.Linq;

namespace AssessmentApplication.RepositoryImplementation
{
    public class ProjectRepositoryImplementation : BaseRepositoryImplementation <Project>,IProjectRepository
    {
        private readonly AppDBContext _dbContext;

        public ProjectRepositoryImplementation(AppDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
