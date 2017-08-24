using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merachel.Models
{
    public class GeneralModel
    {
        public ExceptionModel Exception { get; set; }

        public GeneralModel()
        {
            Exception = new ExceptionModel();
        }

        public int CreatedBy { get; set; }
        public DateTime UtcCreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime utcModifiedDate { get; set; }
    }
}
