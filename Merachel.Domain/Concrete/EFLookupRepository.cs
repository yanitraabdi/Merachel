using Merachel.Domain.Abstract;
using Merachel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merachel.Domain.Concrete
{
    public class EFLookupRepository : ILookupRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Lookup> Lookups
        {
            get { return context.Lookups; }
        }

        public void SaveLookup(Lookup lookup)
        {
            if (lookup.LookupID == 0)
            {
                lookup.LookupStatus = true;
                lookup.LookupCreatedDate = DateTime.Now;
                context.Lookups.Add(lookup);
            }
            else
            {
                Lookup dbEntry = context.Lookups.Find(lookup.LookupID);
                if (dbEntry != null)
                {
                    dbEntry.LookupCode = lookup.LookupCode;
                    dbEntry.LookupCategory = lookup.LookupCategory;
                    dbEntry.LookupDescription = lookup.LookupDescription;
                    dbEntry.LookupSequenceNumber = lookup.LookupSequenceNumber;
                    dbEntry.LookupType = lookup.LookupType;
                    dbEntry.LookupStatus = true;
                }
            }
            context.SaveChanges();
        }

        public Lookup DeleteLookup(int lookupid)
        {
            Lookup dbEntry = context.Lookups.Find(lookupid);
            if (dbEntry != null)
            {
                dbEntry.LookupStatus = false;
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
