using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using sample.Models;

namespace sample.Class_process
{
    public class InfoProcess
    {
        public String SetNowDate(PersonalInfo info)
        {
            info.NowDate = DateTime.Now.ToShortDateString();

            JavaScriptSerializer json_par = new JavaScriptSerializer();
            String dataJson    = json_par.Serialize(info);
            return dataJson;
        }
    }
}