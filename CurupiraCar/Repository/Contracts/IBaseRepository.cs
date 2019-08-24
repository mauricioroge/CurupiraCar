using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Contracts
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        T Create(T obj);
        T Update(T obj);
        T Remove(int id);
        T Get(int id);
        T Get(Expression<Func<T, bool>> expression = null);
        T Remove(Expression<Func<T, bool>> expression = null);
        IEnumerable<T> GetAll();

    }
}
