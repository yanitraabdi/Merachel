using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Merachel.Domain.Abstract;
using Merachel.Domain.Entities;

namespace Merachel.Domain.Concrete
{
    public class EFCollectionRepository : ICollectionRepository 
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Collection> Collections
        {
            get { return context.Collections; }
        }

        public void SaveCollection(Collection collection)
        {
            if (collection.CollectionID == 0)
            {
                collection.CollectionStatus = true;
                collection.CollectionDate = DateTime.Now;
                context.Collections.Add(collection);
            }
            else
            {
                Collection dbEntry = context.Collections.Find(collection.CollectionID);
                if (dbEntry != null)
                {
                    dbEntry.CollectionTitle = collection.CollectionTitle;
                    dbEntry.CollectionStatus = true;
                }
            }
            context.SaveChanges();
        }

        public Collection DeleteCollection(int collectionid)
        {
            Collection dbEntry = context.Collections.Find(collectionid);
            if (dbEntry != null)
            {
                dbEntry.CollectionStatus = false;
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
