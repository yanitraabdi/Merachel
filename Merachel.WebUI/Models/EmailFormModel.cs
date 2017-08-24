using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Merachel.WebUI.Models
{
    public class EmailFormModel
    {
        [Required, Display(Name = "Nama Lengkap")]
        public string FromName { get; set; }
        [Required, Display(Name = "Email Anda"), EmailAddress]
        public string FromEmail { get; set; }
        [Required, Display(Name = "Telepon")]
        public string FromPhone { get; set; }
        [Required, Display(Name = "Judul Pesan")]
        public string Subject { get; set; }
        [Required, Display(Name = "Pesan")]
        public string Message { get; set; }
    }
}