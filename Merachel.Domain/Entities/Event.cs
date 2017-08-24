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
    public class Event
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int EventID { get; set; }

        [Display(Name = "Nama Event")]
        [StringLength(100)]
        [Required(ErrorMessage = "Tolong masukkan Nama Event")]
        public string EventName { get; set; }

        [Display(Name = "Deskripsi Event")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Tolong masukkan Deskripsi Event")]
        public string EventDescription { get; set; }

        [Display(Name = "Lokasi Event")]
        [StringLength(200)]
        [Required(ErrorMessage = "Tolong masukkan Lokasi Event")]
        public string EventLocation { get; set; }

        [Display(Name = "Nama Host")]
        [StringLength(100)]
        public string EventHost { get; set; }
        
        [Display(Name = "Jam Mulai")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm}")]
        public DateTime EventTimeStart { get; set; }

        [Display(Name = "Jam Berakhir")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm}")]
        public DateTime EventTimeEnd { get; set; }

        [Display(Name = "Tanggal Upload")]
        [HiddenInput(DisplayValue = false)]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime EventDateCreated { get; set; }

        [Display(Name = "Tanggal Mulai")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Tolong masukkan Tanggal Mulai Event")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime EventBeginDate { get; set; }

        [Display(Name = "Tanggal Berakhir")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Tolong masukkan Tanggal Berakhir Event")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime EventEndDate { get; set; }
        
        [HiddenInput(DisplayValue = false)]
        [Display(Name = "UserID")]
        public int? UserID { get; set; }

        [ForeignKey("UserID")]
        public virtual User User { get; set; }

        [HiddenInput(DisplayValue = false)]
        public bool EventStatus { get; set; }

        public virtual ICollection<EventPrice> EventPrice { get; set; }
        public virtual ICollection<EventPicture> EventPicture { get; set; }
    }
}
