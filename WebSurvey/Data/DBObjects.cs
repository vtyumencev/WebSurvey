using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSurvey.Data.Models;

namespace WebSurvey.Data
{
    public class DBObjects
    {
        public static void Initial(AppDBContext content)
        {

            if (!content.Questions.Any())
                content.Questions.AddRange(Questions.Select(c => c.Value));

            if (!content.Options.Any())
            {
                content.AddRange(
                    new Option { Title = "Меньше 16", Question = Questions["Сколько вам лет?"], Order = 1 },
                    new Option { Title = "От 16 до 19", Question = Questions["Сколько вам лет?"], Order = 2 },
                    new Option { Title = "От 20 до 25", Question = Questions["Сколько вам лет?"], Order = 3 },
                    new Option { Title = "От 26 до 30", Question = Questions["Сколько вам лет?"], Order = 4 },
                    new Option { Title = "От 31 до 35", Question = Questions["Сколько вам лет?"], Order = 5 },
                    new Option { Title = "От 36 до 40", Question = Questions["Сколько вам лет?"], Order = 6 },
                    new Option { Title = "Более 40", Question = Questions["Сколько вам лет?"], Order = 7 },
                    new Option { Title = "Мужчина", Question = Questions["Ваш пол?"], Order = 1 },
                    new Option { Title = "Женщина", Question = Questions["Ваш пол?"], Order = 2 },
                    new Option { Title = "Среднее", Question = Questions["Какое у вас образование?"], Order = 1 },
                    new Option { Title = "Неоконченное высшее", Question = Questions["Какое у вас образование?"], Order = 2 },
                    new Option { Title = "Одно высшее", Question = Questions["Какое у вас образование?"], Order = 3 },
                    new Option { Title = "Несколько высших", Question = Questions["Какое у вас образование?"], Order = 4 },
                    new Option { Title = "iOS", Question = Questions["Операционная система смартфона?"], Order = 1 },
                    new Option { Title = "Android", Question = Questions["Операционная система смартфона?"], Order = 2 },
                    new Option { Title = "Собаки", Question = Questions["Собаки или кошки?"], Order = 1 },
                    new Option { Title = "Кошки", Question = Questions["Собаки или кошки?"], Order = 2 }
                );
            }

            content.SaveChanges();
        }

        private static Dictionary<string, Question> question;

        public static Dictionary<string, Question> Questions
        {
            get
            {
                if(question == null)
                {
                    var list = new Question[]
                    {
                        new Question { Title = "Сколько вам лет?", IsRequired = true },
                        new Question { Title = "Ваш пол?", IsRequired = true },
                        new Question { Title = "Какое у вас образование?", IsRequired = true },
                        new Question { Title = "Операционная система смартфона?", IsRequired = true },
                        new Question { Title = "Собаки или кошки?", IsRequired = false }
                    };

                    question = new Dictionary<string, Question>();

                    foreach (Question el in list)
                        question.Add(el.Title, el);
                }

                return question;
            }
        }
    }
}
