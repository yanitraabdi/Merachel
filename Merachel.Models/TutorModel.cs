using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merachel.Models
{
    public class TutorModel : GeneralModel
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeDescription { get; set; }
        public string EmployeeSpecial { get; set; }
        public string EmployeeFileName { get; set; }
        public string EmployeeFilePath { get; set; }
        public int? Status { get; set; }
    }
}
