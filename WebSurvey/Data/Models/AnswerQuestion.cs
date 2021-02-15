using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebSurvey.Data.Models
{
    public class AnswerQuestion
    {
        public int ID { get; set; }

        public int AnswerID { get; set; }

        public virtual Answer Answer { get; set; }

        public int? QuestionID { get; set; }

        public virtual Question Question { get; set; }

        public int? OptionID { get; set; }

        public virtual Option Option { get; set; }
    }
}
