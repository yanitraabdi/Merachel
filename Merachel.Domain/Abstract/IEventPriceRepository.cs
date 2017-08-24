﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Merachel.Domain.Entities;

namespace Merachel.Domain.Abstract
{
    public interface IEventPriceRepository
    {
        IQueryable<EventPrice> EventPrices { get; }

        void SaveEventPrice(EventPrice eventprice);
        EventPrice DeleteEventPrice(int eventpriceid);
    }
}
