using System.Collections.Generic;

namespace DIO.Series
{
    public interface IRepository<T>
    {
        List<T> GetList();
        T ReturnById(int id);
        void Add(T entidade);
        void Delete(int id);
        void Update(int id, T entidade);
        int NextId();
    }
}
