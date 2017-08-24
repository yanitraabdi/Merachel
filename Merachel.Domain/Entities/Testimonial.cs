using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Merachel.Domain.Entities
{
    public class Testimonial
    {
        [Key]
        public int TestimonialID { get; set; }

        [Display(Name = "Pesan Testimonial")]
        [Required(ErrorMessage = "Tolong masukkan pesan testimonial")]
        [DataType(DataType.MultilineText)]
        public string TestimonialContent { get; set; }

        [Display(Name = "Nama")]
        [StringLength(80)]
        [Required(ErrorMessage = "Please enter a nama")]
        public string TestimonialUser { get; set; }

        [Display(Name = "Tanggal Upload")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime TestimonialDate { get; set; }

        public byte[] TestimonialImageData { get; set; }

        [Display(Name = "Image")]
        public string TestimonialMimeType { get; set; }

        [HiddenInput(DisplayValue = false)]
        public bool TestimonialStatus { get; set; }
    }
}
