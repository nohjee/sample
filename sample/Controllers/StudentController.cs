using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sample.DAL;
using sample.Models;

namespace sample.Controllers
{
    public class StudentController : Controller
    {
        private SchoolContext db = new SchoolContext();
        // GET: Student
        public ActionResult Index()
        {
            ViewBag.Message = "Student List";
            return View(db.StudentModelses.ToList());
        }

        [HttpPost]
        public String DataInsert(StudentModels studentModels)
        {
            StudentInsert studentInsert = new StudentInsert();
            studentInsert.InsertData(studentModels);

            return "success";
        }
    }
}