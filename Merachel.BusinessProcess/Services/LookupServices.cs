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
    public class LookupServices : GeneralServices
    {
        public ICollection<LookupModel> GetLookups(string type, string description, string category, int? status = null)
        {
            using (var conn = new SQLContext().Database.Connection)
            {
                using (var reader = conn.QueryMultiple("dbo.s_get_lookups", new { type = type, description = description, category = category, status = status }, commandType: System.Data.CommandType.StoredProcedure))
                {
                    var result = reader.Read<LookupModel>().ToList();
                    return result;
                }
            }
        }

        public ICollection<LookupModel> GetLookupsData(string category)
        {
            using (var conn = new SQLContext().Database.Connection)
            {
                using (var reader = conn.QueryMultiple("dbo.s_get_lookups_data", new { category = category }, commandType: System.Data.CommandType.StoredProcedure))
                {
                    var result = reader.Read<LookupModel>().ToList();
                    return result;
                }
            }
        }

        public ICollection<LookupModel> GetLookupsSetting(string category)
        {
            using (var conn = new SQLContext().Database.Connection)
            {
                using (var reader = conn.QueryMultiple("dbo.s_get_lookups_setting", new { category = category }, commandType: System.Data.CommandType.StoredProcedure))
                {
                    var result = reader.Read<LookupModel>().ToList();
                    return result;
                }
            }
        }

        public ICollection<Select2Model> GetLookupsCategory(int? status)
        {
            using (var conn = new SQLContext().Database.Connection)
            {
                using (var reader = conn.QueryMultiple("dbo.s_get_lookup_category", new { status = status },
                    commandType: CommandType.StoredProcedure))
                {
                    var result = reader.Read<Select2Model>().ToList();
                    return result;
                }
            }
        }

        public bool DeleteLookup(List<int?> id, int? userId)
        {
            using (var conn = new SQLContext().Database.Connection)
            {
                string ids = string.Join(",", id);
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@lookupid", SqlDbType.Int);
                param[0].Value = ids;
                param[1] = new SqlParameter("@userId", SqlDbType.Int);
                param[1].Value = 0;


                var context = new SQLContext().Database.ExecuteSqlCommand("s_delete_lookups @lookupId, @userId", param);

                return true;

            }

        }
        public LookupModel PostLookup(LookupModel data)
        {
            string xml = Helper.XmlSerializer<LookupModel>(data);
            using (var context = new SQLContext())
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@data", SqlDbType.Xml);
                param[0].Value = xml;
                param[1] = new SqlParameter("@userid", SqlDbType.Int);
                param[1].Value = 0;

                var insert = context.Database.SqlQuery<LookupModel>("s_post_lookups @data, @userid", param);

                LookupModel result = insert.FirstOrDefault();

                if (result != null)
                    return result;

                return data;
            }
        }

        public bool PutLookup(int lookupId, LookupModel data)
        {
            string xml = Helper.XmlSerializer<LookupModel>(data);
            using (var context = new SQLContext())
            {
                SqlParameter[] param = new SqlParameter[9];
                param[0] = new SqlParameter("@data", SqlDbType.Xml);
                param[0].Value = xml;
                param[1] = new SqlParameter("@userid", SqlDbType.Int);
                param[1].Value = 0;

                context.Database.ExecuteSqlCommand(
                   "s_put_lookups @data, @userid",
                   param);

                return true;
            }
        }
    }
}
