using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
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

        [HttpPost]
        public String TestParam(String inval1, String inval2, String inval3, String inval4, String inval5)
        {
            
            sampleClass sC = new sampleClass();

            sC.Input1 = inval1;
            sC.Input2 = inval2;
            sC.Input3 = inval3;
            sC.Input4 = inval4;
            sC.Input5 = inval5;

            JavaScriptSerializer json_par = new JavaScriptSerializer();
            string obj = json_par.Serialize(sC);
            return obj;
        }

    }

    public class sampleClass
    {
        public String Input1 { get; set; }
        public String Input2 { get; set; }
        public String Input3 { get; set; }
        public String Input4 { get; set; }
        public String Input5 { get; set; }

    }
}
