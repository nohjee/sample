using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using sample.DAL;
using sample.Models;
using System.Linq.Dynamic;
using System.Web.Script.Serialization;
using StudentData;

namespace sample.Controllers
{
    public class StudentController : Controller
    {

        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetTitles()
        {
            var studentManage = new StudentManage();
            return Json(new {Data = studentManage.GetTitleList()}, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult LoadSchoolList(SchoolListRequest request)
        {
            

            var studentManage = new StudentManage();
            var schoolList = studentManage.GetSchoolList(request);

            return Json(new
            {
                draw = request.Draw,
                recordsFiltered = schoolList.TotalRecord,
                recordTotal = schoolList.TotalRecord,
                data = schoolList.SchoolLists
            }, JsonRequestBehavior.AllowGet
            );

        }

        [HttpGet]
        public ActionResult Save(int enrollId)
        {
            var studentManage = new StudentManage();
            var student = studentManage.GetStudent(enrollId);
            return View(student);
        }

        [HttpPost]
        public ActionResult Save(StudentData.Student student)
        {
            var status = false;
            if (ModelState.IsValid)
            {
                var studentManage = new StudentManage();
                status = studentManage.SetStudent(student);
            }
            return Json(status);
        }


        [HttpGet]
        public ActionResult Delete(int enrollId)
        {
            var studentManage = new StudentManage();
            return View(studentManage.GetStudent(enrollId));
        }

        [HttpPost]
        public ActionResult Delete(StudentData.Student student)
        {
            var status = false;
            var studentManage = new StudentManage();
            status = studentManage.DeleteStudent(student);
            return Json(status);
        }
    }

   



}