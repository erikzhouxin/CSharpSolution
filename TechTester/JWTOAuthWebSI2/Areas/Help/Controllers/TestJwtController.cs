using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EZOper.TechTester.JWTOAuthWebSI.Areas.Help.Controllers
{
    public class TestJwtController : AreaBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}