using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSurvey.Data.Interfaces;
using WebSurvey.ViewModels;

namespace WebSurvey.Controllers
{
    public class SurveyController : Controller
    {
        private readonly IQuestions allQuestions;

        public SurveyController(IQuestions iQuestionList)
        {
            this.allQuestions = iQuestionList;
        }

        public IActionResult Index()
        {
            var obj = new SurveyViewModel();
            obj.Questions = allQuestions.Questions;

            ViewBag.Title = "Опрос";

            return View(obj);
        }
    }
}
