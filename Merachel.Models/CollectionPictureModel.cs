using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merachel.Models
{
    public class CollectionPictureModel : GeneralModel
    {
        public int CollectionID { get; set; }
        public int CollectionPictureID { get; set; }
        public string CollectionPictureFileName { get; set; }
        public string CollectionPictureFilePath { get; set; }
        public int Status { get; set; }
    }
}
