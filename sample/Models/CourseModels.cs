using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sample.Models
{
    public class CourseModels
    {
        public int CourseModelsID { get; set; }
        public String Title { get; set; }
        public int Credits { get; set; }
        public virtual ICollection<EnrollmentModels> EnrollmentModelses { get; set; }
    }
}