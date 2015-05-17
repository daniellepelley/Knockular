using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Knockular.HtmlHelpers;

namespace Knockular.Mvc.Controllers
{
    public class KnockoutController : Controller
    {
        public KnockoutController()
        {
            Extensions.HtmlStringBuilderFactory = new KnockoutHtmlStringBuilderFactory();
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}