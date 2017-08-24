using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merachel.Models
{
    public class CoursePriceModel : GeneralModel
    {
        public int CoursePriceID { get; set; }
        public int CourseID { get; set; }
        public string CoursePriceName { get; set; }
        public string CoursePriceDescription { get; set; }
        public decimal CoursePriceTotal { get; set; }
        public int Status { get; set; }
    }
}
