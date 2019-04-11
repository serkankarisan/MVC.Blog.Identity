using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Core.DAL.Repository.Service
{
    public class RepositoryService
    {
        private readonly ArticleRepository articleRepository;
        private readonly CategoryRepository categoryRepository;
        private readonly CommentRepository commentRepository;
        private readonly TagRepository tagRepository;

        public RepositoryService()
        {
            articleRepository = new ArticleRepository();
            categoryRepository = new CategoryRepository();
            commentRepository = new CommentRepository();
            tagRepository = new TagRepository();
        }
        public ArticleRepository ArticleRepo => articleRepository;
        public CategoryRepository CategoryRepo => categoryRepository;
        public CommentRepository CommentRepo => commentRepository;
        public TagRepository TagRepo => tagRepository;
    }
}
