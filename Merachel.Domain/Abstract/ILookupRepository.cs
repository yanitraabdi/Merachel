using Merachel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merachel.Domain.Abstract
{
    public interface ILookupRepository
    {
        IQueryable<Lookup> Lookups { get; }

        void SaveLookup(Lookup lookup);
        Lookup DeleteLookup(int lookupid);
    }
}
