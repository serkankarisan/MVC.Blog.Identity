using Blog.Core.DAL.Repository.Service;
using Blog.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Core.BLL.Repository
{
    public class ArticleRepository : BaseRepo<Article>
    {
        private RepositoryService service;
        public ArticleRepository()
        {
            service = new RepositoryService();
        }

        public override int Insert(Article entity)
        {
            return service.ArticleRepo.Insert(entity);
        }

        public override List<Article> Select()
        {
            throw new System.NotImplementedException();
        }

        public override Article SelectById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
