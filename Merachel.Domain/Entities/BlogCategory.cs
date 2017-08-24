using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Merachel.Domain.Entities
{
    public class BlogCategory
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int BlogCategoryID { get; set; }

        [Display(Name = "Nama Blog Category")]
        [StringLength(100)]
        [Required(ErrorMessage = "Tolong masukkan nama kategori blog")]
        public string BlogCategoryName { get; set; }

        [HiddenInput(DisplayValue = false)]
        [DataType(DataType.Date)]
        public DateTime BlogCategoryDate { get; set; }

        [HiddenInput(DisplayValue = false)]
        public bool BlogCategoryStatus { get; set; }

        public virtual ICollection<Blog> Blog { get; set; }
    }
}
