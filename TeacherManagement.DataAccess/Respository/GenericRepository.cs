using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherManagement.DataAccess.Abstract;
using TeacherManagement.DataAccess.Context;

namespace TeacherManagement.DataAccess.Respository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly TeacherManagementContext _context;

        public GenericRepository(TeacherManagementContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public T GetById(int id)
        {
           return _context.Find<T>(id);
        }

        public List<T> GetListAll()
        {
            return _context.Set<T>().ToList();
        }

        public void Update(T entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}
