using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Core.BLL.Repository.Service
{
    public class RepoService
    {
        public ArticleRepository Articles => new ArticleRepository();
        public CategoryRepository Categories => new CategoryRepository();
        public CommentRepository Comments => new CommentRepository();
        public TagRepository Tags => new TagRepository();
    }
}
