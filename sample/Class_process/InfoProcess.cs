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
        public String SetInfoData(int createId)
        {
            InData indata = new InData();
            ListInfo listinfo = new ListInfo();
            listinfo.Personalinfo = new List<PersonalInfoModels>();

            Random random = new Random();

            
            for (int i = 0; i < createId; i++)
            {
               PersonalInfoModels info = new PersonalInfoModels();
                info.Id = random.Next(001,100);
                info.Phone = "010"+random.Next(00000000, 99999999).ToString();
                info.Name = indata.NameArr[random.Next(0, indata.NameArr.Length-1)];
                info.Email = info.Name + indata.EmailArr[random.Next(0, indata.EmailArr.Length - 1)];
                info.Address = indata.AddrArr[random.Next(0, indata.AddrArr.Length - 1)];
                info.NowDate = DateTime.Now.ToLongDateString();
                listinfo.Personalinfo.Add(info);
            }

            JavaScriptSerializer json_par = new JavaScriptSerializer();
            String dataJson = json_par.Serialize(listinfo.Personalinfo);
            return dataJson;
        }
    }

   
}