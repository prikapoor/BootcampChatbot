using ChatbotDataModelLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesRepContractLib
{
    public interface ISalesRep
    {
        bool PostNewSalesRep(SalesRep data);        
    }
}
