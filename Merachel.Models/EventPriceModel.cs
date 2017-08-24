using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merachel.Models
{
    public class EventPriceModel : GeneralModel
    {
        public int EventID { get; set; }
        public int EventPriceID { get; set; }
        public string EventPriceName { get; set; }
        public string EventPriceQuota { get; set; }
        public decimal EventPriceTotal { get; set; }
        public int Status { get; set; }
    }
}
