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
    [RoutePrefix("api/v1/testimonial")]
    public class ApiTestimonialController : ApiBaseController
    {
        TestimonialServices oSvc = new TestimonialServices();

        [HttpGet, Route("")]
        public IHttpActionResult GetTestimonials(string testimonialuser = "", int? status = null, string testimonialcontent = "")
        {
            try
            {
                var result = oSvc.GetTestimonials(testimonialuser, status, testimonialcontent);
                return Ok(result);
            }
            catch (Exception ex)
            {
                ExceptionModel oExc = oException.Set(ex);
                return Ok(oExc);
            }

        }

        [HttpPost, Route("")]
        public IHttpActionResult PostTestimonial(TestimonialModel data)
        {
            try
            {
                var result = oSvc.PostTestimonial(data);
                return Ok(result);
            }
            catch (Exception ex)
            {
                ExceptionModel exc = oException.Set(ex);
                return Ok(exc);
            }
        }

        [HttpPut, Route("{id}")]
        public IHttpActionResult PutTestimonial(int? id, TestimonialModel data)
        {
            try
            {
                if (!id.HasValue)
                    return BadRequest();

                var result = oSvc.PutTestimonial(id.Value, data);
                return Ok(result);
            }
            catch (Exception ex)
            {
                ExceptionModel exc = oException.Set(ex);
                return Ok(exc);
            }
        }

        [HttpDelete, Route("{id:int}")]
        public IHttpActionResult DeleteTestimonial(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return BadRequest();

                List<int?> ids = new List<int?>();
                ids.Add(id.Value);

                var result = oSvc.DeleteTestimonial(ids);
                return Ok(result);
            }
            catch (Exception ex)
            {
                TestimonialModel result = new TestimonialModel()
                {
                    //Exception = _exception.Set(ExceptionType.CATCH, ex)
                };
                return Ok(ex);
            };
        }
    }
}