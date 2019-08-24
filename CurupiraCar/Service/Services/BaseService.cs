using Domain.Model;
using FluentValidation;
using Repository.Context;
using Repository.Contracts;
using Repository.Repositories;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Service.Services
{
    public class BaseService<T>: IBaseService<T> where T: BaseEntity
    {
        private readonly IBaseRepository<T> _repository;
        public BaseService(MySqlContext context)
        {
            _repository = new BaseRepository<T>(context);
        }

        public virtual void Delete(int id)
        {
            if (id == 0)
                throw new ArgumentException("O id não pode ser zero.");

            _repository.Remove(id);
        }

        public virtual T Get(int id)
        {
            if (id == 0)
                throw new ArgumentException("O id não pode ser zero.");

            return _repository.Get(id);
        }
        

        public virtual IEnumerable<T> Get() => _repository.GetAll();

        public T Get(Expression<Func<T, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public virtual T Post<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());

            _repository.Create(obj);
            return obj;
        }

        public virtual T Put<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());

            _repository.Update(obj);
            return obj;
        }

        private void Validate(T obj, AbstractValidator<T> validator)
        {
            if (obj == null)
            {
                throw new Exception("Registros não encontrados!");
            }

            validator.ValidateAndThrow(obj);
        }
    }
}
