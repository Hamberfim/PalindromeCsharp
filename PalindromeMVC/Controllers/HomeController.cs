using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PalindromeMVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PalindromeMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Reverse()
        {
            Palindrome model = new();

            return View(model);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]  // assure that the post is happening from within the application page
        // overloaded method
        public IActionResult Reverse(Palindrome palindrome)
        {
            // declare member variables for this method
            string inputWord = palindrome.InputWord;
            string revWord = "";

            // start at the end of the word loop through the inputWord decrementing the index
            for (int i = inputWord.Length - 1; i >= 0; i--)
            {
                revWord += inputWord[i];
            }

            palindrome.RevWord = revWord;
            revWord = Regex.Replace(revWord.ToLower(), "[^a-zA-Z0-9]+", "");
            inputWord = Regex.Replace(inputWord.ToLower(), "[^a-zA-Z0-9]+", "");

            // check if revWord & inputWord are the same (inputWord is a palindrome)
            if (revWord == inputWord)
            {
                palindrome.IsPalindrome = true;
                palindrome.Message = $"AWESOME, {palindrome.InputWord} is a palindrome!";

            }
            else 
            {
                palindrome.IsPalindrome = false;
                palindrome.Message = $"SORRY, {palindrome.InputWord} is not a palindrome.";
            }

            return View(palindrome);
        }

        public IActionResult Privacy()
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
