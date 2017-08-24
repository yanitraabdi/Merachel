using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merachel.Models
{
    public class BlogCategoryModel : GeneralModel
    {
        public int BlogCategoryID { get; set; }
        public string BlogCategoryName { get; set; }
        public int? Status { get; set; }
        public string StatusDescription { get; set; }
    }
}
