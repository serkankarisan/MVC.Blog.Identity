using Blog.Core.DAL.Repository.Service;
using Blog.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Core.BLL.Repository
{
    public class TagRepository : BaseRepo<Tag>
    {
        private RepositoryService service;
        public TagRepository()
        {
            service = new RepositoryService();
        }

        public override int Insert(Tag entity)
        {
            return service.TagRepo.Insert(entity);
        }

        public override List<Tag> Select()
        {
            throw new System.NotImplementedException();
        }

        public override Tag SelectById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
