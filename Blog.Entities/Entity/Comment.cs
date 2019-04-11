using Blog.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Blog.Entities.Entity
{
    [Table("Comments")]
    public class Comment : BaseEntity
    {
        [Required(ErrorMessage = "Lütfen yorum içeriğini giriniz!")]
        public string Content { get; set; }
        public int ArticleId { get; set; }
        public string UserId { get; set; }

        [ForeignKey("ArticleId")]
        public virtual Article Article { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

    }
}
