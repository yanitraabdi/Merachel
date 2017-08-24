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
    [RoutePrefix("api/v1/course")]
    public class ApiCourseContoller : ApiBaseController
    {
        CourseCategoryServices oSvc = new CourseCategoryServices();
        CourseServices cSvc = new CourseServices();

        [HttpGet, Route("coursecategory")]
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

        [HttpPost, Route("coursecategory")]
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

        [HttpPut, Route("coursecategory/{id}")]
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

        [HttpDelete, Route("coursecategory/{id:int}")]
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

        [HttpGet, Route("course")]
        public IHttpActionResult GetCourses(string title = "", int? status = null)
        {
            try
            {
                var result = cSvc.GetCourse(title, status);
                return Ok(result);
            }
            catch (Exception ex)
            {
                ExceptionModel oExc = oException.Set(ex);
                return Ok(oExc);
            }

        }

        [HttpPost, Route("course")]
        public IHttpActionResult PostCourse(CourseModel data)
        {
            try
            {
                var result = cSvc.PostCourse(data);
                return Ok(result);
            }
            catch (Exception ex)
            {
                ExceptionModel exc = oException.Set(ex);
                return Ok(exc);
            }
        }

        [HttpPut, Route("course/{id}")]
        public IHttpActionResult PutCourse(int? id, CourseModel data)
        {
            try
            {
                if (!id.HasValue)
                    return BadRequest();

                var result = cSvc.PutCourse(id.Value, data);
                return Ok(result);
            }
            catch (Exception ex)
            {
                ExceptionModel exc = oException.Set(ex);
                return Ok(exc);
            }
        }

        [HttpDelete, Route("course/{id:int}")]
        public IHttpActionResult DeleteCourse(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return BadRequest();

                List<int?> ids = new List<int?>();
                ids.Add(id.Value);

                var result = cSvc.DeleteCourse(ids);
                return Ok(result);
            }
            catch (Exception ex)
            {
                CourseModel result = new CourseModel()
                {
                    //Exception = _exception.Set(ExceptionType.CATCH, ex)
                };
                return Ok(ex);
            };
        }
    }
}