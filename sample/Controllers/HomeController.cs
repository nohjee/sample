using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sample.Common;

namespace sample.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}

		[HttpGet]
		public string GetBonusCheck(string bonusCode)
		{
			var data = "?BonusCode=" + bonusCode;
			return data;
		}

	    [HttpGet]
	    public String TestParam(String val1, String val2)
	    {
	        String data = val1 + "/" +val2;
	        return data;
	    }

	}
}