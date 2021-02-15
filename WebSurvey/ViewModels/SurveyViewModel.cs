using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSurvey.Data.Models;

namespace WebSurvey.ViewModels
{
    public class SurveyViewModel
    {
        public IEnumerable<Question> Questions { get; set; }
    }
}
