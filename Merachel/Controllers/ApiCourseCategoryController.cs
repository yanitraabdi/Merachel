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
    [RoutePrefix("api/v1/coursecategory")]
    public class ApiCourseCategoryController : ApiBaseController
    {
        CourseCategoryServices oSvc = new CourseCategoryServices();

        [HttpGet, Route("")]
        public IHttpActionResult GetCourseCategories(int? status = null, string categoryName = "")
        {
            try
            {
                var result = oSvc.GetCourseCategories(status, categoryName);
                return Ok(result);
            }
            catch (Exception ex)
            {
                ExceptionModel oExc = oException.Set(ex);
                return Ok(oExc);
            }

        }

        [HttpPost, Route("")]
        public IHttpActionResult PostCourseCategory(CourseCategoryModel data)
        {
            try
            {
                var result = oSvc.PostCourseCategory(data);
                return Ok(result);
            }
            catch (Exception ex)
            {
                ExceptionModel exc = oException.Set(ex);
                return Ok(exc);
            }
        }

        [HttpPut, Route("{id}")]
        public IHttpActionResult PutCourseCategory(int? id, CourseCategoryModel data)
        {
            try
            {
                if (!id.HasValue)
                    return BadRequest();

                var result = oSvc.PutCourseCategory(id.Value, data);
                return Ok(result);
            }
            catch (Exception ex)
            {
                ExceptionModel exc = oException.Set(ex);
                return Ok(exc);
            }
        }

        [HttpDelete, Route("{id:int}")]
        public IHttpActionResult DeleteCourseCategory(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return BadRequest();

                List<int?> ids = new List<int?>();
                ids.Add(id.Value);

                var result = oSvc.DeleteCourseCategory(ids);
                return Ok(result);
            }
            catch (Exception ex)
            {
                CourseCategoryModel result = new CourseCategoryModel()
                {
                    //Exception = _exception.Set(ExceptionType.CATCH, ex)
                };
                return Ok(ex);
            };
        }
    }
}
