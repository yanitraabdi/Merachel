using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Merachel.Domain.Entities
{
    public class Collection
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int CollectionID { get; set; }

        [Display(Name = "Nama Galeri")]
        [StringLength(100)]
        [Required(ErrorMessage = "Tolong masukkan nama galeri")]
        public string CollectionTitle { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(NullDisplayText = "", DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CollectionDate { get; set; }

        [HiddenInput(DisplayValue = false)]
        public bool CollectionStatus { get; set; }

        public virtual ICollection<CollectionPicture> CollectionPicture { get; set; }
    }
}
