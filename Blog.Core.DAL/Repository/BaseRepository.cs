using Blog.DAL.Context;
using Blog.Entities.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Blog.Core.DAL.Repository
{
    public class BaseRepository<T> where T : BaseEntity
    {
        private BlogContext _context;
        protected DbSet<T> _dbSet;

        public BaseRepository()
        {
            _context = new BlogContext();
            _dbSet = _context.Set<T>();
        }

        protected int Save()
        {
            return _context.SaveChanges();
        }

        public int Insert(T entity)
        {
            entity.IsActive = true;
            entity.AddedDate = DateTime.Now;
            _dbSet.Add(entity);
            int result = _context.SaveChanges();
            return result;
        }

        public int Update(T newVersion)
        {
            T oldVersion = _dbSet.Find(newVersion.Id);

            _context.Entry(oldVersion).CurrentValues.SetValues(newVersion);

            return Save();
        }

        public int Delete(int id)
        {
            T deleted = _dbSet.Find(id);

            _dbSet.Remove(deleted);

            return Save();
        }

        public List<T> Select()
        {
            return _dbSet.ToList();
        }

        public List<T> SelectWhere(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }

        public T SelectById(int id)
        {
            return _dbSet.FirstOrDefault(x => x.Id == id);
        }
    }
}
