using ChatbotDataModelLib.Models;
using ChatbotService1.Support_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Unity;

namespace ChatbotService1.Controllers
{
    public class SalesRepController : ApiController
    {
        readonly UnityContainer _con = new UnityContainer();        

        public SalesRepController()
        {
            _con.RegisterType<SalesRepContractLib.ISalesRep, SalesRepLib.SalesRep>();
        }

        [Route("api/SalesRep/Registration")]
        public void Post([FromBody] SalesRep data)
        {
            SalesRepContractLib.ISalesRep salesRep;
            salesRep = _con.Resolve<SalesRepContractLib.ISalesRep>();
            salesRep.PostNewSalesRep(data);
        }
    }
}

