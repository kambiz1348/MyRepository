using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using Newtonsoft.Json;

namespace nikanApi.Controllers
{
    public class usersController : ApiController
    {
        [HttpPost]
        public IHttpActionResult usersUpdate(List<common.DataModel.tblUsers> userList)
        {
            if (userList != null)
            {
                new DAL.users().update(common.publicClass.List2datatable.ToDataTable(userList));
                return Ok("Success");
            }
            return Ok("Fail");
        }
        [HttpGet]
        public string usersGet()
        {
            DataTable dt = new DataTable { TableName = "MyTableName" };
            dt = new DAL.users().fetchAll();
            string jsonData = JsonConvert.SerializeObject(dt);
            return jsonData;
        }
    }
}
