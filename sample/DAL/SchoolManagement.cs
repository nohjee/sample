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
        public String GetSearchStudent(int searchId)
        {
            try
            {
                SchoolContext context = new SchoolContext();

                var findId = (from enroll in context.EnrollmentModelses
                    join
                    coures in context.CourseModelses on
                    enroll.CourseModelsID equals coures.CourseModelsID
                    into leftenroll1
                    from coures in leftenroll1.DefaultIfEmpty()
                    join
                    student in context.StudentModels on
                    enroll.StudentModelsID equals student.StudentModelsID
                    into leftenroll2
                    from student in leftenroll2.DefaultIfEmpty()
                    where enroll.StudentModelsID == searchId
                    orderby enroll.EnrollmentModelsID
                    select
                    new StudentListModels()
                    {
                        StudentModelsID = student.StudentModelsID,
                        CourseModelsID = coures.CourseModelsID,
                        EnrollmentModelsID = enroll.EnrollmentModelsID,
                        Grade = enroll.Grade,
                        Title = coures.Title,
                        Credits = coures.Credits,
                        FirstMidName = student.FirstMidName,
                        LastName = student.LastName,
                        EnrollmentDate = student.EnrollmentDate
                    }).ToList();


                JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                String result = javaScriptSerializer.Serialize(findId);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
           

        }

        public String GetStudentList()
        {
            try
            {
                SchoolContext context = new SchoolContext();
                var schoolData = (from enroll in context.EnrollmentModelses
                    join
                    coures in context.CourseModelses on
                    enroll.CourseModelsID equals coures.CourseModelsID
                    into leftenroll1
                    from coures in leftenroll1.DefaultIfEmpty()
                    join
                    student in context.StudentModels on
                    enroll.StudentModelsID equals student.StudentModelsID
                    into leftenroll2
                    from student in leftenroll2.DefaultIfEmpty()
                    orderby enroll.EnrollmentModelsID
                    select
                    new StudentListModels()
                    {
                        StudentModelsID = enroll.StudentModelsID,
                        CourseModelsID = enroll.CourseModelsID,
                        EnrollmentModelsID = enroll.EnrollmentModelsID,
                        Grade = enroll.Grade,
                        Title = coures.Title,
                        Credits = coures.Credits,
                        FirstMidName = student.FirstMidName,
                        LastName = student.LastName,
                        EnrollmentDate = student.EnrollmentDate
                    }).ToList();

                JavaScriptSerializer schoolList = new JavaScriptSerializer();
                String jsonSchoolList = schoolList.Serialize(schoolData);

                return jsonSchoolList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }
    }
}