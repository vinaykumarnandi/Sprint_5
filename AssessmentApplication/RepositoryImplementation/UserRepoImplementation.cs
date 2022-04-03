using AssessmentApplication.Models;
using AssessmentApplication.Repository;
using AssessmentApplication.Repository.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssessmentApplication.RepositoryImplementation
{
    public class UserRepoImplementation : BaseRepositoryImplementation<User>, IUserRepository
    {
        private readonly AppDBContext _dbContext;

        public UserRepoImplementation(AppDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        
    }
}
