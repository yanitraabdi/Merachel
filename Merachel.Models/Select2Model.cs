using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merachel.Models
{
    public class Select2Model : GeneralModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int? ParentId { get; set; }

        public string AdditionalInfo1 { get; set; }
        public string AdditionalInfo2 { get; set; }
        public string AdditionalInfo3 { get; set; }
    }
}
