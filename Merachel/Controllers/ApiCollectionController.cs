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
    [RoutePrefix("api/v1/collections")]
    public class ApiCollectionController : ApiBaseController
    {
        CollectionServices oSvc = new CollectionServices();

        [HttpGet, Route("")]
        public IHttpActionResult GetCollections(string title = "", int? status = null)
        {
            try
            {
                var result = oSvc.GetCollection(title, status);
                return Ok(result);
            }
            catch (Exception ex)
            {
                ExceptionModel oExc = oException.Set(ex);
                return Ok(oExc);
            }

        }

        [HttpPost, Route("")]
        public IHttpActionResult PostCollection(CollectionModel data)
        {
            try
            {
                var result = oSvc.PostCollection(data);
                return Ok(result);
            }
            catch (Exception ex)
            {
                ExceptionModel exc = oException.Set(ex);
                return Ok(exc);
            }
        }

        [HttpPut, Route("{id}")]
        public IHttpActionResult PutCollection(int? id, CollectionModel data)
        {
            try
            {
                if (!id.HasValue)
                    return BadRequest();

                var result = oSvc.PutCollection(id.Value, data);
                return Ok(result);
            }
            catch (Exception ex)
            {
                ExceptionModel exc = oException.Set(ex);
                return Ok(exc);
            }
        }

        [HttpDelete, Route("{id:int}")]
        public IHttpActionResult DeleteCollection(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return BadRequest();

                List<int?> ids = new List<int?>();
                ids.Add(id.Value);

                var result = oSvc.DeleteCollection(ids);
                return Ok(result);
            }
            catch (Exception ex)
            {
                CollectionModel result = new CollectionModel()
                {
                    //Exception = _exception.Set(ExceptionType.CATCH, ex)
                };
                return Ok(ex);
            };
        }
    }
}