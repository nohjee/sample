using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using sample.Models;

namespace sample.DAL
{
    public class StudentInsert
    {
        private  SchoolContext db = new SchoolContext();
        public void InsertData(StudentModels studentModels)
        {
            studentModels.EnrollmentDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            db.StudentModelses.Add(studentModels);
            db.SaveChanges();
        }

    }
}