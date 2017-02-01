using System.Collections.Generic;

namespace GroceryCo.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetItems();
    }
}