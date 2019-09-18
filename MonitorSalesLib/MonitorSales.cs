using ChatbotDataModelLib.Models;
using MonitorSalesContractLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorSalesLib
{
    public sealed class MonitorSales:IMonitorSales
    {        
        List<PatientSale> IMonitorSales.GetExecutiveName(string name)
        {
            PhilipsDBEntities record = new PhilipsDBEntities();
            return record.PatientSales.Where((e) => e.ExecutiveName.Equals(name)).ToList();                        
        }
    }
}
