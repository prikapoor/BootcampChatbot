using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatbotDataModelLib.Models
{
    public class Monitors
    {
        public string _name { get; set; }
        public string _model { get; set; }
        public string _screenSize { get; set; }
        public string _portability { get; set; }
        public string _touchScreen { get; set; }
        public string _use { get; set; }
        public string _location { get; set; }
        public string _weight { get; set; }
        public string _careStage { get; set; }

        public PatientMonitor Convert()
        {
            return new PatientMonitor
            {
                Name = _name,
                Model = _model,
                Screen_Size = this._screenSize,
                Portability = _portability,
                Touch_Screen = _touchScreen,
                Use = _use,
                Location = _location,
                Weight = _weight,
                Care_Stage = _careStage
            };
        }

        public void Convert(PatientMonitor record)
        {
            _name = record.Name;
            _model = record.Model;
            _screenSize = record.Screen_Size;
            _portability = record.Portability;
            _touchScreen = record.Touch_Screen;
            _use = record.Use;
            _location = record.Location;
            _weight = record.Weight;
            _careStage = record.Care_Stage;
        }
    }
}
