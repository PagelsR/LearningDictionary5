using LearningDictionary5.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LearningDictionary5.Web.Controllers
{
    public class TestResultController : Controller
    {
        private readonly ILogger<TestResultController> _logger;

        public TestResultController(ILogger<TestResultController> logger)
        {
            _logger = logger;
        }

        public IActionResult GetDateTime()
        {
            return View();
        }

        public IActionResult GetScore()
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