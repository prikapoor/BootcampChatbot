using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SampleWebApplication1.Models;

namespace SampleWebApplication1.Controllers
{
    public class Employee1Controller : ApiController
    {
        //[HttpGet]
        [Route("api/Employee1/Samples")]
        public IEnumerable<PatientMonitor> GetSamples()
        {
            using (PhilipsDBEntities record = new PhilipsDBEntities())
            {
                return record.PatientMonitors.ToList();

            }
        }

        

            
        
    }
}



//[Route("api/Employee1/Samples1")]
//public IEnumerable<SportsTable> GetSamples1()
//{
//    using (PhilipsDBEntities records = new PhilipsDBEntities())
//    {
//        return records.SportsTables.ToList();

//    }
//[Route("api/Employee1/Samples")]
//public IEnumerable<EmpTable> GetSamples()
//{
//    using (PhilipsDBEntities records = new PhilipsDBEntities())
//    {
//        return records.EmpTables.ToList();

//    }


//}




//}