using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Merachel.Domain.Entities
{
    public class Lookup
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int LookupID { get; set; }

        [Display(Name = "Nama Lookup")]
        [StringLength(100)]
        [Required(ErrorMessage = "Tolong masukkan Kategori Lookup")]
        public string LookupCategory { get; set; }

        [Display(Name = "Kode")]
        [StringLength(100)]
        [Required(ErrorMessage = "Tolong masukkan Kode Lookup")]
        public string LookupCode { get; set; }

        [Display(Name = "Type")]
        [StringLength(100)]
        [Required(ErrorMessage = "Tolong masukkan Tipe Lookup")]
        public string LookupType { get; set; }

        [Display(Name = "Description")]
        [StringLength(500)]
        [Required(ErrorMessage = "Tolong masukkan Deskripsi Lookup")]
        public string LookupDescription { get; set; }

        [Display(Name = "Sequence Number")]
        [StringLength(30)]
        public string LookupSequenceNumber { get; set; }

        [HiddenInput(DisplayValue = false)]
        [DataType(DataType.Date)]
        public DateTime LookupCreatedDate { get; set; }

        [HiddenInput(DisplayValue = false)]
        public bool LookupStatus { get; set; }
    }
}
