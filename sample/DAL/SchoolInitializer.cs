using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using sample.Models;
using StudentData;

namespace sample.DAL
{
    public class SchoolInitializer : DropCreateDatabaseIfModelChanges<SchoolContext>
    {
        protected override void Seed(SchoolContext context)
        {
            var students = new List<StudentModels>()
            {
                new StudentModels
                {
                    FirstMidName = "Carson",
                    LastName = "Alexander",
                    EnrollmentDate = DateTime.Parse("2005-09-01")
                },
                new StudentModels
                {
                    FirstMidName = "Meredith",
                    LastName = "Alonso",
                    EnrollmentDate = DateTime.Parse("2002-09-01")
                },
                new StudentModels
                {
                    FirstMidName = "Arturo",
                    LastName = "Anand",
                    EnrollmentDate = DateTime.Parse("2003-09-01")
                },
                new StudentModels
                {
                    FirstMidName = "Gytis",
                    LastName = "Barzdukas",
                    EnrollmentDate = DateTime.Parse("2002-09-01")
                },
                new StudentModels
                {
                    FirstMidName = "Yan",
                    LastName = "Li",
                    EnrollmentDate = DateTime.Parse("2002-09-01")
                },
                new StudentModels
                {
                    FirstMidName = "Peggy",
                    LastName = "Justice",
                    EnrollmentDate = DateTime.Parse("2001-09-01")
                },
                new StudentModels
                {
                    FirstMidName = "Laura",
                    LastName = "Norman",
                    EnrollmentDate = DateTime.Parse("2003-09-01")
                },
                new StudentModels
                {
                    FirstMidName = "Nino",
                    LastName = "Olivetto",
                    EnrollmentDate = DateTime.Parse("2005-09-01")
                }

            };

            students.ForEach(s => context.StudentModels.Add(s));
            context.SaveChanges();

            var courses = new List<CourseModels>
            {
                new CourseModels { Title = "Chemistry",    Credits = 3, },
                new CourseModels { Title = "Microeconomics", Credits = 3, },
                new CourseModels { Title = "Macroeconomics", Credits = 3, },
                new CourseModels { Title = "Calculus",    Credits = 4, },
                new CourseModels { Title = "Trigonometry",  Credits = 4, },
                new CourseModels { Title = "Composition",  Credits = 3, },
                new CourseModels { Title = "physics", Credits = 2, },
                new CourseModels { Title = "mathematics", Credits = 2, },
                new CourseModels { Title = "Literature",  Credits = 4, }
            };
            courses.ForEach(s => context.CourseModelses.Add(s));
            context.SaveChanges();

            var enrollments = new List<EnrollmentModels>
            {
                new EnrollmentModels { StudentModelsID = 1, CourseModelsID = 1, Grade = 1 },
                new EnrollmentModels { StudentModelsID = 1, CourseModelsID = 2, Grade = 3 },
                new EnrollmentModels { StudentModelsID = 1, CourseModelsID = 3, Grade = 1 },
                new EnrollmentModels { StudentModelsID = 2, CourseModelsID = 4, Grade = 2 },
                new EnrollmentModels { StudentModelsID = 2, CourseModelsID = 5, Grade = 3 },
                new EnrollmentModels { StudentModelsID = 2, CourseModelsID = 6, Grade = 5 },
                new EnrollmentModels { StudentModelsID = 3, CourseModelsID = 1, Grade = 4 },
                new EnrollmentModels { StudentModelsID = 4, CourseModelsID = 1, Grade = 3 },
                new EnrollmentModels { StudentModelsID = 4, CourseModelsID = 2, Grade = 4 },
                new EnrollmentModels { StudentModelsID = 5, CourseModelsID = 3, Grade = 3 },
                new EnrollmentModels { StudentModelsID = 6, CourseModelsID = 4, Grade = 5 },
                new EnrollmentModels { StudentModelsID = 7, CourseModelsID = 5, Grade = 2 },
            };
            enrollments.ForEach(s => context.EnrollmentModelses.Add(s));
            context.SaveChanges();
        }

    }
    
}