using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;

using EnumStringValues;
using Dapper;

using Merachel.Models;
using Merachel.Libraries;

namespace Merachel.BusinessProcess
{
    public class UserServices : GeneralServices
    {
        public ICollection<UserModel> GetUsers(string userEmail, string userFullName, int? status)
        {
            using (var conn = new SQLContext().Database.Connection)
            {
                using (var reader = conn.QueryMultiple("dbo.s_get_users", new { userEmail = userEmail, userFullName = userFullName, status = status }, commandType: System.Data.CommandType.StoredProcedure))
                {
                    var result = reader.Read<UserModel>().ToList();
                    return result;
                }
            }
        }

        public ExceptionModel PutUser(int userId, UserModel data)
        {
            ExceptionModel oResult = new ExceptionModel();
            try
            {
                string xml = Helper.XmlSerializer<UserModel>(data);
                using (var context = new SQLContext())
                {
                    SqlParameter[] param = new SqlParameter[2];
                    param[0] = new SqlParameter("@userId", SqlDbType.Int);
                    param[0].Value = userId;
                    param[1] = new SqlParameter("@data", SqlDbType.Xml);
                    param[1].Value = xml;

                    context.Database.ExecuteSqlCommand(
                        "[dbo].[s_put_users] @userId, @data",
                        param);
                }
            }
            catch (Exception ex)
            {
                oResult = oException.Set(ex);
            }
            return oResult;
        }

        public ExceptionModel PostUser(UserModel data)
        {
            ExceptionModel oResult = new ExceptionModel();
            try
            {

                string xml = Helper.XmlSerializer<UserModel>(data);
                using (var context = new SQLContext())
                {
                    SqlParameter[] param = new SqlParameter[1];
                    param[0] = new SqlParameter("@data", SqlDbType.Xml);
                    param[0].Value = xml;

                    var reader = context.Database.SqlQuery<ExceptionModel>(
                        "[dbo].[s_post_user] @data",
                        param);

                    oResult = reader.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                oResult = oException.Set(ex);
            }
            return oResult;
        }
    }
}
