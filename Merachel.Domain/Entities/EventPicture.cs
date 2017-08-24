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
    public class EventPicture
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int EventPictureID { get; set; }

        public byte[] EventPictureImageData { get; set; }

        [Display(Name = "Image")]
        public string EventPictureMimeType { get; set; }

        [HiddenInput(DisplayValue = false)]
        public bool EventPictureStatus { get; set; }

        [Display(Name = "EventID")]
        public int? EventID { get; set; }

        [ForeignKey("EventID")]
        public virtual Event Event { get; set; }
    }
}
