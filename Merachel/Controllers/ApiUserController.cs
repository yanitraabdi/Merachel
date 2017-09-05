using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Merachel.Models;
using Merachel.BusinessProcess;

namespace Merachel.Controllers
{
    [RoutePrefix("api/v1/users")]
    public class ApiUserController : ApiBaseController
    {
        UserServices _svc = new UserServices();
        [HttpGet, Route("")]
        public IHttpActionResult GetUsers(string userName = "", string userFullName = "", int? status = null)
        {
            try
            {
                var result = _svc.GetUsers(userName, userFullName, status);
                return Ok(result);
            }
            catch (Exception ex)
            {
                {
                    // Exception = _exception.Set(ExceptionType.CATCH, ex)
                };
                return Ok(ex);
            }

        }


        [HttpPut, Route("{id}")]
        public IHttpActionResult PutUser(int? id, UserModel data)
        {
            try
            {
                if (!id.HasValue)
                    return BadRequest();

                var result = _svc.PutUser(id.Value, data);
                return Ok(result);
            }
            catch (Exception ex)
            {
                {
                    //Exception = _exception.Set(ExceptionType.CATCH, ex)
                };
                return Ok(ex);
            }
        }

        [HttpPost, Route("")]
        public IHttpActionResult PostUser(UserModel data)
        {
            try
            {
                var result = _svc.PostUser(data);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
    }
}