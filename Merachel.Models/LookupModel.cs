using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merachel.Models
{
    public class LookupModel : GeneralModel
    {
        public int LookupID { get; set; }
        public string LookupCategory { get; set; }
        public string LookupCode { get; set; }
        public string LookupDescription { get; set; }
        public int LookupSequenceNumber { get; set; }
        public int Status { get; set; }
        public string LookupType { get; set; }
        public string LookupValue { get; set; }
    }
}
