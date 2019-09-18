using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ChatbotDataModelLib.Models;
using ChatbotService1.Support_Classes;
using Unity;

namespace ChatbotService1.Controllers
{
    public class ChatbotController : ApiController
    {
        readonly UnityContainer _con = new UnityContainer();        

        public ChatbotController()
        {
            _con.RegisterType<ChatbotContractLib.IChatbot, ChatbotLib.Chatbot>();
        }        
        
        [Route("api/chatbot/Monitors")]
        public IEnumerable<PatientMonitor> GetMonitors()
        {
            ChatbotContractLib.IChatbot chatbot;
            chatbot = _con.Resolve<ChatbotContractLib.IChatbot>();
            return chatbot.GetAllMonitors();            
        }

        [Route("api/chatbot/Questions")]
        public IEnumerable<Question> GetQuestions()
        {
            ChatbotContractLib.IChatbot chatbot;
            chatbot = _con.Resolve<ChatbotContractLib.IChatbot>();
            return chatbot.GetAllQuestions();            
        }

        [Route("api/Chatbot/Monitors/Add")]
        public void PostMonitors([FromBody] PatientMonitor newmod)
        {
            ChatbotContractLib.IChatbot chatbot;
            chatbot = _con.Resolve<ChatbotContractLib.IChatbot>();
            chatbot.PostNewMonitors(newmod);            
        }        

        [Route("api/Chatbot/Monitors/Delete/{mod}")]
        public void Delete(string mod)
        {
            ChatbotContractLib.IChatbot chatbot;
            chatbot = _con.Resolve<ChatbotContractLib.IChatbot>();
            chatbot.DeleteMonitor(mod);
        }

        [Route("api/chatbot/Questions/Initial")]
        public Question GetFirstQuestion()
        {
            ChatbotContractLib.IChatbot chatbot;
            chatbot = _con.Resolve<ChatbotContractLib.IChatbot>();
            return chatbot.GetInitialQuestion();            
        }

        [Route("api/chatbot/Questions/Initial/{Q1}")]
        public Question GetQuestion2(string Q1)
        {
            ChatbotContractLib.IChatbot chatbot;
            chatbot = _con.Resolve<ChatbotContractLib.IChatbot>();
            return chatbot.GetQ2(Q1);
        }

        [Route("api/chatbot/Questions/Initial/{Q1}/{Q2}")]
        public Question GetQuestion3(string Q1, string Q2)
        {
            ChatbotContractLib.IChatbot chatbot;
            chatbot = _con.Resolve<ChatbotContractLib.IChatbot>();
            return chatbot.GetQ3(Q1,Q2);
        }

        [Route("api/chatbot/Questions/Initial/{Q1}/{Q2}/{Q3}")]
        public Question GetQuestion4(string Q1, string Q2, string Q3)
        {
            ChatbotContractLib.IChatbot chatbot;
            chatbot = _con.Resolve<ChatbotContractLib.IChatbot>();
            return chatbot.GetQ4(Q1,Q2,Q3);
        }


        [Route("api/chatbot/Questions/Initial/LabourCare/{Q2}/{Q3}")]
        public HttpResponseMessage GetSolutionAvalon(string Q2, string Q3)
        {
            ChatbotContractLib.IChatbot chatbot;
            chatbot = _con.Resolve<ChatbotContractLib.IChatbot>();                     
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, chatbot.GetAvalonSolution(Q2,Q3)); 
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            }
        }

        [Route("api/chatbot/Questions/Initial/ICU/{Q2}/{Q3}/{Q4}")]
        public HttpResponseMessage GetSolutionICU(string Q2, string Q3, string Q4)
        {
            ChatbotContractLib.IChatbot chatbot;
            chatbot = _con.Resolve<ChatbotContractLib.IChatbot>();
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, chatbot.GetICUSolution(Q2,Q3,Q4));
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            }
        }
    }
}
