using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSurvey.Data.Models
{
    public class Question
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public List<Option> Options { get; set; }

        public List<AnswerQuestion> Answers { get; set; }

        public bool IsRequired { get; set; }
    }
}
