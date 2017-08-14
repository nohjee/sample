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
        public String TestParam(String[] idArr, String[] nameArr, String[] emailArr)
        {
            List<ValueReturn> list_vr = new List<ValueReturn>();
            for (int i = 0; i < idArr.Length; i++)
            {
                int id = Int32.Parse(idArr[i]);
                ValueReturn vr = new ValueReturn(id,nameArr[i],emailArr[i]);
                list_vr.Add(vr);
            }
            
             JavaScriptSerializer json_par = new JavaScriptSerializer();
              string obj = json_par.Serialize(list_vr);


            return obj;
        }

    }

    public class ValueReturn
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }

        public ValueReturn(int Id, String Name, String Email)
        {
            this.Id = Id;
            this.Name = Name;
            this.Email = Email;
        }

    }
}
