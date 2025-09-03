using Bootcamp_6_10.Models;

namespace Bootcamp_6_10.Repository.Base
{
    public interface IUnitOfWork
    {
        IRepoProduct Products { get; }
        IRepository<Categoty> Categories { get; }
        IRepository<Employee> Employees { get; }

        void Save();

    }
}
