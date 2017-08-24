using Merachel.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Merachel.WebUI.Controllers
{
    [RoutePrefix("api/v1/lookup")]
    public class ApiLookupController : ApiController
    {
        private ILookupRepository lookuprepository;

        public ApiLookupController(
            ILookupRepository lookuprepo)
        {
            lookuprepository = lookuprepo;
        }

        //[HttpGet, Route("")]
        //public IHttpActionResult GetLookups(string type = "", string description = "", string category = "", int? status = null)
        //{
        //    try
        //    {
        //        var result = lookuprepository.Lookups(type, description, category, status);
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        LookupViewModels result = new LookupViewModels()
        //        {
        //            //Exception = _exception.Set(ExceptionType.CATCH, ex)
        //        };
        //        return Ok(ex);
        //    }
        //}

        //[HttpGet, Route("Data")]
        //public IHttpActionResult GetLookupsData(string category = "")
        //{
        //    try
        //    {
        //        var result = _svc.GetLookupsData(category);
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        LookupViewModels result = new LookupViewModels()
        //        {
        //            //Exception = _exception.Set(ExceptionType.CATCH, ex)
        //        };
        //        return Ok(ex);
        //    }
        //}

        //[HttpGet, Route("Setting")]
        //public IHttpActionResult GetLookupsSetting(string category = "")
        //{
        //    try
        //    {
        //        var result = _svc.GetLookupsSetting(category);
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        LookupViewModels result = new LookupViewModels()
        //        {
        //            //Exception = _exception.Set(ExceptionType.CATCH, ex)
        //        };
        //        return Ok(ex);
        //    }
        //}

        //[HttpGet, Route("Category")]
        //public IHttpActionResult GetLookupsCategory(int? status = null)
        //{
        //    try
        //    {
        //        var result = _svc.GetLookupsCategory(status);
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        ExceptionModel oExc = oException.Set(ex);
        //        return Ok(oExc);
        //    }
        //}

        //[HttpDelete, Route("{id:int}")]
        //public IHttpActionResult DeleteLookup(int? id, int? userId)
        //{
        //    try
        //    {
        //        if (!id.HasValue)
        //            return BadRequest();

        //        List<int?> ids = new List<int?>();
        //        ids.Add(id.Value);

        //        var result = _svc.DeleteLookup(ids, userId);
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        LookupViewModels result = new LookupViewModels()
        //        {
        //            //Exception = _exception.Set(ExceptionType.CATCH, ex)
        //        };
        //        return Ok(result);
        //    };
        //}

        //[HttpPost, Route("")]
        //public IHttpActionResult PostLookup(LookupModel data)
        //{
        //    try
        //    {
        //        var result = _svc.PostLookup(data);
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        LookupModel result = new LookupModel()
        //        {
        //            //Exception = _exception.Set(ExceptionType.CATCH, ex)
        //        };
        //        return Ok(ex);
        //    }
        //}

        //[HttpPut, Route("{id}")]
        //public IHttpActionResult PutLookup(int? id, LookupModel data)
        //{
        //    try
        //    {
        //        if (!id.HasValue)
        //            return BadRequest();

        //        var result = _svc.PutLookup(id.Value, data);
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        LookupModel result = new LookupModel()
        //        {
        //            //Exception = _exception.Set(ExceptionType.CATCH, ex)
        //        };
        //        return Ok(ex);
        //    }
        //}
    }
}