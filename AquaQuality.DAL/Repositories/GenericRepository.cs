using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AquaQuality.DAL.Interfaces;
using AquaQuality.DAL.DataContext;

namespace AquaQuality.DAL.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class
    {
        protected readonly DatabaseContext Db;
        protected readonly DbSet<TEntity> dbSet;

        public GenericRepository(DatabaseContext context)
        {
            Db = context;
            dbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> Get()
        {
            return dbSet.AsNoTracking().ToList();
        }

        public virtual IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return dbSet.AsNoTracking().Where(predicate).ToList();
        }

        public virtual TEntity FindById(int Id)
        {
            return dbSet.Find(Id);
        }

        public virtual void Create(TEntity item)
        {
            this.dbSet.Add(item);
            this.Db.SaveChanges();
        }

        public void CreateRange(IEnumerable<TEntity> items)
        {
            this.dbSet.AddRange(items);
            this.Db.SaveChanges();
        }

        public virtual void Update(TEntity item)
        {
            Db.Entry(item).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public virtual void Remove(TEntity item)
        {
            dbSet.Remove(item);
            Db.SaveChanges();
        }

        public void RemoveRange(IEnumerable<TEntity> items)
        {
            this.dbSet.RemoveRange(items);
            this.Db.SaveChanges();
        }

        public virtual void Remove(int Id)
        {
            TEntity entity = FindById(Id);
            dbSet.Remove(entity);
            Db.SaveChanges();
        }

        public void Save()
        {
            Db.SaveChanges();
        }
        public IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> predicate)
        {
            return dbSet.AsNoTracking().Where(predicate).ToList();
        }
        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
