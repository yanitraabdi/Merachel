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
    public class BlogServices : GeneralServices
    {
        public ICollection<BlogModel> GetBlogs(string title, int? status, int? categoryId, DateTime? startDate, DateTime? endDate, int? blogid, int? limit)
        {
            using (var conn = db.Database.Connection)
            {
                using (var reader = conn.QueryMultiple("dbo.s_get_blogs", new
                {
                    status = status,
                    title = title,
                    categoryId = categoryId,
                    startDate = startDate,
                    endDate = endDate,
                    blogid = blogid,
                    limit = limit
                },
                    commandType: CommandType.StoredProcedure))
                {
                    var result = reader.Read<BlogModel>().ToList();
                    return result;
                }
            }
        }

        public BlogModel PostBlog(BlogModel data)
        {
            string xml = Helper.XmlSerializer<BlogModel>(data);
            using (var context = new SQLContext())
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@data", SqlDbType.Xml);
                param[0].Value = xml;
                param[1] = new SqlParameter("@userid", SqlDbType.Int);
                param[1].Value = SessionInfo.User.UserId;

                var insert = context.Database.SqlQuery<BlogModel>("s_post_blog @data, @userid", param);

                BlogModel result = insert.FirstOrDefault();

                if (result != null)
                    return result;

                return data;
            }
        }

        public bool PutBlog(int blogId, BlogModel data)
        {
            string xml = Helper.XmlSerializer<BlogModel>(data);
            using (var context = new SQLContext())
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@blogid", SqlDbType.Int);
                param[0].Value = blogId;
                param[1] = new SqlParameter("@data", SqlDbType.Xml);
                param[1].Value = xml;
                param[2] = new SqlParameter("@userid", SqlDbType.Int);
                param[2].Value = SessionInfo.User.UserId;

                context.Database.ExecuteSqlCommand(
                    "[dbo].[s_put_blog] @blogid, @data, @userid",
                    param);

                return true;
            }
        }

        public bool DeleteBlog(List<int?> id)
        {
            using (var conn = new SQLContext().Database.Connection)
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@blogid", SqlDbType.Int);
                param[0].Value = id;
                param[1] = new SqlParameter("@userId", SqlDbType.Int);
                param[1].Value = SessionInfo.User.UserId;
                var context = new SQLContext().Database.ExecuteSqlCommand("s_delete_blog @blogid, @userId", param);

                return true;

            }
        }
    }
}
