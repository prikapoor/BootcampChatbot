using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatbotDataModelLib.Models
{
    public class QuestionClass
    {
        public string _id { get; set; }
        public string _Question { get; set; }
        public string _Option1 { get; set; }
        public string _Option2 { get; set; }
        public string _Option3 { get; set; }

        public Question Convert()
        {
            return new Question
            {

                Identifier = _id,
                Question1 = _Question,
                Option_1 = _Option1,
                Option_2 = _Option1,
                Option_3 = _Option3
                
            };
        }

        public void Convert(Question record)
        {
            _id = record.Identifier;
            _Question = record.Question1;
            _Option1 = record.Option_1;
            _Option2 = record.Option_2;
            _Option3 = record.Option_3;
        }
    }
}
