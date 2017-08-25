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
            List<StudentListModels> selectStudnet = await studentSearch.GetSearchStudent(searchId);
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            String jsonSelectStudnet = javaScriptSerializer.Serialize(selectStudnet);
            return jsonSelectStudnet;
        }

        [HttpGet]
        public async Task<string> CourseList()
        {
            SchoolManagement schoolManagement = new SchoolManagement();
            List<CourseListModels> courseList = await schoolManagement.GetCourseList();
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            String jsonCourse = javaScriptSerializer.Serialize(courseList);
            return jsonCourse;
        }

        [HttpGet]
        public async Task<string> GetSchoolList()
        {
            SchoolManagement schoolManagement = new SchoolManagement();
            List<StudentListModels> studentList = await schoolManagement.GetStudentList();
            JavaScriptSerializer schoolList = new JavaScriptSerializer();
            String jsonStudentlList = schoolList.Serialize(studentList);
            return jsonStudentlList;
        }
    }
}