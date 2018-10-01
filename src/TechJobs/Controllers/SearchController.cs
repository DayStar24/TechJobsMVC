using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        private static List<Dictionary<string, string>> results = new List<Dictionary<string, string>>();

        public IActionResult Index()
        {
            if (results.Count != 0) ViewBag.search = results; 

            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results
        public IActionResult Results(string searchType, string searchTerm)
        {
            results = JobData.FindByColumnAndValue(searchType, searchTerm);

            return Redirect("/");
        }
    }
}
