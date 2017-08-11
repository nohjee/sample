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
        public String TestParam(String id, String name, String email, String address, String phone)
        {
            PersonalInfo sC = new PersonalInfo();

            sC.Id = Int16.Parse(id);
            sC.Name = name;
            sC.Email = email;
            sC.Address = address;
            sC.Phone = phone;
            sC.Date = DateTime.Now.ToLongDateString();


            JavaScriptSerializer json_par = new JavaScriptSerializer();
            string obj = json_par.Serialize(sC);
            return obj;

        }

    }

        public class PersonalInfo
        {
            public int Id { get; set; }
            public String Name { get; set; }
            public String Email { get; set; }
            public String Address { get; set; }
            public String Phone { get; set; }
            public String Date { get; set; }

        }
}
