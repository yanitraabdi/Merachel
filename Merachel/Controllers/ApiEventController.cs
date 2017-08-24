using Merachel.BusinessProcess;
using Merachel.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Merachel.Controllers
{
    [RoutePrefix("api/v1/event")]
    public class ApiEventController : ApiBaseController
    {
        EventServices oSvc = new EventServices();

        [HttpGet, Route("coursecategory")]
        public IHttpActionResult GetEvent(int? status = null, string title = "")
        {
            try
            {
                var result = oSvc.GetEvent(title, status);
                return Ok(result);
            }
            catch (Exception ex)
            {
                ExceptionModel oExc = oException.Set(ex);
                return Ok(oExc);
            }

        }

        [HttpPost, Route("event")]
        public IHttpActionResult PostEvent(EventModel data)
        {
            try
            {
                var result = oSvc.PostEvent(data);
                return Ok(result);
            }
            catch (Exception ex)
            {
                ExceptionModel exc = oException.Set(ex);
                return Ok(exc);
            }
        }

        [HttpPut, Route("event/{id}")]
        public IHttpActionResult PutEvent(int? id, EventModel data)
        {
            try
            {
                if (!id.HasValue)
                    return BadRequest();

                var result = oSvc.PutEvent(id.Value, data);
                return Ok(result);
            }
            catch (Exception ex)
            {
                ExceptionModel exc = oException.Set(ex);
                return Ok(exc);
            }
        }

        [HttpDelete, Route("coursecategory/{id:int}")]
        public IHttpActionResult DeleteEvent(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return BadRequest();

                List<int?> ids = new List<int?>();
                ids.Add(id.Value);

                var result = oSvc.DeleteEvent(ids);
                return Ok(result);
            }
            catch (Exception ex)
            {
                EventModel result = new EventModel()
                {
                    //Exception = _exception.Set(ExceptionType.CATCH, ex)
                };
                return Ok(ex);
            };
        }
    }
}