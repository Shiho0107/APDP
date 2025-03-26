using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApplication1.Data;

namespace WebApplication1.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DemoContext _demoProtectContext;
        protected DbSet<T> _dbset;

        public Repository(DemoContext demoProtectContext)
        {
            _demoProtectContext = demoProtectContext;
            _dbset = _demoProtectContext.Set<T>();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dbset.ToList();
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _dbset.Where(predicate);
        }

        public virtual T GetById(int id)
        {
            return _dbset.Find(id);
        }

        public virtual void Add(T entity)
        {
            _dbset.Add(entity);
        }

        public virtual void Update(T entity)
        {
            _dbset.Update(entity);
        }

        public virtual void Delete(T entity)
        {
            _dbset.Remove(entity);
        }
    }
}
