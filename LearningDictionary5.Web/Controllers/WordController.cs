using LearningDictionary5.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LearningDictionary5.Web.Controllers
{
    public class WordController : Controller
    {
        private readonly ILogger<WordController> _logger;

        public WordController(ILogger<WordController> logger)
        {
            _logger = logger;
        }

        public IActionResult GetPrimaryWord()
        {
            return View();
        }

        public IActionResult GetSecondaryWord()
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