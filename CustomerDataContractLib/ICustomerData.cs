using ChatbotDataModelLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerDataContractLib
{
    public interface ICustomerData
    {
        bool PostNewMonitor(CustomerData data);
        PatientSale CreatePatientRecord(CustomerData data);
        string CheckSales(CustomerData data);
    }
}
