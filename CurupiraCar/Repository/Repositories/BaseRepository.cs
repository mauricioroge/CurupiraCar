using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected MySqlContext _baseContext;
        protected DbSet<T> dbSet;
        protected IQueryable<T> baseQuery;
        public BaseRepository(MySqlContext context)
        {
            _baseContext = context;
            dbSet = _baseContext.Set<T>();
            baseQuery = _baseContext.Set<T>();

        }

        public virtual T Create(T obj)
        {
            var item = dbSet.Add(obj);
            _baseContext.SaveChanges();
            return item.Entity;
        }

        public virtual T Remove(int id)
        {
            var item = dbSet.Remove(Get(id));
            _baseContext.SaveChanges();
            return item.Entity;
        }

        public virtual T Update(T obj)
        {
            dbSet.Update(obj);
            _baseContext.SaveChanges();
            return Get(obj.Id);
        }

        public virtual T Get(int id)
        {
            return  dbSet.Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public T Get(Expression<Func<T, bool>> expression = null)
        {
            IQueryable<T> query = dbSet.AsNoTracking();

            return query.FirstOrDefault(expression);
        }

        public T Remove(Expression<Func<T, bool>> expression = null)
        {
            var item = dbSet.Remove(Get(expression));
            _baseContext.SaveChanges();
            return item.Entity;
        }
        public IEnumerable<T> GetAll(string search)
        {
            var fields = dbSet.ToList();
            var valores = new List<T>();
            foreach (var item in fields)
            {
                if (item.ToString().Contains(search.ToLowerInvariant()))
                {
                    valores.Add(item);
                }
            }
            return valores;
           
        }
    }
}
