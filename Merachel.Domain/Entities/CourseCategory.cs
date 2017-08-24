using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Merachel.Domain.Entities
{
    public class CourseCategory
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int CourseCategoryID { get; set; }

        [Display(Name = "Nama Kategori")]
        [StringLength(100)]
        [Required(ErrorMessage = "Tolong masukkan nama kategori produk")]
        public string CourseCategoryName { get; set; }

        [Display(Name = "Deskripsi")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Tolong masukkan Deskripsi Kategori Kursus")]
        public string CourseCategoryDescription { get; set; }

        [Display(Name = "Tanggal Upload")]
        [HiddenInput(DisplayValue = false)]
        [DataType(DataType.Date)]
        public DateTime CourseCategoryDate { get; set; }

        [HiddenInput(DisplayValue = false)]
        public bool CourseCategoryStatus { get; set; }

        public virtual ICollection<Course> Course { get; set; }
    }
}
