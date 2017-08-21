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
}