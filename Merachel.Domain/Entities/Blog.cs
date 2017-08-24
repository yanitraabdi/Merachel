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
    public class Blog
    {
        [Key]
        public int BlogID { get; set; }

        [Display(Name = "Judul Blog")]
        [Required(ErrorMessage = "Please enter a blog title")]
        [StringLength(200)]
        public string BlogTitle { get; set; }
        
        [Display(Name = "Konten")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Please enter a blog content")]
        public string BlogContent { get; set; }

        [Display(Name = "Tanggal Upload")]
        [DataType(DataType.Date)]
        public DateTime BlogDate { get; set; }

        [HiddenInput(DisplayValue = false)]
        public bool BlogStatus { get; set; }

        [Display(Name = "Kategori Blog")]
        public int? BlogCategoryID { get; set; }

        [ForeignKey("BlogCategoryID")]
        public virtual BlogCategory BlogCategory { get; set; }

        public byte[] BlogPictureImageData { get; set; }

        [Display(Name = "Thumbnail")]
        public string BlogPictureMimeType { get; set; }

        [HiddenInput(DisplayValue = false)]
        [Display(Name = "User ID")]
        public int? UserID { get; set; }

        [ForeignKey("UserID")]
        public virtual User User { get; set; }
    }
}
