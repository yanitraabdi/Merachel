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
    [RoutePrefix("api/v1/tutor")]
    public class ApiTutorController : ApiBaseController
    {
        TutorServices oSvc = new TutorServices();

        [HttpGet, Route("")]
        public IHttpActionResult GetTutors(string employeename = "", int? status = null, string employeedescription = "", string employeespecial = "")
        {
            try
            {
                var result = oSvc.GetTutors(employeename, status, employeedescription, employeespecial);
                return Ok(result);
            }
            catch (Exception ex)
            {
                ExceptionModel oExc = oException.Set(ex);
                return Ok(oExc);
            }

        }

        [HttpPost, Route("")]
        public IHttpActionResult PostTutor(TutorModel data)
        {
            try
            {
                var result = oSvc.PostTutor(data);
                return Ok(result);
            }
            catch (Exception ex)
            {
                ExceptionModel exc = oException.Set(ex);
                return Ok(exc);
            }
        }

        [HttpPut, Route("{id}")]
        public IHttpActionResult PutTutor(int? id, TutorModel data)
        {
            try
            {
                if (!id.HasValue)
                    return BadRequest();

                var result = oSvc.PutTutor(id.Value, data);
                return Ok(result);
            }
            catch (Exception ex)
            {
                ExceptionModel exc = oException.Set(ex);
                return Ok(exc);
            }
        }

        [HttpDelete, Route("{id:int}")]
        public IHttpActionResult DeleteTutor(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return BadRequest();

                List<int?> ids = new List<int?>();
                ids.Add(id.Value);

                var result = oSvc.DeleteTutor(ids);
                return Ok(result);
            }
            catch (Exception ex)
            {
                TutorModel result = new TutorModel()
                {
                    //Exception = _exception.Set(ExceptionType.CATCH, ex)
                };
                return Ok(ex);
            };
        }
    }
}