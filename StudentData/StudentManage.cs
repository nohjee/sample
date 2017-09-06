using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic;


namespace StudentData
{
    public class StudentManage
    {
        public List<String> getTitleList()
        {
            SchoolContext schoolContext = new SchoolContext();
            var list = from course in schoolContext.CourseModelses
                select course.Title;

            return list.ToList();
        }

        public StudentListReturn GetSchoolList(String draw, String start, String length, String sortColumn,
            String sortColumnDir,
            String searchId, String searchTitle)
        {
            using (SchoolContext schoolContext = new SchoolContext()) 
            {
                var schoolList = schoolContext.EnrollmentModelses.GroupJoin(schoolContext.CourseModelses,
                    e => e.CourseModelsID, c => c.CourseModelsID, (e, c) => new { enroll = e, course = c }).SelectMany(
                    course => course.course.DefaultIfEmpty(), (e, c) => new { enroll = e.enroll, coruse = c }).GroupJoin(
                    schoolContext.StudentModels, e => e.enroll.StudentModelsID, s => s.StudentModelsID,
                    (e, s) => new { enroll = e, student = s }).SelectMany(
                    student => student.student.DefaultIfEmpty(), (e, s) => new { enroll = e.enroll, student = s }).Select(
                    list => new SchoolList()
                    {
                        EnrollmentModelsID = list.enroll.enroll.EnrollmentModelsID,
                        StudentModelsID = list.student.StudentModelsID,
                        CourseModelsID = list.enroll.coruse.CourseModelsID,
                        Grade = list.enroll.enroll.Grade,
                        Title = list.enroll.coruse.Title,
                        Credits = list.enroll.coruse.Credits,
                        LastName = list.student.LastName,
                        FirstMidName = list.student.FirstMidName,
                        EnrollmentDate = list.student.EnrollmentDate
                    });

                if (!string.IsNullOrEmpty(searchId))
                {
                    int findId = Convert.ToInt32(searchId);
                    schoolList = schoolList.Where(s => s.StudentModelsID == findId);
                }
                if (!string.IsNullOrEmpty(searchTitle))
                {
                    schoolList = schoolList.Where(s => s.Title.Contains(searchTitle));
                }

                if (!(string.IsNullOrEmpty(sortColumn)) && !(string.IsNullOrEmpty(sortColumnDir)))
                {
                    schoolList = schoolList.OrderBy(sortColumn + " " + sortColumnDir);
                }

                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int totalRecords = 0;

                totalRecords = schoolList.Count();
                var infoList = schoolList.Skip(skip).Take(pageSize).ToList();

                StudentListReturn studentListReturn = new StudentListReturn();
                studentListReturn.totalRecord = totalRecords;
                studentListReturn.SchoolLists = infoList;

                return studentListReturn;
            }
            
        }

        public Student GetStudent(int? enrollId)
        {
            using (SchoolContext schoolContext = new SchoolContext())
            {
                var studentInfo = schoolContext.EnrollmentModelses.Join(schoolContext.StudentModels, e => e.StudentModelsID,
                        s => s.StudentModelsID, (e, s) => new { enroll = e, student = s }).Join(
                        schoolContext.CourseModelses,
                        e => e.enroll.CourseModelsID,
                        c => c.CourseModelsID, (e, c) => new { enroll = e, course = c })
                    .Where(e => e.enroll.enroll.EnrollmentModelsID == enrollId).Select(
                        student => new Student()
                        {
                            StudentModelsID = student.enroll.enroll.StudentModelsID,
                            CourseModelsID = student.course.CourseModelsID,
                            EnrollmentModelsID = student.enroll.enroll.EnrollmentModelsID,
                            LastName = student.enroll.student.LastName,
                            FirstMidName = student.enroll.student.FirstMidName,
                            Title = student.course.Title
                        }).FirstOrDefault();

                return studentInfo;
            }
           
        }

        public bool SetStudent(Student student)
        {
            using (SchoolContext schoolContext = new SchoolContext())
            {
                if (!(student.StudentModelsID <= 0) && !(student.Title.Equals("")))
                {
                    //edit
                    var studentEdit = schoolContext.StudentModels
                        .FirstOrDefault(s => s.StudentModelsID == student.StudentModelsID);

                    var courseId = schoolContext.CourseModelses.FirstOrDefault(c => c.Title.Contains(student.Title));

                    if (studentEdit != null && courseId != null)
                    {
                        studentEdit.FirstMidName = student.FirstMidName;
                        studentEdit.LastName = student.LastName;
                        var enroll =
                            schoolContext.EnrollmentModelses.FirstOrDefault(
                                e => e.EnrollmentModelsID == student.EnrollmentModelsID);
                        enroll.CourseModelsID = courseId.CourseModelsID;
                    }
                }
                else
                {
                    //save
                    var maxid = schoolContext.StudentModels.Max(s => s.StudentModelsID);
                    var addId = maxid + 1;
                    var courseId = schoolContext.CourseModelses.FirstOrDefault(c => c.Title.Contains(student.Title));

                    var studentModels = new StudentModels();
                    studentModels.StudentModelsID = addId;
                    studentModels.FirstMidName = student.FirstMidName;
                    studentModels.LastName = student.LastName;
                    studentModels.EnrollmentDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    schoolContext.StudentModels.Add(studentModels);

                    var enroll = new EnrollmentModels();
                    enroll.StudentModelsID = addId;
                    enroll.CourseModelsID = courseId.CourseModelsID;
                    schoolContext.EnrollmentModelses.Add(enroll);

                }
                schoolContext.SaveChanges();
                return true;
            }
            
        }

        public bool DeleteStudent(Student student)
        {
            using (SchoolContext schoolContext = new SchoolContext())
            {
                var v = schoolContext.EnrollmentModelses.FirstOrDefault(
                    e => e.EnrollmentModelsID == student.EnrollmentModelsID);
                if (v != null)
                {
                    var studentModel =
                        schoolContext.StudentModels.FirstOrDefault(s => s.StudentModelsID == v.StudentModelsID);
                    schoolContext.EnrollmentModelses.Remove(v);
                    schoolContext.StudentModels.Remove(studentModel);
                    schoolContext.SaveChanges();
                    return true;
                }
                return false;
            }
        }
    }
}
