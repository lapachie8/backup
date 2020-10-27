using Admin.Common.Commands;
using Admin.Common.Dtos;
using QSI.Common.Web;
using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Service
{
    public interface ITeacherService
    {
        int RegisterNewTeacher(AddTeacherCommand command);
        TeacherDto GetTeacherById(int id);
        TeacherDto GetTeacherByName(string name);
        //DataTable<TeacherDto> GetTeacherByPaging(int page, int size);
        void DeleteTeacher(int id);
        void UpdateTeacherData(int id, AddTeacherCommand command);
    }
}
