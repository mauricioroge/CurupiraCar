using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;


namespace Tests.Repositories
{
    public class ApoliceSeguroRepositoryTest : IDisposable
    {
        protected readonly TesteContextTest _db;
        protected readonly DbSet<ApoliceSeguro> _dbSet;

        public ApoliceSeguroRepositoryTest()
        {
            var options = new DbContextOptionsBuilder<TesteContextTest>()
                .UseInMemoryDatabase("Teste")
                .Options;

            _db = new TesteContextTest(options);
            TesteContextTest.RunSeed(_db);
            _dbSet = _db.Set<ApoliceSeguro>();
        }
        
        public bool Create(ApoliceSeguro apolice)
        {
            if (apolice != null)
            {
                try
                {
                    var obj = _dbSet.Add(apolice);
                    _db.SaveChanges();
                    if (obj != null)
                    {
                        return true;
                    }
                    else
                        return false;
                }
                catch (Exception)
                {
                    return false;
                }
                
            }
            return false;
        }
        public bool Delete(int id)
        {
            var entity = _dbSet.Find(id);

            if (entity == null)
                return false;

            _dbSet.Remove(entity);
            return _db.SaveChanges() > 0;
        }

        public void Dispose()
        {
            TesteContextTest.CleanContext(_db);
            _db.Dispose();
        }
    }
}
