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
    public class EventPrice
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int EventPriceID { get; set; }

        [Display(Name = "Nama Tiket")]
        [StringLength(100)]
        [Required(ErrorMessage = "Tolong masukkan Nama Tiket")]
        public string EventPriceName { get; set; }

        [Display(Name = "Harga Tiket")]
        [Required(ErrorMessage = "Tolong masukkan Harga Tiket")]
        public decimal EventPriceTotal { get; set; }

        [Display(Name = "Jumlah Tiket")]
        [StringLength(5)]
        [Required(ErrorMessage = "Tolong masukkan Jumlah Tiket")]
        public string EventPriceQuota { get; set; }

        [HiddenInput(DisplayValue = false)]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm}")]
        public DateTime EventPriceDate { get; set; }

        [HiddenInput(DisplayValue = false)]
        public bool EventPriceStatus { get; set; }

        [Display(Name = "Event ID")]
        public int? EventID { get; set; }

        [ForeignKey("EventID")]
        public virtual Event Event { get; set; }
    }
}
