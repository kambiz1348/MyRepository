using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace nikanApi.Controllers
{
    public class loginController : ApiController
    {
        [HttpPost]
        public string loginGet(common.DataModel.loginPassword login)
        {
            DataTable dt = new DataTable { TableName = "MyTableName" };
            dt = new DAL.login().fetchUser(login.loginName, login.Password);
            string jsonData = JsonConvert.SerializeObject(dt);
            return jsonData;
        }
    }
}
