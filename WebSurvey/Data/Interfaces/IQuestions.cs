using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSurvey.Data.Models;

namespace WebSurvey.Data.Interfaces
{
    public interface IQuestions
    {
        IEnumerable<Question> Questions { get; }

        IEnumerable<Question> StatisticsQuestions { get; }

        int StatisticsCountAnswers { get; }
    }
}
