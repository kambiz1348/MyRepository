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
    public class unitsController : ApiController
    {
        [HttpPost]
        public IHttpActionResult unitsUpdate(List<common.DataModel.units> unitList)
        {
            if (unitList != null)
            {
                new DAL.units().update(common.publicClass.List2datatable.ToDataTable(unitList));
                return Ok("Success");
            }
            return Ok("Fail");
        }
        [HttpGet]
        public string unitsGet()
        {
            DataTable dt = new DataTable { TableName = "MyTableName" };
            dt = new DAL.units().fetchAll();
            string jsonData = JsonConvert.SerializeObject(dt);
            return jsonData; 
        }
    }
}
