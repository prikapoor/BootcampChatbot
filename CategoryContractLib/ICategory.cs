using ChatbotDataModelLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategoryContractLib
{
    public interface ICategory
    {
        Question GetCategories();
        Question GetQuestion1(string Q1);
        List<PatientMonitor> GetSolution(string Q1, string Q2);        
    }
}
