using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merachel.Models
{
    public class EventPictureModel : GeneralModel
    {
        public int EventID { get; set; }
        public int EventPictureID { get; set; }
        public string EventPictureFileName { get; set; }
        public string EventPictureFilePath { get; set; }
        public int Status { get; set; }
    }
}
