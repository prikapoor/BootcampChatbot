using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using WebApiService1.Models;



namespace WebApiService1.Controllers
{
    public class PatientMonitorsController : ApiController
    {
        [HttpGet]
        public List<Monitors> AllMonitors()
        {
            var content = new PhilipsDBEntities2();
            var records = content.PatientMonitors.ToList();
             var models = new List<Monitors>();
            foreach(var mod in records)
            {
                var temp = new Monitors();
                temp.Convert(mod);
                models.Add(temp);

            }
            


                
        }
    }
}
