using ChatbotDataModelLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ChatbotService1.Support_Classes;

namespace ChatbotService1.Controllers
{
    public class CustomerDataController : ApiController
    {
        CreateEntity obj = new CreateEntity();
        
        [Route("api/CustomerData/Registration")]        
        public void Post([FromBody] CustomerData data)
        {
                var record = obj.CreateEntities();
                record.CustomerDatas.Add(data);
                record.SaveChanges();
        }
    }
}
