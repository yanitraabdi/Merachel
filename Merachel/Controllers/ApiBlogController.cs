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
    [RoutePrefix("api/v1/blogs")]
    public class ApiBlogController : ApiBaseController
    {
        BlogServices oSvc = new BlogServices();

        [HttpGet, Route("")]
        public IHttpActionResult GetBlogs(string title = "", int? status = null, int? categoryId = null, DateTime? startDate = null, DateTime? endDate = null, int? blogid = null, int? limit = null)
        {
            try
            {
                var result = oSvc.GetBlogs(title, status, categoryId, startDate, endDate, blogid, limit);
                return Ok(result);
            }
            catch (Exception ex)
            {
                ExceptionModel oExc = oException.Set(ex);
                return Ok(oExc);
            }

        }

        [HttpPost, Route("")]
        public IHttpActionResult PostBlog(BlogModel data)
        {
            try
            {
                var result = oSvc.PostBlog(data);
                return Ok(result);
            }
            catch (Exception ex)
            {
                ExceptionModel exc = oException.Set(ex);
                return Ok(exc);
            }
        }

        [HttpPut, Route("{id}")]
        public IHttpActionResult PutBlog(int? id, BlogModel data)
        {
            try
            {
                if (!id.HasValue)
                    return BadRequest();

                var result = oSvc.PutBlog(id.Value, data);
                return Ok(result);
            }
            catch (Exception ex)
            {
                ExceptionModel exc = oException.Set(ex);
                return Ok(exc);
            }
        }

        [HttpDelete, Route("{id:int}")]
        public IHttpActionResult DeleteBlog(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return BadRequest();

                List<int?> ids = new List<int?>();
                ids.Add(id.Value);

                var result = oSvc.DeleteBlog(ids);
                return Ok(result);
            }
            catch (Exception ex)
            {
                BlogModel result = new BlogModel()
                {
                    //Exception = _exception.Set(ExceptionType.CATCH, ex)
                };
                return Ok(ex);
            };
        }
    }
}