using Merachel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merachel.Libraries
{
    public class ExceptionManagement
    {
        private ExceptionModel oResult;

        public ExceptionManagement()
        {
            oResult = new ExceptionModel();
        }

        public ExceptionModel Set(Exception ex)
        {
            oResult.ErrorCode = 9999;
            oResult.ErrorDesc = ex.Message;

            return oResult;
        }

        public ExceptionModel Set(int errorCode, string message)
        {
            oResult.ErrorCode = errorCode;
            oResult.ErrorDesc = message;

            return oResult;
        }
    }
}
