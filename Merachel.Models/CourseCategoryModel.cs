using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merachel.Models
{
    public class CourseCategoryModel : GeneralModel
    {
        public int CourseCategoryID { get; set; }
        public string CourseCategoryName { get; set; }
        public string CourseCategoryDescription { get; set; }
        public int Status { get; set; }
    }
}
