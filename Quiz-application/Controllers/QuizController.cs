using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Quiz_application.Data;
using Quiz_application.Models.Entities;
using Quiz_application.Models.viewmodels;

namespace Quiz_application.Controllers
{
    public class QuizController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public QuizController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var questions = dbContext.Questions
                .Include(x => x.Options)
                .Select(x => new QuestionItem()
                {
                    QuestionId = x.Id,
                    Text = x.Text,
                    Options = x.Options
                        .Select(y => new SelectListItem
                        {
                            Text = y.Text,
                            Value = y.Id.ToString()
                        }).ToList()
                })
                .ToList();

            var viewModel = new QuizViewModel
            {
                Questions = questions
            };

            return View(viewModel);
        }


        [HttpPost]
        public IActionResult Submit(List<Guid> useAnswers)
        {
            var questions = dbContext.Questions.ToList();
            var score = 0;
            var totalScore = questions.Count;
            for(var i=0; i < useAnswers.Count; i++)
            {
                if (questions[i].CorrectOption == useAnswers[i])
                {
                    score++;
                }
                
            }


            ViewBag.Score = score;
            ViewBag.TotalScore = totalScore;

            return View("Results");
        }

    }
}
