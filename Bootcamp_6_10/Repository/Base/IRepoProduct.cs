using Bootcamp_6_10.Models;

namespace Bootcamp_6_10.Repository.Base
{
    public interface IRepoProduct  : IRepository<Product>
    {
        IEnumerable<Product> FindAllProducts();
    }
}
