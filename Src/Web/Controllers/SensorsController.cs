using System;
using System.Collections.Generic;
using System.Configuration;
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
        public IHttpActionResult GetValues()
        {
            if (IsEmulation())
            {
                Random r=new Random();
                List<SensorLine> lines=new List<SensorLine>();
                for (int i = 0; i < 10; i++)
                {
                    lines.Add(new SensorLine()
                    {
                        Id=i,
                        Timestamp = DateTime.Now.AddSeconds(i*-1),
                        Value1 = (decimal)r.Next(50)+(decimal)r.NextDouble(),
                        Value2 = (decimal)r.Next(10) + (decimal)r.NextDouble(),
                    });
                }
                return Ok(new List<SensorLine>(lines));
                
            }
            using (EFContext ctx = new EFContext())
            {
                List<SensorLine> search = ctx.Sensors.ToList();
                
                return Ok(new List<SensorLine>(search));
            }
            
        }

        [Route("")]
        public IHttpActionResult PostValue(SensorLine sensors)
        {
            using (EFContext ctx = new EFContext())
            {
                ctx.Sensors.Add(sensors);
                ctx.SaveChanges();

                return Ok();
            }
            
        }

        public bool IsEmulation()
        {
            return ConfigurationManager.AppSettings["simulation"] != null &&
                   ConfigurationManager.AppSettings["simulation"] == "1";
        }
    }
}
