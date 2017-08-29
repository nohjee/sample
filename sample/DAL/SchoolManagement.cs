using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using sample.Models;

namespace sample.DAL
{
    public class SchoolManagement
    {
        [HttpPost]
        public async Task<String> GetSearchStudent(int searchId)
        {
            using (SchoolContext context = new SchoolContext())
            {
                try
                {
                    var findId = await (from enroll in context.EnrollmentModelses
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
                        }).ToListAsync();

                    String selectStudent = JsonParsing(findId);
                    return selectStudent;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return "error";
                }
            }
        }

        public async Task<String> GetStudentList()
        {
            using (SchoolContext context = new SchoolContext())
            {
                try
                {
                    var schoolData =await context.EnrollmentModelses.
                        GroupJoin(context.CourseModelses,
                            e => e.CourseModelsID, c => c.CourseModelsID, (e, c) => new {enroll = e, course = c})
                        .SelectMany(
                            course => course.course.DefaultIfEmpty(),
                            (e, c) => new {enroll = e.enroll, course = c}
                        ).GroupJoin(context.StudentModels, e => e.enroll.StudentModelsID, s => s.StudentModelsID,
                            (e, s) => new {enroll = e, student = s}).
                            SelectMany(
                            student => student.student.DefaultIfEmpty(),
                            (e, s) => new {enroll = e.enroll, Student = s})
                        .OrderBy(enroll => enroll.enroll.enroll.EnrollmentModelsID).Select(
                            list => new StudentListModels()
                            {
                                EnrollmentModelsID = list.enroll.enroll.EnrollmentModelsID,
                                CourseModelsID = list.enroll.course.CourseModelsID,
                                StudentModelsID = list.Student.StudentModelsID,
                                Grade = list.enroll.enroll.Grade,
                                Title = list.enroll.course.Title,
                                Credits = list.enroll.course.Credits,
                                LastName = list.Student.LastName,
                                FirstMidName = list.Student.FirstMidName,
                                EnrollmentDate = list.Student.EnrollmentDate
                            }
                        ).ToListAsync();

                    String studentList = JsonParsing(schoolData);
                    return studentList;
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return "error";
                }
            }
        }

        public String SetStudentInfomation(StudentModels studentModels, CourseModels courseModels)
        {
            using (SchoolContext context = new SchoolContext())
            {
                try
                {
                    studentModels.EnrollmentDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    context.StudentModels.Add(studentModels);
                    context.SaveChanges();
                    EnrollmentModels enrollmentModels = new EnrollmentModels();
                    enrollmentModels.StudentModelsID = studentModels.StudentModelsID;
                    enrollmentModels.CourseModelsID = courseModels.CourseModelsID;
                    context.EnrollmentModelses.Add(enrollmentModels);
                    int result = context.SaveChanges();
                    if (result > 0)
                    {
                        return "success";
                    }
                    
                        return "fail";
                    
  
                }
                catch (DbUpdateException exception)
                {
                    Console.WriteLine(exception.ToString());
                    return "error";
                }
            }
        }


        public async Task<String> GetCourseList()
        {
            
            using (SchoolContext context = new SchoolContext())
            {
                try
                {
                    var courseList = await context.CourseModelses.
                        OrderBy(course => course.CourseModelsID).
                        Select(
                        list => new CourseListModels()
                        {
                            CourseModelsID = list.CourseModelsID,
                            Credits = list.Credits,
                            Title = list.Title
                        }).ToListAsync();

                    String jsonCourseList = JsonParsing(courseList);
                    return jsonCourseList;   
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return "error";
                }
            }
        }

        public String JsonParsing(object jsonParsing)
        {
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            String jsonData = javaScriptSerializer.Serialize(jsonParsing);
            return jsonData;
        }
    }
}