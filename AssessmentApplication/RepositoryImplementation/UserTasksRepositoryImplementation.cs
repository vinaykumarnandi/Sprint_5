using AssessmentApplication.Models;
using AssessmentApplication.Repository;
using AssessmentApplication.Repository.DBContext;
using System.Collections.Generic;
using System.Linq;

namespace AssessmentApplication.RepositoryImplementation
{
    public class UserTasksRepositoryImplementation : BaseRepositoryImplementation<UserTask>,IUserTaskRepository
    {
        private readonly AppDBContext _dbContext;

        public UserTasksRepositoryImplementation(AppDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
