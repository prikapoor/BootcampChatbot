using ChatbotDataModelLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatbotService1.Support_Classes
{
    public class CreateEntity
    {
        public PhilipsDBEntities CreateEntities()
        {
            PhilipsDBEntities record = new PhilipsDBEntities();
            return record;
        }
    }
}