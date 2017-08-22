using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using sample.Models;

namespace sample.DAL
{
    public class StudentSearch
    {
        [HttpPost]
        public String SearchId(int searchId)
        {
            SchoolContext context = new SchoolContext();
            var findId = from m in context.StudentModels
                where m.StudentModelsID == searchId
                select m;

            List<StudentModels> studentInfo = findId.ToList();
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();

            return javaScriptSerializer.Serialize(studentInfo);

        }
    }
}