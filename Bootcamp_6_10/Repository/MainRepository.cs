using Bootcamp_6_10.Data;
using Bootcamp_6_10.Models;
using Bootcamp_6_10.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace Bootcamp_6_10.Repository
{
    public class MainRepository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        public MainRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public T Find(int Id)
        {
           return _context.Set<T>().Find(Id);
        }

        public IEnumerable<T> FindAll()
        {
            
            return _context.Set<T>().ToList();
        }

        public void  Insert(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
       
        }

        public void  Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();

        }
    }
}
