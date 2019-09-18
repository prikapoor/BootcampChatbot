using ChatbotDataModelLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ChatbotService1.Support_Classes;
using Unity;

namespace ChatbotService1.Controllers
{
    public class CustomerDataController : ApiController
    {
        readonly UnityContainer _con = new UnityContainer();        

        public CustomerDataController()
        {
            _con.RegisterType<CustomerDataContractLib.ICustomerData, CustomerDataLib.CustomerData>();
        }        

        [Route("api/CustomerData/Registration")]        
        public void Post([FromBody] CustomerData data)
        {
            CustomerDataContractLib.ICustomerData customerData;
            customerData = _con.Resolve<CustomerDataContractLib.ICustomerData>();
            customerData.PostNewMonitor(data);
        }        
    }
}
