using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Merachel.Domain.Entities
{
    public class Course
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int CourseID { get; set; }

        [Display(Name = "Nama Kursus")]
        [StringLength(100)]
        [Required(ErrorMessage = "Tolong masukkan nama kategori produk")]
        public string CourseName { get; set; }

        [Display(Name = "Deskripsi Kursus")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Tolong masukkan Deskripsi Kursus")]
        public string CourseDescription { get; set; }

        public byte[] CoursePictureImageData { get; set; }

        [Display(Name = "Image")]
        public string CoursePictureMimeType { get; set; }

        [HiddenInput(DisplayValue = false)]
        [DataType(DataType.Date)]
        public DateTime CourseDate { get; set; }

        [HiddenInput(DisplayValue = false)]
        public bool CourseStatus { get; set; }

        [Display(Name = "Kategori Kursus")]
        public int? CourseCategoryID { get; set; }

        [ForeignKey("CourseCategoryID")]
        public virtual CourseCategory CourseCategory { get; set; }
    }
}
