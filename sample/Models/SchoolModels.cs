using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sample.Models
{
    public class StudentModels
    {
        public int StudentModelsID { get; set; }
        public String LastName { get; set; }
        public String FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public virtual ICollection<EnrollmentModels> EnrollmentModelses { get; set; }
    }

    public class CourseModels
    {
        public int CourseModelsID { get; set; }
        public String Title { get; set; }
        public int Credits { get; set; }
        public virtual ICollection<EnrollmentModels> EnrollmentModelses { get; set; }
    }

    public class EnrollmentModels
    {
        public int EnrollmentModelsID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public decimal? Grade { get; set; }
        public virtual CourseModels Course { get; set; }
        public virtual StudentModels Student { get; set; }
    }
}