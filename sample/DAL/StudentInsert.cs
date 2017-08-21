using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using sample.Models;
using sample.DAL;

namespace sample.DAL
{
    public class StudentInsert
    {
       
        public void InsertData(StudentModels studentModels)
        {
            SchoolContext context = new SchoolContext();
            studentModels.EnrollmentDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            context.StudentModels.Add(studentModels);
            context.SaveChanges();
        }

    }
}