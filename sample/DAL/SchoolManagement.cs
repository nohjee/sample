using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using sample.Models;

namespace sample.DAL
{
    public class SchoolManagement
    {
        [HttpPost]
        public String SearchId(int searchId)
        {
            SchoolContext context = new SchoolContext();
            var findId = from m in context.StudentModels
                where m.StudentModelsID == searchId
                select 
                new
                {
                    m.StudentModelsID,
                    m.EnrollmentDate,
                    m.FirstMidName,
                    m.LastName
                };

            List<StudentModels> studentInfo = new List<StudentModels>();
            foreach (var key in findId)
            {
                studentInfo.Add(new StudentModels()
                {
                    StudentModelsID = key.StudentModelsID,
                    EnrollmentDate = key.EnrollmentDate,
                    FirstMidName = key.FirstMidName,
                    LastName = key.LastName
                });
            }
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            String result = javaScriptSerializer.Serialize(studentInfo);
            return result;

        }

        public List<SchoolListModels> SchoolList()
        {
            SchoolContext context = new SchoolContext();

            var schoolData = (from enroll in context.EnrollmentModelses
                join
                coures in context.CourseModelses on
                enroll.CourseModelsID equals coures.CourseModelsID
                join
                student in context.StudentModels on
                enroll.StudentModelsID equals student.StudentModelsID
                orderby enroll.EnrollmentModelsID
                select
                new
                {
                    enroll.StudentModelsID,
                    enroll.CourseModelsID,
                    enroll.EnrollmentModelsID,
                    enroll.Grade,
                    coures.Title,
                    coures.Credits,
                    student.FirstMidName,
                    student.LastName,
                    student.EnrollmentDate
                }).ToList();

            List<SchoolListModels> schoolList = new List<SchoolListModels>();

            foreach (var key in schoolData)
            {
                schoolList.Add(new SchoolListModels()
                {
                    StudentModelsID = key.StudentModelsID,
                    CourseModelsID = key.CourseModelsID,
                    EnrollmentModelsID = key.EnrollmentModelsID,
                    Grade = key.Grade,
                    Title = key.Title,
                    Credits = key.Credits,
                    FirstMidName = key.FirstMidName,
                    LastName = key.LastName,
                    EnrollmentDate = key.EnrollmentDate
                });
            }
            return schoolList;
        }
    }
}