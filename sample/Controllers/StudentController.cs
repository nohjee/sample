using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public ActionResult ErrorMessage()
        {
            return View();
        }

        [HttpPost]
        public String AddStudentInfomation(StudentModels studentModels, CourseModels courseModels)
        {
            SchoolManagement schoolManagement = new SchoolManagement();
            String result = schoolManagement.SetStudentInfomation(studentModels, courseModels);

            return result;
        }

        [HttpPost]
        public async Task<string> GetSelectStudent(int searchId)
        {
            SchoolManagement studentSearch = new SchoolManagement();
            String selectStudnet = await studentSearch.GetSearchStudent(searchId);
            return selectStudnet;
        }

        [HttpGet]
        public async Task<string> CourseList()
        {
            SchoolManagement schoolManagement = new SchoolManagement();
            String courseList = await schoolManagement.GetCourseList();       
            return courseList;
        }

        [HttpGet]
        public async Task<string> GetSchoolList()
        {
            SchoolManagement schoolManagement = new SchoolManagement();
            String studentList = await schoolManagement.GetStudentList();
            return studentList;
        }
    }
}