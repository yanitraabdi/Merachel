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
    public class TestimonialServices : GeneralServices
    {
        public ICollection<TestimonialModel> GetTestimonials(string testimonialuser, int? status, string testimonialcontent)
        {
            using (var conn = db.Database.Connection)
            {
                using (var reader = conn.QueryMultiple("dbo.s_get_testimonial", new
                {
                    status = status,
                    testimonialcontent = testimonialcontent,
                    testimonialuser = testimonialuser
                },
                    commandType: CommandType.StoredProcedure))
                {
                    var result = reader.Read<TestimonialModel>().ToList();
                    return result;
                }
            }
        }

        public TestimonialModel PostTestimonial(TestimonialModel data)
        {
            string xml = Helper.XmlSerializer<TestimonialModel>(data);
            using (var context = new SQLContext())
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@data", SqlDbType.Xml);
                param[0].Value = xml;
                param[1] = new SqlParameter("@userid", SqlDbType.Int);
                param[1].Value = SessionInfo.User.UserId;

                var insert = context.Database.SqlQuery<TestimonialModel>("s_post_testimonial @data, @userid", param);

                TestimonialModel result = insert.FirstOrDefault();

                if (result != null)
                    return result;

                return data;
            }
        }

        public bool PutTestimonial(int testimonialId, TestimonialModel data)
        {
            string xml = Helper.XmlSerializer<TestimonialModel>(data);
            using (var context = new SQLContext())
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@testimonialid", SqlDbType.Int);
                param[0].Value = testimonialId;
                param[1] = new SqlParameter("@data", SqlDbType.Xml);
                param[1].Value = xml;
                param[2] = new SqlParameter("@userid", SqlDbType.Int);
                param[2].Value = SessionInfo.User.UserId;

                context.Database.ExecuteSqlCommand(
                    "[dbo].[s_put_testimonial] @testimonialid, @data, @userid",
                    param);

                return true;
            }
        }

        public bool DeleteTestimonial(List<int?> id)
        {
            using (var conn = new SQLContext().Database.Connection)
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@testimonialid", SqlDbType.Int);
                param[0].Value = id;
                param[1] = new SqlParameter("@userId", SqlDbType.Int);
                param[1].Value = SessionInfo.User.UserId;
                var context = new SQLContext().Database.ExecuteSqlCommand("s_delete_testimonial @testimonialid, @userId", param);

                return true;

            }
        }
    }
}
