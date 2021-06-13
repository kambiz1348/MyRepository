using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;



namespace nikanApi.Controllers
{
    public class productGroupsController : ApiController
    {
        [HttpPost]

        public IHttpActionResult productGroupsUpdate(common.DataModel.productGroup pg)
        {
            new DAL.productGroups().update(pg.id, pg.code, pg.name, pg.parentId, pg.levelNo, pg.active, pg.fullCode);
            return Ok("Success");
        }
        [HttpGet]
        public DataTable productGroupsGet()
        {
            DataTable dt = new DAL.productGroups().fetchAll();
            return dt;
        }
    }
}
