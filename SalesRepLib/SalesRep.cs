using ChatbotDataModelLib.Models;
using SalesRepContractLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesRepLib
{
    public class SalesRep : ISalesRep
    {
        public bool PostNewSalesRep(ChatbotDataModelLib.Models.SalesRep data)
        {
            PhilipsDBEntities record = new PhilipsDBEntities();
            var selected = record.SalesReps.FirstOrDefault((e) => e.City.Equals(data.City));
            if (selected == null)
            {
                record.SalesReps.Add(data);
                record.SaveChanges();
                return true;
            }
            return false;            
        }
    }
}
