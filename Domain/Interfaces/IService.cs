using Domain.Models;

namespace Domain.Interfaces
{
    public interface IService<T>
    {
        Option<T> Get(string id);
        Option<T> Save(T t);

        void Save(MakeTransfer transfer);
    }
}
