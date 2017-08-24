using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Merachel.Libraries
{
    public class DataAccessBase
    {
        public static string GetConnectionString()
        {
            string datasource = ConfigurationManager.AppSettings["datasource"].ToString();
            string catalog = ConfigurationManager.AppSettings["catalog"].ToString();
            string uid = ConfigurationManager.AppSettings["uid"].ToString();
            string pwd = ConfigurationManager.AppSettings["pwd"].ToString();

            CryptographyConfiguration cm = new CryptographyConfiguration();

            string deUid = cm.DecryptText(uid);
            string dePwd = cm.DecryptText(pwd);

            string constring = @"Data Source=" + datasource + @";
                                        Initial Catalog=" + catalog + @";
                                        User ID=" + deUid + @";
                                        Password=" + dePwd + @"";

            return constring;
        }
    }
}
