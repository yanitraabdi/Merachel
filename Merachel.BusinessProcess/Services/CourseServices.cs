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
    public class CourseServices : GeneralServices
    {
        public ICollection<CourseModel> GetCourse(int? courseid = null, int? status = null, int? coursecategoryid = null, string coursedescription = "")
        {
            using (var conn = db.Database.Connection)
            {
                using (var reader = conn.QueryMultiple("dbo.s_get_course", new
                {
                    courseid = courseid,
                    coursecategoryid = coursecategoryid,
                    coursedescription = coursedescription,
                    status = status,
                },
                    commandType: CommandType.StoredProcedure))
                {

                    var result = reader.Read<CourseModel>().ToList();
                    var resultDetail = reader.Read<CoursePriceModel>().ToList();

                    foreach (CourseModel item in result)
                    {
                        item.ListPrice = resultDetail.Where(i => i.CourseID == item.CourseID).ToList();
                    }

                    return result;
                }
            }
        }
        public CourseModel PostCourse(CourseModel data)
        {
            string xml = Helper.XmlSerializer<CourseModel>(data);
            using (var context = new SQLContext())
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@data", SqlDbType.Xml);
                param[0].Value = xml;
                param[1] = new SqlParameter("@userid", SqlDbType.Int);
                param[1].Value = 0;

                var insert = context.Database.SqlQuery<CourseModel>("s_post_course @data, @userid", param);

                CourseModel result = insert.FirstOrDefault();

                if (result != null)
                    return result;

                return data;
            }
        }

        public bool PutCourse(int courseId, CourseModel data)
        {
            try
            {
                string xml = Helper.XmlSerializer<CourseModel>(data);
                using (var context = new SQLContext())
                {
                    SqlParameter[] param = new SqlParameter[3];

                    param[0] = new SqlParameter("@courseId", SqlDbType.Int);
                    param[0].Value = courseId;
                    param[1] = new SqlParameter("@data", SqlDbType.Xml);
                    param[1].Value = xml;
                    param[2] = new SqlParameter("@userId", SqlDbType.Int);
                    param[2].Value = 0;

                    context.Database.ExecuteSqlCommand(
                        "[dbo].[s_put_course] @courseId, @data, @userId",
                        param);

                    return true;
                }
            }
            catch (Exception ex)
            {
                //_exception.Set(ExceptionType.CATCH, ex);
                return false;
            }
        }

        public bool DeleteCourse(List<int?> ids)
        {
            using (var conn = new SQLContext().Database.Connection)
            {
                foreach (var id in ids)
                {
                    SqlParameter[] param = new SqlParameter[2];
                    param[0] = new SqlParameter("@courseId", SqlDbType.Int);
                    param[0].Value = id.Value;
                    param[1] = new SqlParameter("@userId", SqlDbType.Int);
                    param[1].Value = 0;
                    var context = new SQLContext().Database.ExecuteSqlCommand("s_delete_course @courseId, @userId", param);
                }

                return true;

            }
        }
    }
}
