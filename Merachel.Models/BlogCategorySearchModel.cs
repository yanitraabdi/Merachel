using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merachel.Models
{
    public class BlogCategorySearchModel : GeneralModel
    {
        public int TotalCount { get; set; }
        public IEnumerable<Select2Model> Items { get; set; }
    }
}
