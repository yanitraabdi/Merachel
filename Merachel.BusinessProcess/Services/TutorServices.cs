using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

using EnumStringValues;
using Dapper;

using Merachel.Models;
using Merachel.Libraries;

namespace Merachel.BusinessProcess
{
    public class TutorServices : GeneralServices
    {
        public ICollection<TutorModel> GetTutors(string employeename, int? status, string employeedescription, string employeespecial)
        {
            using (var conn = db.Database.Connection)
            {
                using (var reader = conn.QueryMultiple("dbo.s_get_tutor", new
                {
                    status = status,
                    employeename = employeename,
                    employeedescription = employeedescription,
                    employeespecial = employeespecial
                },
                    commandType: CommandType.StoredProcedure))
                {
                    var result = reader.Read<TutorModel>().ToList();
                    return result;
                }
            }
        }

        public TutorModel PostTutor(TutorModel data)
        {
            string xml = Helper.XmlSerializer<TutorModel>(data);
            using (var context = new SQLContext())
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@data", SqlDbType.Xml);
                param[0].Value = xml;
                param[1] = new SqlParameter("@userid", SqlDbType.Int);
                param[1].Value = SessionInfo.User.UserId;

                var insert = context.Database.SqlQuery<TutorModel>("s_post_tutor @data, @userid", param);

                TutorModel result = insert.FirstOrDefault();

                if (result != null)
                    return result;

                return data;
            }
        }

        public bool PutTutor(int tutorId, TutorModel data)
        {
            string xml = Helper.XmlSerializer<TutorModel>(data);
            using (var context = new SQLContext())
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@tutorid", SqlDbType.Int);
                param[0].Value = tutorId;
                param[1] = new SqlParameter("@data", SqlDbType.Xml);
                param[1].Value = xml;
                param[2] = new SqlParameter("@userid", SqlDbType.Int);
                param[2].Value = SessionInfo.User.UserId;

                context.Database.ExecuteSqlCommand(
                    "[dbo].[s_put_tutor] @tutorid, @data, @userid",
                    param);

                return true;
            }
        }

        public bool DeleteTutor(List<int?> id)
        {
            using (var conn = new SQLContext().Database.Connection)
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@tutorid", SqlDbType.Int);
                param[0].Value = id;
                param[1] = new SqlParameter("@userId", SqlDbType.Int);
                param[1].Value = SessionInfo.User.UserId;
                var context = new SQLContext().Database.ExecuteSqlCommand("s_delete_tutor @tutorid, @userId", param);

                return true;

            }
        }
    }
}
