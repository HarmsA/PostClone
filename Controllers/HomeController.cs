using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PostClone.Models;

namespace PostClone.Controllers
{
    public class HomeController : Controller
    {
        private PostCloneContext dbContext;
        public HomeController(PostCloneContext context)
        {
            dbContext = context;
        }

        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [Route("login")]
        [HttpGet]
        public IActionResult login()
        {
            return View();
        }

    }
}
