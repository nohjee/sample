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
            ListInfo listinfo = new ListInfo();
            listinfo.Personalinfo = new List<PersonalInfo>();

            Random random = new Random();

            String[] nameArr = {"Kim","Lee","Park","Nam","Gang","Woo","Choe"};
            String[] emailArr = {"@naver.com", "@gmail.com", "@nate.com", "daum.net", "nsuslab.com"};
            String[] addrArr = {"서울", "수원", "인천", "대구", "광주", "대전", "부산", "울산"};

            for (int i = 0; i < createId; i++)
            {
               PersonalInfo info = new PersonalInfo();
                info.Id = random.Next(001,100);
                info.Phone = "010"+random.Next(00000000, 99999999).ToString();
                info.Name = nameArr[random.Next(0, nameArr.Length-1)];
                info.Email = info.Name + emailArr[random.Next(0, emailArr.Length - 1)];
                info.Address = addrArr[random.Next(0, addrArr.Length - 1)];
                info.NowDate = DateTime.Now.ToLongDateString();
                listinfo.Personalinfo.Add(info);
            }

            JavaScriptSerializer json_par = new JavaScriptSerializer();
            String dataJson = json_par.Serialize(listinfo.Personalinfo);
            return dataJson;
        }
    }

    public class ListInfo {
    
        public List<PersonalInfo> Personalinfo { get; set; }
    }
}