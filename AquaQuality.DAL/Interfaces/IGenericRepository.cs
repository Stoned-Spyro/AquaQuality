using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AquaQuality.DAL.Interfaces
{
    public interface IGenericRepository<TEntity> : IDisposable where TEntity : class
    {
        IEnumerable<TEntity> Get();
        TEntity FindById(int Id);
        void Create(TEntity item);
        void CreateRange(IEnumerable<TEntity> items);
        void Update(TEntity item);
        void Remove(TEntity item);
        void Remove(int Id);
        void RemoveRange(IEnumerable<TEntity> items);
        IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> predicate);
        void Save();
    }
}
