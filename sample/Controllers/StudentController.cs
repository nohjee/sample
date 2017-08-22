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
       
        // GET: Student
        public ActionResult Index()
        {
            SchoolContext context = new SchoolContext();
            ViewBag.Message = "Student List";
            return View(context.StudentModels.ToList());
        }

        [HttpPost]
        public String DataInsert(StudentModels studentModels)
        {
            StudentInsert studentInsert = new StudentInsert();
            studentInsert.InsertData(studentModels);

            return "success";
        }

        [HttpPost]
        public String SearchId(int searchId)
        {
            SchoolContext context = new SchoolContext();
            StudentModels findId = context.StudentModels.Find(searchId);

            String insertHtml = ""; 

            if (findId == null)
            {
                insertHtml = "<tr><td colspan='4'>찾는 id가 없습니다.</td></tr>";
                return insertHtml;
            }
            insertHtml = "<tr>";
            insertHtml += "<td>" + findId.StudentModelsID + "</td>";
            insertHtml += "<td>" + findId.LastName + "</td>";
            insertHtml += "<td>" + findId.FirstMidName + "</td>";
            insertHtml += "<td>" + findId.EnrollmentDate + "</td>";
            insertHtml += "</tr>";

            return insertHtml;

        }
    }
}