using Merachel.Domain.Abstract;
using Merachel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Merachel.WebUI.Controllers
{
    [RoutePrefix("api/v1/blog")]
    public class ApiBlogController : ApiController
    {
        //IBlogRepository blogrepository = new IBlogRepository();

        //[HttpGet, Route("")]
        //public IHttpActionResult GetRoles(string name = "", int? memberId = null, int? status = null)
        //{
        //    try
        //    {
        //        var roles = _svc.GetRoles(name, memberId, status);
        //        foreach (RoleModel role in roles)
        //        {
        //            role.Members = _svc.GetRoleMembers(role.RoleId);
        //        }

        //        return Ok(roles);
        //    }
        //    catch (Exception ex)
        //    {
        //        RoleViewModels result = new RoleViewModels()
        //        {
        //            //Exception = _exception.Set(ExceptionType.CATCH, ex)
        //        };
        //        return Ok(ex);
        //    }
        //}

        //[HttpDelete, Route("{id:int}")]
        //public IHttpActionResult DeleteRoles(int? id)
        //{
        //    ExceptionModel oResult = new ExceptionModel();
        //    try
        //    {
        //        if (!id.HasValue)
        //            return BadRequest();

        //        var result = _svc.DeleteRoles(id.Value);
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        RoleViewModels result = new RoleViewModels()
        //        {
        //            //Exception = _exception.Set(ExceptionType.CATCH, ex)
        //        };
        //        return Ok(ex);
        //    };
        //}

        //[HttpPost, Route("")]
        //public IHttpActionResult PostRole(RoleModel data)
        //{
        //    try
        //    {
        //        var result = _svc.PostRoles(data);
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        RoleModel result = new RoleModel()
        //        {
        //            //Exception = _exception.Set(ExceptionType.CATCH, ex)
        //        };
        //        return Ok(ex);
        //    }
        //}

        //[HttpPut, Route("{id}")]
        //public IHttpActionResult PutRole(int? id, RoleModel data)
        //{
        //    try
        //    {
        //        if (!id.HasValue)
        //            return BadRequest();

        //        var result = _svc.PutRole(id.Value, data);
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        RoleModel result = new RoleModel()
        //        {
        //            //Exception = _exception.Set(ExceptionType.CATCH, ex)
        //        };
        //        return Ok(ex);
        //    }
        //}
    }
}