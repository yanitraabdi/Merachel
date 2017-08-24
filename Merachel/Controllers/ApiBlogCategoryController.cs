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
    [RoutePrefix("api/v1/blogcategories")]
    public class ApiBlogCategoryController : ApiBaseController
    {
        BlogCategoryServices oSvc = new BlogCategoryServices();

        [HttpGet, Route("")]
        public IHttpActionResult GetBlogCategories(int? status = null, string categoryName = "")
        {
            try
            {
                var result = oSvc.GetBlogCategories(status, categoryName);
                return Ok(result);
            }
            catch (Exception ex)
            {
                ExceptionModel oExc = oException.Set(ex);
                return Ok(oExc);
            }

        }

        [HttpPost, Route("")]
        public IHttpActionResult PostBlogCategory(BlogCategoryModel data)
        {
            try
            {
                var result = oSvc.PostBlogCategory(data);
                return Ok(result);
            }
            catch (Exception ex)
            {
                ExceptionModel exc = oException.Set(ex);
                return Ok(exc);
            }
        }

        [HttpPut, Route("{id}")]
        public IHttpActionResult PutBlogCategory(int? id, BlogCategoryModel data)
        {
            try
            {
                if (!id.HasValue)
                    return BadRequest();

                var result = oSvc.PutBlogCategory(id.Value, data);
                return Ok(result);
            }
            catch (Exception ex)
            {
                ExceptionModel exc = oException.Set(ex);
                return Ok(exc);
            }
        }

        [HttpDelete, Route("{id:int}")]
        public IHttpActionResult DeleteBlogCategory(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return BadRequest();

                List<int?> ids = new List<int?>();
                ids.Add(id.Value);

                var result = oSvc.DeleteBlogCategory(ids);
                return Ok(result);
            }
            catch (Exception ex)
            {
                BlogCategoryModel result = new BlogCategoryModel()
                {
                    //Exception = _exception.Set(ExceptionType.CATCH, ex)
                };
                return Ok(ex);
            };
        }
    }
}