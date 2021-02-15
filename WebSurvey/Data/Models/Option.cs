using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WebSurvey.Data.Models
{
    public class Option
    {

        public int ID { get; set; }

        public string Title { get; set; }

        public int QuestionID { get; set; }

        public virtual Question Question { get; set; }

        public List<AnswerQuestion> Answers { get; set; }

        public int Order { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string StringRate
        {
            get
            {
                if (Answers != null)
                {
                    return ((Convert.ToDouble(Answers.Count) / Question.Answers.Count) * 100.0).ToString().Replace(",", ".");
                }
                else
                {
                    return "0";
                }
            }
        }
    }
}
