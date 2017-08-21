using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sample.Models
{
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