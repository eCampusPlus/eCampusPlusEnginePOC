using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fr.eCampusPlus.Engine.Runner;
using eCampusPlus.Engine.Configuration.Drivers;

namespace eCampusPlusPlateforme.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Browser.SetWebDriver("FIREFOX");
            return View();
        }

        public ActionResult ProofOfconcept()
        {
            return View();
        }

        public ActionResult Concept()
        {
            return View("Index");
        }

        public ActionResult CampusAccountCreation()
        {
            //Runner.RunTest(1);
            return View("Index");
        }

        public ActionResult CampusAccountValidation(string lienValidation)
        {
            //Runner.RunTest(2,lienValidation);
            return View("Index");
        }

        public ActionResult CampusAccountSetup()
        {
            Runner.RunTest(3);
            Browser.WebDriver.Quit();
            return View("Index");
        }
    }
}