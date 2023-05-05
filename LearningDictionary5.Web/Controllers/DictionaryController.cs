using LearningDictionary5.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LearningDictionary5.Web.Controllers
{
    public class DictionaryController : Controller
    {
        private readonly ILogger<DictionaryController> _logger;

        public DictionaryController(ILogger<DictionaryController> logger)
        {
            _logger = logger;
        }

        public IActionResult AddWord(Word word)
        {
            return View();
        }

        public IActionResult RemoveWord(Word word)
        {
            return View();
        }

        public IActionResult ViewWords()
        {
            return View();
        }
        public IActionResult ViewTestResults()
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