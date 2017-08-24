using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Merachel.Domain.Entities
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }

        [Display(Name = "Nama")]
        [Required(ErrorMessage = "Tolong masukkan nama Employee")]
        [StringLength(100)]
        public string EmployeeName { get; set; }

        [Display(Name = "Bidang")]
        [StringLength(100)]
        [Required(ErrorMessage = "Tolong masukkan Bidang")]
        public string EmployeeSpecial { get; set; }

        [Display(Name = "Deskripsi")]
        [Required(ErrorMessage = "Tolong masukkan deskripsi")]
        [DataType(DataType.MultilineText)]
        public string EmployeeDescription { get; set; }

        [Display(Name = "Tanggal Upload")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EmployeeDate { get; set; }

        public byte[] EmployeeImageData { get; set; }

        [Display(Name = "Foto")]
        public string EmployeeMimeType { get; set; }

        [HiddenInput(DisplayValue = false)]
        public bool EmployeeStatus { get; set; }
    }
}
