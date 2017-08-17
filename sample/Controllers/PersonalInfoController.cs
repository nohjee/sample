using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using sample.Models;
using sample.Class_process;

namespace sample.Controllers
{
    public class PersonalInfoController : Controller
    {
        // GET: PersonalInfo
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
        public String TestDTO(PersonalInfo info)
        {
            InfoProcess info_process = new InfoProcess();
            string obj  = info_process.SetNowDate(info);

            return obj;
            
        }
    }

}