using Bootcamp_6_10.Data;
using Bootcamp_6_10.Models;
using Bootcamp_6_10.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace Bootcamp_6_10.Repository
{
    public class RepoProduct : MainRepository<Product> , IRepoProduct
    {
        private readonly ApplicationDbContext _context;
        public RepoProduct(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public IEnumerable<Product> FindAllProducts()
        {
            return _context.Products.Include(p => p.Categoty).AsNoTracking().ToList();
        }
    }
}
