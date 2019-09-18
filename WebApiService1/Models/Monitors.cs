using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiService1.Models
{
    public class Monitors
    {
        public string _name { get; set; }
        public string _model { get; set; }
        public int _screenSize { get; set; }
        public string _portability { get; set; }
        public string _touchScreen { get; set; }
        public int _nowf { get; set; }
        public string _monitortype { get; set; }
        public string _careStage { get; set; }

        public PatientMonitors Convert()
        {
            return new PatientMonitors
            {
                Name = _name,
                Model = _model,
                Screen_Size = this._screenSize,
                Portability = _portability,
                Touch_Screen = _touchScreen,
                No_of_Waveforms = _nowf,
                Monitor_Type = _monitortype,
                Care_Stage = _careStage
            };
        }

        public void Convert(PatientMonitors record)
        {
            _name = record.Name;
            _model = record.Model;
            _screenSize = record.Screen_Size;
            _portability = record.Portability;
            _touchScreen = record.Touch_Screen;
            _nowf = record.No_of_Waveforms;
            _monitortype = record.Monitor_Type;
            _careStage = record.Care_Stage;
        }
    }

    
}