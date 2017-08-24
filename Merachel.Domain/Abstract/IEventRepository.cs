using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Merachel.Domain.Entities;

namespace Merachel.Domain.Abstract
{
    public interface IEventRepository
    {
        IQueryable<Event> Events { get; }

        void SaveEvent(Event events);
        Event DeleteEvent(int eventid);
    }
}
