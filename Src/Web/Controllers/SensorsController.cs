using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web.Models;
using Web.Models.Ef;

namespace Web.Controllers
{
    [RoutePrefix("api/sensors")]
    public class SensorsController : ApiController
    {
        [Route("")]
        public IHttpActionResult GetRegions()
        {
            using (EFContext ctx = new EFContext())
            {
                List<SensorLine> search = ctx.Sensors.ToList();
                
                return Ok(new List<SensorLine>(search));
            }
            return Ok();
        }

        [Route("")]
        public IHttpActionResult PostRegions(SensorLine sensors)
        {
            using (EFContext ctx = new EFContext())
            {
                ctx.Sensors.Add(sensors);
                ctx.SaveChanges();

                return Ok();
            }
            
        }
    }
}
