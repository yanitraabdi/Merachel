using Merachel.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merachel.BusinessProcess
{
    public class GeneralServices : SessionConfiguration, IDisposable
    {
        public SQLContext db = new SQLContext();
        public ExceptionManagement oException;

        public void Dispose()
        {
            db.Dispose();
        }

        public GeneralServices()
        {
            db = new SQLContext();
            oException = new ExceptionManagement();
        }

        public string Right(string str, int length)
        {
            return str.Substring(str.Length - length, length);
        }

        public static string[] SplitFullName(string pFullName)
        {
            string newFullName = pFullName.Trim();
            string[] NameSurname = new string[2];
            string[] NameSurnameTemp = newFullName.Split(' ');

            if (NameSurnameTemp.Length == 1)
            {
                NameSurname[0] = newFullName;
                NameSurname[1] = newFullName;
            }
            else
            {
                NameSurname[0] = NameSurnameTemp[0];
                NameSurname[1] = newFullName.Replace(NameSurnameTemp[0], "").Trim();
            }

            return NameSurname;
        }

    }
}