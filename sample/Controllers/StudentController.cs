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

            SchoolManagement schoolManagement = new SchoolManagement();
            ViewBag.Message = "Student List";
            return View(schoolManagement.SchoolList());
        }

        [HttpPost]
        public String DataInsert(StudentModels studentModels)
        {
            StudentInsert studentInsert = new StudentInsert();
            studentInsert.InsertData(studentModels);

            return "success";
        }

        [HttpPost]
        public String StudentSelect(int searchId)
        {
            SchoolManagement studentSearch = new SchoolManagement();
            String result = studentSearch.SearchId(searchId);
            return result;
        }
    }
}