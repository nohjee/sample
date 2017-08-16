using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.WebPages;
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
        public String TestParam(int[] idArr, String[] nameArr, String[] emailArr)
        {
            GetListClass listClass = new GetListClass();
            listClass.ListInfoValue = new List<GetValueReturn>(); 

            for (int i = 0; i < idArr.Length; i++)
            {
                GetValueReturn vr = new GetValueReturn(idArr[i],nameArr[i],emailArr[i]);  
                listClass.ListInfoValue.Add(vr);
            } 
             JavaScriptSerializer json_par = new JavaScriptSerializer();
              string obj = json_par.Serialize(listClass.ListInfoValue);


            return obj;
        }

    }

    public class GetValueReturn
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }

        public GetValueReturn(int Id, String Name, String Email)
        {
            this.Id = Id;
            this.Name = Name;
            this.Email = Email;
        }

    }

    public class GetListClass
    {
        public List<GetValueReturn> ListInfoValue { get; set; }
    }
}
