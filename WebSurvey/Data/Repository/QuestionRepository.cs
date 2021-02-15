using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSurvey.Data.Interfaces;
using WebSurvey.Data.Models;

namespace WebSurvey.Data.Repository
{
    public class QuestionRepository : IQuestions
    {
        private readonly AppDBContext appDBContent;

        public QuestionRepository(AppDBContext appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Question> Questions => appDBContent.Questions
            .Include(q => q.Options.OrderBy(opt => opt.Order));

        public IEnumerable<Question> StatisticsQuestions => appDBContent.Questions
            .Include(q => q.Options.OrderBy(opt => opt.Order))
            .Include(q => q.Answers)
            .ThenInclude(a => a.Answer.AnswerQuestions);

        public int StatisticsCountAnswers => appDBContent.Answers.Count();
    }
}
