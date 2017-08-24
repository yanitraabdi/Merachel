using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Merachel.WebUI.Models
{
    public class DAL
    {
        static SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["EFDBContext"].ToString());

        public static bool UserIsValid(string username, string password)
        {
            bool authenticated = false;

            string query = string.Format("SELECT * FROM [dbo].[Users] WHERE UserEmail = '{0}' AND UserPassword = '{1}'", username, password);

            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            authenticated = sdr.HasRows;
            conn.Close();
            return (authenticated);
        }
    }
}