using Blog.Core.DAL.Repository.Service;
using Blog.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Core.BLL.Repository
{
    public class CategoryRepository : BaseRepo<Category>
    {
        private RepositoryService service;
        public CategoryRepository()
        {
            service = new RepositoryService();
        }

        public override int Insert(Category entity)
        {
            return service.CategoryRepo.Insert(entity);
        }

        public override List<Category> Select()
        {
            throw new System.NotImplementedException();
        }

        public override Category SelectById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
