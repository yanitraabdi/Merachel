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
    public class User
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int UserID { get; set; }

        [Display(Name = "Nama User")]
        [StringLength(100)]
        public string UserFullName { get; set; }

        [Display(Name = "Email User")]
        [StringLength(30)]
        [Required(ErrorMessage = "Tolong masukkan Email Anda")]
        [DataType(DataType.EmailAddress)]
        public string UserEmail { get; set; }

        [Display(Name = "Deskripsi")]
        [DataType(DataType.MultilineText)]
        public string UserDescription { get; set; }

        [Display(Name = "Password")]
        [StringLength(30)]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Tolong masukkan Password Anda")]
        public string UserPassword { get; set; }

        [Display(Name = "Telepon User")]
        [StringLength(30)]
        public string UserPhone { get; set; }

        [Display(Name = "Alamat User")]
        [StringLength(250)]
        public string UserAddress { get; set; }

        [Display(Name = "Role")]
        [StringLength(30)]
        public string UserRole { get; set; }

        [HiddenInput(DisplayValue = false)]
        [DataType(DataType.Date)]
        public DateTime UserJoinDate { get; set; }

        [HiddenInput(DisplayValue = false)]
        public bool UserStatus { get; set; }
    }
}
