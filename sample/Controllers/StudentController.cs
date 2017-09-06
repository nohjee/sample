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
        public String GetTitleList()
        {
            StudentManage studentManage = new StudentManage();
            var list = studentManage.getTitleList();
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            return javaScriptSerializer.Serialize(list);
        }

        [HttpPost]
        public ActionResult LoadSchoolList()
        {
            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var start = Request.Form.GetValues("start").FirstOrDefault();
            var length = Request.Form.GetValues("length").FirstOrDefault();

            var sortColumn = Request.Form
                .GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]")
                .FirstOrDefault();
            var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();

            var searchId = Request.Form.GetValues("columns[0][search][value]").FirstOrDefault();
            var searchTitle = Request.Form.GetValues("columns[6][search][value]").FirstOrDefault();

            StudentManage studentManage = new StudentManage();
            var schoolList = studentManage.GetSchoolList(draw, start, length, 
                sortColumn, sortColumnDir, searchId, searchTitle);
        
            return Json(new
                {
                    draw = draw,
                    recordsFiltered = schoolList.totalRecord,
                    recordTotal = schoolList.totalRecord,
                    data = schoolList.SchoolLists
            },
                JsonRequestBehavior.AllowGet
            );
                        
        }

        [HttpGet]
        public ActionResult Save(int? enrollId)
        {

            StudentManage studentManage = new StudentManage();
            var student = studentManage.GetStudent(enrollId);
            return View(student);

        }

        [HttpPost]
        public ActionResult Save(StudentData.Student student)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                StudentManage studentManage = new StudentManage();
                status = studentManage.SetStudent(student);      
            }
            return new JsonResult {Data = new {status = status}};
        }


        [HttpGet]
        public ActionResult Delete(int? enrollId)
        {
            StudentManage studentManage = new StudentManage();
            return View(studentManage.GetStudent(enrollId));         
        }

        [HttpPost]
        public ActionResult Delete(StudentData.Student student)
        {
            bool status = false; 
            StudentManage studentManage = new StudentManage();
            status = studentManage.DeleteStudent(student);
            return new JsonResult { Data = new { status = status } };
        }
    }
}