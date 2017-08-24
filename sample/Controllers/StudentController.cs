using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using sample.DAL;
using sample.Models;

namespace sample.Controllers
{
    public class StudentController : Controller
    {

        // GET: Student
        public ActionResult Index()
        {
            
            ViewBag.Message = "Student List";
            return View();
        }

        public ActionResult SchoolAdd()
        {
            return View();
        }

        [HttpPost]
        public String AddSchoolData(StudentModels studentModels, CourseModels courseModels)
        {
            StudentInsert studentInsert = new StudentInsert();
            String result = studentInsert.SetAddStudent(studentModels, courseModels);

            return result;
        }

        [HttpPost]
        public String GetSelectStudent(int searchId)
        {
            SchoolManagement studentSearch = new SchoolManagement();
            String result = studentSearch.GetSearchStudent(searchId);
            return result;
        }

        [HttpGet]
        public String CourseList()
        {
            StudentInsert studentInsert = new StudentInsert();
            String jsonCourse = studentInsert.GetCourseList();

            return jsonCourse;
        }

        [HttpGet]
        public String GetSchoolList()
        {
            SchoolManagement schoolManagement = new SchoolManagement();
            return schoolManagement.GetStudentList();
        }
    }
}