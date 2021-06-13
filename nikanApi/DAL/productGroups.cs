using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using NLog;
using NLog.Config;
using System.Configuration;
using System.Data;

namespace nikanApi.DAL
{

    public class productGroups
    {
        SqlConnection con;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public DataTable fetchAll()
        {
            DataTable dt = new DataTable();
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
                SqlCommand com = new SqlCommand("productGroupsGet", con)
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
        public void update(int id,string code,string name,int parentId,int levelNo,int active,string fullCode)
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
                SqlCommand com = new SqlCommand("productGroupsUpdate", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlParameter _id = new SqlParameter("@id", SqlDbType.Int);
                SqlParameter _code = new SqlParameter("@code", SqlDbType.Char,3);
                SqlParameter _name = new SqlParameter("@name", SqlDbType.NVarChar, 50);
                SqlParameter _parentId = new SqlParameter("@parentId", SqlDbType.Int);
                SqlParameter _levelNo = new SqlParameter("@levelNo", SqlDbType.Int);
                SqlParameter _active = new SqlParameter("@active", SqlDbType.Int);
                SqlParameter _fullCode = new SqlParameter("@fullCode", SqlDbType.NVarChar, 50);
                _id.Value = id;
                _code.Value = code;
                _name.Value = name;
                _parentId.Value = parentId;
                _levelNo.Value = levelNo;
                _active.Value = active;
                _fullCode.Value = fullCode;
                com.Parameters.Add(_id);
                com.Parameters.Add(_code);
                com.Parameters.Add(_name);
                com.Parameters.Add(_parentId);
                com.Parameters.Add(_levelNo);
                com.Parameters.Add(_active);
                com.Parameters.Add(_fullCode);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ee)
            {
                logger.Info(ee.ToString());
            }

        }
    }
}