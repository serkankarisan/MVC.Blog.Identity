using Blog.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entities.ViewModel
{
    public class MakaleDetayViewModel
    {
        public Article Makale { get; set; }
        public Comment Yorum { get; set; }
        public List<Comment> Yorumlar { get; set; }
    }
}
