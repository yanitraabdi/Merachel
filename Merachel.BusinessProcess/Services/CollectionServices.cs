﻿using System;
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
    public class CollectionServices : GeneralServices
    {
        public ICollection<CollectionModel> GetCollection(string title = "", int? status = null)
        {
            using (var conn = db.Database.Connection)
            {
                using (var reader = conn.QueryMultiple("dbo.s_get_collection", new
                {
                    title = title,
                    status = status,
                },
                    commandType: CommandType.StoredProcedure))
                {

                    var result = reader.Read<CollectionModel>().ToList();
                    var resultDetail = reader.Read<CollectionPictureModel>().ToList();

                    foreach (CollectionModel item in result)
                    {
                        item.ListPicture = resultDetail.Where(i => i.CollectionID == item.CollectionID).ToList();
                    }

                    return result;
                }
            }
        }
        public CollectionModel PostCollection(CollectionModel data)
        {
            string xml = Helper.XmlSerializer<CollectionModel>(data);
            using (var context = new SQLContext())
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@data", SqlDbType.Xml);
                param[0].Value = xml;
                param[1] = new SqlParameter("@userid", SqlDbType.Int);
                param[1].Value = SessionInfo.User.UserId;

                var insert = context.Database.SqlQuery<CollectionModel>("s_post_collection @data, @userid", param);

                CollectionModel result = insert.FirstOrDefault();

                if (result != null)
                    return result;

                return data;
            }
        }

        public bool PutCollection(int collectionId, CollectionModel data)
        {
            try
            {
                string xml = Helper.XmlSerializer<CollectionModel>(data);
                using (var context = new SQLContext())
                {
                    SqlParameter[] param = new SqlParameter[3];

                    param[0] = new SqlParameter("@collectionId", SqlDbType.Int);
                    param[0].Value = collectionId;
                    param[1] = new SqlParameter("@data", SqlDbType.Xml);
                    param[1].Value = xml;
                    param[2] = new SqlParameter("@userId", SqlDbType.Int);
                    param[2].Value = SessionInfo.User.UserId;

                    context.Database.ExecuteSqlCommand(
                        "[dbo].[s_put_collection] @collectionId, @data, @userId",
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

        public bool DeleteCollection(List<int?> id)
        {
            using (var conn = new SQLContext().Database.Connection)
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@collectionId", SqlDbType.Int);
                param[0].Value = id;
                param[1] = new SqlParameter("@userId", SqlDbType.Int);
                param[1].Value = SessionInfo.User.UserId;
                var context = new SQLContext().Database.ExecuteSqlCommand("s_delete_collection @collectionId, @userId", param);

                return true;

            }
        }
    }
}
