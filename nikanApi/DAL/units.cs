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
    public class units
    {
        SqlConnection con;

        private static Logger logger = LogManager.GetCurrentClassLogger();
        public void update(DataTable unitsDT)
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
                SqlCommand com = new SqlCommand("unitUpdate", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlParameter _Tbl_units = new SqlParameter("@tbl_units", SqlDbType.Structured);
                _Tbl_units.Value = unitsDT;
                com.Parameters.Add(_Tbl_units);
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
            DataTable dt=new DataTable();
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
                SqlCommand com = new SqlCommand("unitGet", con)
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