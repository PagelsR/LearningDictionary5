using LearningDictionary5.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LearningDictionary5.Web.Controllers
{
    public class PracticeTestController : Controller
    {
        private readonly ILogger<PracticeTestController> _logger;

        public PracticeTestController(ILogger<PracticeTestController> logger)
        {
            _logger = logger;
        }

        public IActionResult StartTest()
        {
            return View();
        }

        public IActionResult AnswerQuestion(Question question)
        {
            return View();
        }

        public IActionResult ViewResults()
        {
            return View();

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}