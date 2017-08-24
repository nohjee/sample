using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.ModelBinding;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using sample.Models;
using sample.DAL;

namespace sample.DAL
{
    public class StudentInsert
    {
       
        public String SetAddStudent(StudentModels studentModels,CourseModels courseModels)
        {
            try
            {
                SchoolContext context = new SchoolContext();
                studentModels.EnrollmentDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                context.StudentModels.Add(studentModels);
                context.SaveChanges();

                EnrollmentModels enrollmentModels = new EnrollmentModels();
                enrollmentModels.StudentModelsID = studentModels.StudentModelsID;
                enrollmentModels.CourseModelsID = courseModels.CourseModelsID;
                context.EnrollmentModelses.Add(enrollmentModels);
                context.SaveChanges();
                return "success";
            }
            
            catch (DbUpdateException exception)
            {
                Console.WriteLine(exception.ToString());
                return "fail";
            }
           
        }


        public String GetCourseList()
        {
            try
            {
                SchoolContext context = new SchoolContext();
                var courseList = (from course in context.CourseModelses
                    select new CourseListModels()
                    {
                        CourseModelsID = course.CourseModelsID,
                        Credits = course.Credits,
                        Title = course.Title
                    }).ToList();

                JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                String jsonCourse = javaScriptSerializer.Serialize(courseList);

                return jsonCourse;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
           
        }
    }
}