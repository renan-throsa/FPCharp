using Domain.Models;

namespace Domain.Interfaces
{
    public interface IRepository<T>
    {
        Option<T> Get(string id);
        void Save(T t);
    }

}
