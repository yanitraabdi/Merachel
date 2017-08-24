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
    public class CoursePrice
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int CoursePriceID { get; set; }

        [Display(Name = "Nama Harga Kursus")]
        [StringLength(100)]
        [Required(ErrorMessage = "Tolong masukkan Nama Tiket")]
        public string CoursePriceName { get; set; }

        [Display(Name = "Jumlah Harga Kursus")]
        [Required(ErrorMessage = "Tolong masukkan Harga Tiket")]
        public decimal CoursePriceTotal { get; set; }

        [Display(Name = "Deskripsi Harga Kursus")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Tolong masukkan Deskripsi Harga Kursus")]
        public string CoursePriceDescription { get; set; }

        [HiddenInput(DisplayValue = false)]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm}")]
        public DateTime CoursePriceDate { get; set; }

        [HiddenInput(DisplayValue = false)]
        public bool CoursePriceStatus { get; set; }

        [Display(Name = "Course ID")]
        public int? CourseID { get; set; }

        [ForeignKey("CourseID")]
        public virtual Course Course { get; set; }
    }
}
