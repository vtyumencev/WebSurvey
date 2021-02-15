using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSurvey.Data.Interfaces;
using WebSurvey.ViewModels;

namespace WebSurvey.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly IQuestions allQuestions;

        public StatisticsController(IQuestions iQuestionList)
        {
            this.allQuestions = iQuestionList;
        }

        public IActionResult Index()
        {
            var obj = new StatisticsViewModel
            {
                Questions = allQuestions.StatisticsQuestions,
                AnswersCount = allQuestions.StatisticsCountAnswers
            };

            ViewBag.Title = "Статистика";

            return View(obj);
        }
    }
}
