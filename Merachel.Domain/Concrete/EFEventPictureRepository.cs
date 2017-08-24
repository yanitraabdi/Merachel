using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Merachel.Domain.Abstract;
using Merachel.Domain.Entities;

namespace Merachel.Domain.Concrete
{
    public class EFEventPictureRepository : IEventPictureRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<EventPicture> EventPictures
        {
            get { return context.EventPictures; }
        }

        public void SaveEventPicture(EventPicture eventpicture)
        {
            if (eventpicture.EventPictureID == 0)
            {
                eventpicture.EventPictureStatus = true;
                context.EventPictures.Add(eventpicture);
            }
            else
            {
                EventPicture dbEntry = context.EventPictures.Find(eventpicture.EventPictureID);
                if (dbEntry != null)
                {
                    dbEntry.EventPictureImageData = eventpicture.EventPictureImageData;
                    dbEntry.EventPictureMimeType = eventpicture.EventPictureMimeType;
                    dbEntry.EventPictureStatus = true;
                }
            }
            context.SaveChanges();
        }

        public EventPicture DeleteEventPicture(int pictureid)
        {
            EventPicture dbEntry = context.EventPictures.Find(pictureid);
            if (dbEntry != null)
            {
                dbEntry.EventPictureStatus = false;
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
