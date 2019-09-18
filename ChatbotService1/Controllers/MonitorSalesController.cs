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
    public class MonitorSalesController : ApiController
    {
        UnityContainer _con = new UnityContainer();
        public MonitorSalesContractLib.IMonitorSales monitorSales;

        public MonitorSalesController()
        {
            _con.RegisterType<MonitorSalesContractLib.IMonitorSales, MonitorSalesLib.MonitorSales>();
        }

        [Route("api/MonitorSales/Registration/{ExecutiveName}")]
        public HttpResponseMessage GetSalesExecutiveName(string name)
        {
            monitorSales = _con.Resolve<MonitorSalesContractLib.IMonitorSales>();                        
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, monitorSales.GetExecutiveName(name));
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            }

            //var record = obj.CreateEntities();
            //try
            //{
            //    return Request.CreateResponse(HttpStatusCode.OK, record.PatientSales.Where((e) => e.ExecutiveName.Equals(name)));
            //}
            //catch (Exception e)
            //{
            //    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            //}
        }
    }
}
