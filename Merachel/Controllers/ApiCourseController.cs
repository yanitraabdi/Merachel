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
    public class ApiCourseController : ApiBaseController
    {
        CourseServices oSvc = new CourseServices();

        [HttpGet, Route("")]
        public IHttpActionResult GetCourses(int? courseid = null, int? status = null, int? coursecategoryid = null, string coursecategorydescription = "")
        {
            try
            {
                var result = oSvc.GetCourse(courseid, status, coursecategoryid, coursecategorydescription);
                return Ok(result);
            }
            catch (Exception ex)
            {
                ExceptionModel oExc = oException.Set(ex);
                return Ok(oExc);
            }

        }

        [HttpPost, Route("")]
        public IHttpActionResult PostCourse(CourseModel data)
        {
            try
            {
                var result = oSvc.PostCourse(data);
                return Ok(result);
            }
            catch (Exception ex)
            {
                ExceptionModel exc = oException.Set(ex);
                return Ok(exc);
            }
        }

        [HttpPut, Route("{id}")]
        public IHttpActionResult PutCourse(int? id, CourseModel data)
        {
            try
            {
                if (!id.HasValue)
                    return BadRequest();

                var result = oSvc.PutCourse(id.Value, data);
                return Ok(result);
            }
            catch (Exception ex)
            {
                ExceptionModel exc = oException.Set(ex);
                return Ok(exc);
            }
        }

        [HttpDelete, Route("{id:int}")]
        public IHttpActionResult DeleteCourse(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return BadRequest();

                List<int?> ids = new List<int?>();
                ids.Add(id.Value);

                var result = oSvc.DeleteCourse(ids);
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
