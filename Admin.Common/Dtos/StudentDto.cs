using System;
using System.Collections.Generic;
using System.Text;
using Teacher.Nilai.Repository.Models;

namespace Admin.Common.Dtos
{
    public class StudentDto
    {
        public int nisn { get; set; }
        public string name { get; set; }
        public string birthDate { get; set; }
        public string address { get; set; }
        public string majors { get; set; }
        public string gender { get; set; }
        public string fatherName { get; set; }
        public string motherName { get; set; }
        public IList<TeacherNilaiModel> NilaiModel { get; set; }
    }
}
