﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentData
{
    public class StudentListReturn
    {
        public int totalRecord { get; set; }
        public List<SchoolList> SchoolLists { get; set; }
    }
}
