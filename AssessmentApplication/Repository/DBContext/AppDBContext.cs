using AssessmentApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace AssessmentApplication.Repository.DBContext
{
    public class AppDBContext: DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<UserTask> UserTasks { get; set; }
    }
}
