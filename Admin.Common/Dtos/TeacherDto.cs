using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Common.Dtos
{
    public class TeacherDto
    {
        public string name { get; set; }
        public string address { get; set; }
        public string birthDate { get; set; }
        public string lastAcad { get; set; }
        public bool isDeleted { get; set; }
    }
}
