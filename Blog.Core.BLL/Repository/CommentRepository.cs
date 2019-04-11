using Blog.Core.DAL.Repository.Service;
using Blog.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Core.BLL.Repository
{
    public class CommentRepository : BaseRepo<Comment>
    {
        private RepositoryService service;
        public CommentRepository()
        {
            service = new RepositoryService();
        }

        public override int Insert(Comment entity)
        {
            return service.CommentRepo.Insert(entity);
        }

        public override List<Comment> Select()
        {
            throw new System.NotImplementedException();
        }

        public override Comment SelectById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
