using AssessmentApplication.Models;
using AssessmentApplication.Repository;
using AssessmentApplication.Repository.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AssessmentApplication.RepositoryImplementation
{
    public class BaseRepositoryImplementation<T> : IBaseRepository<T> where T : BaseModel
    {
        private readonly AppDBContext _context;

        public BaseRepositoryImplementation(AppDBContext context)
        {
            _context = context;
        }

        public virtual IEnumerable<T> GetAll()
        {
            try
            {
                return _context.Set<T>().ToList();
            }
            catch (Exception)
            {

            }
            return null;
        }

        public virtual T GetById(int id)
        {
            try
            {
                var entity = _context.Set<T>().FirstOrDefault(i => i.Id == id);
                if (entity == null)
                    return null;

                return entity;
            }
            catch (Exception)
            {

            }
            return null;
        }

        public virtual bool Add(T entity)
        {
            try
            {
                if (entity == null)
                    return false;

                _context.Set<T>().Add(entity);
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {

            }
            return false;
        }

        public virtual bool Update(int id, T entity)
        {
            try
            {
                if (id != entity.Id)
                    return false;

                if (!(_context.Set<T>().Any(e => e.Id == id)))
                {
                    return false;
                }
                _context.Entry(entity).State = EntityState.Modified;
                _context.Set<T>().Update(entity);
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {

            }
            return false;
        }

        public virtual bool Delete(int id)
        {
            try
            {
                var entity = _context.Set<T>().FirstOrDefault(i => i.Id == id);
                if (entity == null)
                    return false;

                _context.Set<T>().Remove(entity);
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {

            }
            return false;
        }
    }
}
