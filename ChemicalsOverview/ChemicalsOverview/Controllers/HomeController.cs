using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChemicalsOverview.Models;
using ChemicalsOverview.Controllers.ViewModel;
using System.Text.RegularExpressions;
using System.IO;
using ChemicalsOverview.Controllers.Data;

namespace ChemicalsOverview.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbRepository _context;

        public HomeController(DbRepository context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var viewModel = new HomeIndexViewModel();
            var list = _context.GetAllChemicals();
            viewModel.Chemicals = list.ToList();
            
            return View(viewModel);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

       
    }
}
