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
    public class CourseCategoryServices : GeneralServices
    {
        public ICollection<CourseCategoryModel> GetCourseCategories(int? status, string categoryName)
        {
            using (var conn = db.Database.Connection)
            {
                using (var reader = conn.QueryMultiple("dbo.s_get_course_category", new
                {
                    categoryName = categoryName,
                    status = status,
                },
                    commandType: CommandType.StoredProcedure))
                {
                    var result = reader.Read<CourseCategoryModel>().ToList();
                    return result;
                }
            }
        }

        public CourseCategoryModel PostCourseCategory(CourseCategoryModel data)
        {
            string xml = Helper.XmlSerializer<CourseCategoryModel>(data);
            using (var context = new SQLContext())
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@data", SqlDbType.Xml);
                param[0].Value = xml;
                param[1] = new SqlParameter("@userid", SqlDbType.Int);
                param[1].Value = 0;

                var insert = context.Database.SqlQuery<CourseCategoryModel>("s_post_course_category @data, @userid", param);

                CourseCategoryModel result = insert.FirstOrDefault();

                if (result != null)
                    return result;

                return data;
            }
        }

        public bool PutCourseCategory(int blogCategoryId, CourseCategoryModel data)
        {
            string xml = Helper.XmlSerializer<CourseCategoryModel>(data);
            using (var context = new SQLContext())
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@blogcategoryid", SqlDbType.Int);
                param[0].Value = blogCategoryId;
                param[1] = new SqlParameter("@data", SqlDbType.Xml);
                param[1].Value = xml;
                param[2] = new SqlParameter("@userid", SqlDbType.Int);
                param[2].Value = 0;

                context.Database.ExecuteSqlCommand(
                    "[dbo].[s_put_course_category] @blogcategoryid, @data, @userid",
                    param);

                return true;
            }
        }

        public bool DeleteCourseCategory(List<int?> ids)
        {
            using (var conn = new SQLContext().Database.Connection)
            {
                foreach (var id in ids)
                {
                    SqlParameter[] param = new SqlParameter[2];
                    param[0] = new SqlParameter("@blogcategoryid", SqlDbType.Int);
                    param[0].Value = id.Value;
                    param[1] = new SqlParameter("@userId", SqlDbType.Int);
                    param[1].Value = 0;
                    var context = new SQLContext().Database.ExecuteSqlCommand("s_delete_course_category @blogcategoryid, @userId", param);
                }

                return true;

            }
        }
    }
}
