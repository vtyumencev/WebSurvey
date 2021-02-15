using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSurvey.Data.Interfaces;
using WebSurvey.Data.Models;

namespace WebSurvey.Controllers
{
    public class AnswersController : Controller
    {
        private readonly Answer answer;

        public AnswersController(Answer answer)
        {
            this.answer = answer;
        }

        [HttpPost]
        public JsonResult Post([FromBody] List<AnswerQuestion> answerItems)
        {
            answer.AnswerQuestions = answerItems;

            if (answer.IsRequiredQuestionsFilled())
            {
                answer.AddAnswer();
                return Json(new { status = "OK" });
            }
            else
                return Json(new 
                { 
                    status = "ERROR",
                    message = "Обязательные пункты опроса не заполнены." 
                });

        }
    }
}
