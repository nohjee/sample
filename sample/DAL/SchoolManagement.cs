using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
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
        public async Task<List<StudentListModels>> GetSearchStudent(int searchId)
        {
            using (SchoolContext context = new SchoolContext())
            {
                try
                {
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

                    return findId;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return null;
                }
            }
        }

        public async Task<List<StudentListModels>> GetStudentList()
        {
            using (SchoolContext context = new SchoolContext())
            {
                try
                {
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

                    return schoolData;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return null;
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
                    context.SaveChanges();
                    return "success";
                }
                catch (DbUpdateException exception)
                {
                    Console.WriteLine(exception.ToString());
                    return "fail";
                }
            }
        }


        public async Task<List<CourseListModels>> GetCourseList()
        {
            using (SchoolContext context = new SchoolContext())
            {
                try
                {
                    var courseList = (from course in context.CourseModelses
                        select new CourseListModels()
                        {
                            CourseModelsID = course.CourseModelsID,
                            Credits = course.Credits,
                            Title = course.Title
                        }).ToList();

                    return courseList;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return null;
                }
            }
        }
    }
}