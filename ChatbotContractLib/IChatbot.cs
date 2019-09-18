using ChatbotDataModelLib.Models;
using System.Collections.Generic;

namespace ChatbotContractLib
{
    public interface IChatbot
    {
        List<PatientMonitor> GetAllMonitors();
        List<Question> GetAllQuestions();
        bool PostNewMonitors(PatientMonitor newmod);
        bool DeleteMonitor(string mod);        
        Question GetInitialQuestion();
        Question GetQ2(string Q1);
        Question GetQ3(string Q1, string Q2);
        Question GetQ4(string Q1, string Q2, string Q3);
        List<PatientMonitor> GetAvalonSolution(string Q2, string Q3);
        List<PatientMonitor> GetICUSolution(string Q2, string Q3, string Q4);

    }
}
