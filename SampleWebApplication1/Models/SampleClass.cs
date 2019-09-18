using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleWebApplication1.Models
{
    
    public class Monitors
    {
        public string _name { get; set; }
        public string _model { get; set; }
        public double _screenSize { get; set; }
        public string _portability { get; set; }
        public string _touchScreen { get; set; }
        public Nullable<int> _nowf { get; set; }
        public Nullable<double> _weight { get; set; }
        public string _careStage { get; set; }

    }

    public class QuestionsPart
    {
        public int ID { get; set; }
        public string qone { get; set; }
        public string qtwo { get; set; }

    }
        

 }

   

        
