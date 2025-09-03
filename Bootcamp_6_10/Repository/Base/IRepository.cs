using Bootcamp_6_10.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp_6_10.Repository.Base
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> FindAll();
         T Find(int Id);
         void Insert(T entity);
         void Update(T entity);
         void Delete(T entity);


    }
}
