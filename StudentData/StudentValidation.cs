using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentData
{

    [MetadataType(typeof(SchoolMetadata))]
    public partial class Student
    {

    }

    public class SchoolMetadata
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Plase provide firstmid name")]
        public String FirstMidName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Plase provide last name")]
        public String LastName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Plase provide Title")]
        public String Title { get; set; }

    }
 
}
