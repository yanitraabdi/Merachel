using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Merachel.Domain.Entities;

namespace Merachel.Domain.Abstract
{
    public interface IColletionPictureRepository
    {
        IQueryable<CollectionPicture> CollectionPictures { get; }

        void SaveCollectionPicture(CollectionPicture collectionpicture);
        CollectionPicture DeleteCollectionPicture(int collectionpictureid);
    }
}
