using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merachel.Models
{
    public class CollectionModel : GeneralModel
    {
        public int CollectionID { get; set; }
        public string CollectionTitle { get; set; }
        public int Status { get; set; }
        
        public List<CollectionPictureModel> ListPicture { get; set; }
    }
}
