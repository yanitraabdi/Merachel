using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Merachel.Domain.Abstract;
using Merachel.Domain.Entities;

namespace Merachel.Domain.Concrete
{
    public class EFCollectionPictureRepository : IColletionPictureRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<CollectionPicture> CollectionPictures
        {
            get { return context.CollectionPictures; }
        }

        public void SaveCollectionPicture(CollectionPicture collectionpicture)
        {
            if (collectionpicture.CollectionPictureID == 0)
            {
                collectionpicture.CollectionPictureStatus = true;
                context.CollectionPictures.Add(collectionpicture);
            }
            else
            {
                CollectionPicture dbEntry = context.CollectionPictures.Find(collectionpicture.CollectionPictureID);
                if (dbEntry != null)
                {
                    dbEntry.CollectionPictureImageData = collectionpicture.CollectionPictureImageData;
                    dbEntry.CollectionPictureMimeType = collectionpicture.CollectionPictureMimeType;
                    dbEntry.CollectionPictureStatus = true;
                }
            }
            context.SaveChanges();
        }

        public CollectionPicture DeleteCollectionPicture(int collectionpictureid)
        {
            CollectionPicture dbEntry = context.CollectionPictures.Find(collectionpictureid);
            if (dbEntry != null)
            {
                dbEntry.CollectionPictureStatus = false;
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
