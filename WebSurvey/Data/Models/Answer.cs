using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSurvey.Data.Models
{
    public class Answer
    {
        public readonly AppDBContext appDBContent;

        public int ID { get; set; }

        public List<AnswerQuestion> AnswerQuestions { get; set; }

        public DateTime Datetime { get; set; }

        public Answer(AppDBContext appDBContent)
        {
            this.appDBContent = appDBContent;
            Datetime = DateTime.Now;
        }

        public bool IsRequiredQuestionsFilled()
        {
            var questions =
                appDBContent.Questions
                .Where(q => q.IsRequired);
            var jQuestions =
                questions
                .AsEnumerable()
                .Join(AnswerQuestions,
                    question => question.ID,
                    answer => answer.QuestionID,
                    (question, answer) => new { Id = question.ID, Answer = answer.OptionID });

            if (jQuestions.Count() == questions.Count()) return true;
            else return false;
        }


        public void AddAnswer()
        {
            appDBContent.Answers.Add(this);
            appDBContent.SaveChanges();
        }
    }
}
