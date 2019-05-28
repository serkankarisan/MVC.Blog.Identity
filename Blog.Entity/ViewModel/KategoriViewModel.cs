using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entity.ViewModel
{
    public class KategoriViewModel
    {
        [Required]
        [Display(Name = "Kategori Adı")]
        public string Name { get; set; }

        public int Id { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Display(Name = "Açıklama")]
        public string Description { get; set; }
    }
}
