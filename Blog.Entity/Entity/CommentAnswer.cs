using Blog.Entity.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entity.Entity
{
    public class CommentAnswer:EntityBase
    {
            [Required(ErrorMessage = "Lütfen Cevap içeriğini giriniz!")]
            public string Content { get; set; }
            public int CommentId { get; set; }
            public string UserId { get; set; }

            [ForeignKey("CommentId")]
            public virtual Comment Comment { get; set; }

            [ForeignKey("UserId")]
            public virtual ApplicationUser User { get; set; }
        }
}
