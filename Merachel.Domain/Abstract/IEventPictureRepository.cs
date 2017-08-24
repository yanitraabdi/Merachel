using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Merachel.Domain.Entities;

namespace Merachel.Domain.Abstract
{
    public interface IEventPictureRepository
    {
        IQueryable<EventPicture> EventPictures { get; }

        void SaveEventPicture(EventPicture picture);
        EventPicture DeleteEventPicture(int pictureid);
    }
}
