using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Merachel.Domain.Entities;

namespace Merachel.Domain.Abstract
{
    public interface ICollectionRepository
    {
        IQueryable<Collection> Collections { get; }

        void SaveCollection(Collection collection);
        Collection DeleteCollection(int collectionid);
    }
}
