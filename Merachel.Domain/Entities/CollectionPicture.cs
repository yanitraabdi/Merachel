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
    public class CollectionPicture
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int CollectionPictureID { get; set; }

        public byte[] CollectionPictureImageData { get; set; }

        [Display(Name = "Image")]
        public string CollectionPictureMimeType { get; set; }

        [HiddenInput(DisplayValue = false)]
        public bool CollectionPictureStatus { get; set; }
        
        [Display(Name = "CollectionID")]
        public int? CollectionID { get; set; }

        [ForeignKey("CollectionID")]
        public virtual Collection Collection { get; set; }
    }
}
