using Admin.Common.Commands;
using Admin.Common.Dtos;
using QSI.Common.Web;
using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Service
{
    public interface IStudentService
    {
        int RegisterNewStudent(AddStudentCommand command);
        StudentDto GetStudentById(int id);
        StudentDto GetStudentByName(string name);
        void DeleteStudent(int id);
        void UpdateStudentData(int id, AddStudentCommand command);
    }
}
