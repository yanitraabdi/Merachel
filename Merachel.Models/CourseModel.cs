using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merachel.Models
{
    public class CourseModel : GeneralModel
    {
        public int CourseID { get; set; }
        public int CourseCategoryID { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public string CoursePictureFilePath { get; set; }
        public string CoursePictureFileName { get; set; }
        public int Status { get; set; }
        
        public List<CoursePriceModel> ListPrice { get; set; }
    }
}
