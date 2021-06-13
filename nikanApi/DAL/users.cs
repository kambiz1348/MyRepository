using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NLog;
using NLog.Config;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


namespace nikanApi.DAL
{
    public class users
    {
        SqlConnection con;

        private static Logger logger = LogManager.GetCurrentClassLogger();
        public void update(DataTable usersDT)
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
                SqlCommand com = new SqlCommand("userUpdate", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlParameter _tbl_users = new SqlParameter("@tbl_users", SqlDbType.Structured);

                _tbl_users.Value = usersDT;
                com.Parameters.Add(_tbl_users);

                con.Open();
                com.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ee)
            {
                logger.Info(ee.ToString());
            }
        }
        public DataTable fetchAll()
        {
            DataTable dt = new DataTable();
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
                SqlCommand com = new SqlCommand("userGet", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
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