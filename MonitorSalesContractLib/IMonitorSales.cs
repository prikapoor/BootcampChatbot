using ChatbotDataModelLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorSalesContractLib
{
    public interface IMonitorSales
    {
        List<PatientSale> GetExecutiveName(string name);
        
    }
}
