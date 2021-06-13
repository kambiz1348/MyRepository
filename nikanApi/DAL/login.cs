using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using NLog;

namespace nikanApi.DAL
{
    public class login
    {
        SqlConnection con;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public DataTable fetchUser(string user,string password)
        {
            DataTable dt = new DataTable();
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
                SqlCommand com = new SqlCommand("loginGet", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlParameter _user = new SqlParameter("@user",SqlDbType.NVarChar,50);
                SqlParameter _pass = new SqlParameter("@password", SqlDbType.NVarChar, 50);
                _user.Value = user;
                _pass.Value = password;
                com.Parameters.Add(_user);
                com.Parameters.Add(_pass);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = com;
                adapter.Fill(dt);
            }
            catch (Exception ee)
            {
                logger.Info(ee.ToString());
            }
            return dt;
        }
    }
}