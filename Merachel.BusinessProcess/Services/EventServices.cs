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
    public class EventServices : GeneralServices
    {
        public ICollection<EventModel> GetEvent(string title = "", int? status = null)
        {
            using (var conn = db.Database.Connection)
            {
                using (var reader = conn.QueryMultiple("dbo.s_get_event", new
                {
                    title = title,
                    status = status,
                },
                    commandType: CommandType.StoredProcedure))
                {

                    var result = reader.Read<EventModel>().ToList();
                    var resultDetail = reader.Read<EventPriceModel>().ToList();

                    foreach (EventModel item in result)
                    {
                        item.ListPrice = resultDetail.Where(i => i.EventID == item.EventID).ToList();
                    }

                    return result;
                }
            }
        }
        public EventModel PostEvent(EventModel data)
        {
            string xml = Helper.XmlSerializer<EventModel>(data);
            using (var context = new SQLContext())
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@data", SqlDbType.Xml);
                param[0].Value = xml;
                param[1] = new SqlParameter("@userid", SqlDbType.Int);
                param[1].Value = SessionInfo.User.UserId;

                var insert = context.Database.SqlQuery<EventModel>("s_post_event @data, @userid", param);

                EventModel result = insert.FirstOrDefault();

                if (result != null)
                    return result;

                return data;
            }
        }

        public bool PutEvent(int eventId, EventModel data)
        {
            try
            {
                string xml = Helper.XmlSerializer<EventModel>(data);
                using (var context = new SQLContext())
                {
                    SqlParameter[] param = new SqlParameter[3];

                    param[0] = new SqlParameter("@eventId", SqlDbType.Int);
                    param[0].Value = eventId;
                    param[1] = new SqlParameter("@data", SqlDbType.Xml);
                    param[1].Value = xml;
                    param[2] = new SqlParameter("@userId", SqlDbType.Int);
                    param[2].Value = SessionInfo.User.UserId;

                    context.Database.ExecuteSqlCommand(
                        "[dbo].[s_put_event] @eventId, @data, @userId",
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

        public bool DeleteEvent(List<int?> id)
        {
            using (var conn = new SQLContext().Database.Connection)
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@eventId", SqlDbType.Int);
                param[0].Value = id;
                param[1] = new SqlParameter("@userId", SqlDbType.Int);
                param[1].Value = SessionInfo.User.UserId;
                var context = new SQLContext().Database.ExecuteSqlCommand("s_delete_event @eventId, @userId", param);

                return true;

            }
        }
    }
}
