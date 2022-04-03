using AssessmentApplication.Models;
using System.Collections.Generic;

namespace AssessmentApplication.Repository
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        bool Add(T entity);
        
        bool Update(int id, T entity);
        
        IEnumerable<T> GetAll();
        
        T GetById(int id);

        bool Delete (int id);
    }
}
