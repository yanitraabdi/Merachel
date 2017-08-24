using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Merachel.Domain.Abstract;
using Merachel.Domain.Entities;

namespace Merachel.Domain.Concrete
{
    public class EFEventRepository : IEventRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Event> Events
        {
            get { return context.Events; }
        }

        public void SaveEvent(Event events)
        {
            if (events.EventID == 0)
            {
                events.EventStatus = true;
                events.EventDateCreated = DateTime.Now;
                context.Events.Add(events);
            }
            else
            {
                Event dbEntry = context.Events.Find(events.EventID);
                if (dbEntry != null)
                {
                    dbEntry.EventName = events.EventName;
                    dbEntry.EventDescription = events.EventDescription;
                    dbEntry.EventBeginDate = events.EventBeginDate;
                    dbEntry.EventEndDate = events.EventEndDate;
                    dbEntry.EventLocation = events.EventLocation;
                    dbEntry.EventHost = events.EventHost;
                    dbEntry.EventTimeStart = events.EventTimeStart;
                    dbEntry.EventTimeEnd = events.EventTimeEnd;
                    dbEntry.EventStatus = true;
                }
            }
            context.SaveChanges();
        }

        public Event DeleteEvent(int eventid)
        {
            Event dbEntry = context.Events.Find(eventid);
            if (dbEntry != null)
            {
                dbEntry.EventStatus = false;
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
