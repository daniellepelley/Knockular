using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Knockular.HtmlHelpers;

namespace Knockular.Mvc.Controllers
{
    public class AngularController : Controller
    {
        public AngularController()
        {
            Extensions.HtmlStringBuilderFactory = new AngularHtmlStringBuilderFactory();
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}