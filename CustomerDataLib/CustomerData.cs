using ChatbotDataModelLib.Models;
using CustomerDataContractLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerDataLib
{
    public class CustomerData : ICustomerData
    {
        string executiveName;

        public PatientSale CreatePatientRecord(ChatbotDataModelLib.Models.CustomerData data)
        {
            PatientSale patientSale = new PatientSale
            {
                CustomerId = data.CustomerId,
                CustomerName = data.CustomerName,
                ExecutiveName = executiveName,
                City = data.CustomerAddress,
                Model = data.Model
            };
            return patientSale;
        }

        public string CheckSales(ChatbotDataModelLib.Models.CustomerData data)
        {
            PhilipsDBEntities record = new PhilipsDBEntities();
            string name = "Main HQ";
            var item = record.SalesReps.ToList();
            for (int i = 0; i < record.SalesReps.Count(); i++)
            {
                if (item[i].City.Equals(data.CustomerAddress))
                {
                    name = item[i].ExecutiveName;
                }
            }
            return name;
        }

        public bool PostNewMonitor(ChatbotDataModelLib.Models.CustomerData data)
        {
            PhilipsDBEntities record = new PhilipsDBEntities();
            record.CustomerDatas.Add(data);
            record.SaveChanges();

            executiveName = CheckSales(data);
            PatientSale patientSale = CreatePatientRecord(data);
            record.PatientSales.Add(patientSale);
            record.SaveChanges();
            return true;
        }
    }
}
