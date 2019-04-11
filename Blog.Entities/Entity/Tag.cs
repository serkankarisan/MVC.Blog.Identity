using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Blog.Entities.Entity
{
    public class Tag : BaseEntity
    {
        [Required(ErrorMessage = "Lütfen etiket içeriği giriniz!")]
        [StringLength(30, ErrorMessage = "İçerik {0} karakterden uzun olmamalıdır!")]
        public string Content { get; set; }

        public virtual List<Article> Articles { get; set; }
    }
}
