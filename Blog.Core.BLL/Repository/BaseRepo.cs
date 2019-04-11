using Blog.Core.DAL.Repository.Service;
using Blog.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Core.BLL.Repository
{
    public abstract class BaseRepo<TEntity> where TEntity : BaseEntity
    {
        protected RepositoryService Service;
        public BaseRepo()
        {
            Service = new RepositoryService();
        }
        public abstract int Insert(TEntity entity);
        public abstract List<TEntity> Select();
        public abstract TEntity SelectById(int id);
    }
}
