using Merachel.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Merachel.Controllers
{
    public class ApiBaseController : ApiController
    {
        public ExceptionManagement oException;

        public ApiBaseController()
        {
            oException = new ExceptionManagement();
        }
    }
}