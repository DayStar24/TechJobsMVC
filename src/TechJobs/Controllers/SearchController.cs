using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results
        public IActionResult Results(string searchType, string searchTerm)
        {
            ViewBag.columns = ListController.columnChoices;

            if (String.IsNullOrEmpty(searchTerm) == false)
            {
                if (searchType.Equals("all"))
                
                    ViewBag.jobs = JobData.FindByValue(searchTerm);
                else
                    ViewBag.jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
            }
            else
                ViewBag.jobs = JobData.FindAll();

            return View("Index");
        }
    }
}
