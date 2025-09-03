using Bootcamp_6_10.Data;
using Bootcamp_6_10.Models;
using Bootcamp_6_10.Repository.Base;

namespace Bootcamp_6_10.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context )
        {
            _context = context;
            Products =new RepoProduct(_context);
            Categories = new MainRepository<Categoty>(_context);
            Employees = new  MainRepository<Employee>(_context);
        }
        public IRepoProduct Products { get; }
        public IRepository<Categoty>  Categories { get; }
        public IRepository<Employee>  Employees  { get; }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
