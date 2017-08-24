using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Merachel.Domain.Abstract;
using Merachel.Domain.Entities;

namespace Merachel.Domain.Concrete
{
    public class EFEventPriceRepository : IEventPriceRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<EventPrice> EventPrices
        {
            get { return context.EventPrices; }
        }

        public void SaveEventPrice(EventPrice eventprice)
        {
            if (eventprice.EventPriceID == 0)
            {
                eventprice.EventPriceStatus = true;
                eventprice.EventPriceDate = DateTime.Now;
                context.EventPrices.Add(eventprice);
            }
            else
            {
                EventPrice dbEntry = context.EventPrices.Find(eventprice.EventPriceID);
                if (dbEntry != null)
                {
                    dbEntry.EventPriceName = eventprice.EventPriceName;
                    dbEntry.EventPriceQuota = eventprice.EventPriceQuota;
                    dbEntry.EventPriceTotal = eventprice.EventPriceTotal;
                    dbEntry.EventPriceStatus = true;
                }
            }
            context.SaveChanges();
        }

        public EventPrice DeleteEventPrice(int eventpriceid)
        {
            EventPrice dbEntry = context.EventPrices.Find(eventpriceid);
            if (dbEntry != null)
            {
                dbEntry.EventPriceStatus = false;
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
