using System;
using System.Collections.Generic;
using System.Text;
using Admin.Common.Commands;
using Admin.Common.Dtos;
using Admin.Repository;
using Admin.Repository.Models;
using AutoMapper;
using QSI.Common.Web;

namespace Admin.Service.Impls
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherDao teacherDao;
        private readonly IMapper mapper;

        public TeacherService(ITeacherDao teacherDao, IMapper mapper)
        {
            this.teacherDao = teacherDao;
            this.mapper = mapper;
        }

        public void DeleteTeacher(int id)
        {
            var teacher = teacherDao.Get(id);
            teacherDao.Delete(teacher.Id);
        }

        public TeacherDto GetTeacherById(int id)
        {
            var teacher = teacherDao.Get(id);
            TeacherDto dto = mapper.Map<TeacherDto>(teacher);

            return dto;
        }

        public TeacherDto GetTeacherByName(string name)
        {
            var teacher = teacherDao.GetTeacherByName(name);
            TeacherDto dto = mapper.Map<TeacherDto>(teacher);
            return dto;
        }

        //public DataTable<TeacherDto> GetTeacherByPaging(int page, int size)
        //{
        //    throw new NotImplementedException();
        //}

        public int RegisterNewTeacher(AddTeacherCommand command)
        {
            TeacherModel model = mapper.Map<TeacherModel>(command);
            model = teacherDao.Save(model);

            return model.Id;
        }

        public void UpdateTeacherData(int id, AddTeacherCommand command)
        {
            var teacher = teacherDao.Get(id);
            teacherDao.Delete(teacher.Id);

            TeacherModel model = mapper.Map<TeacherModel>(command);
            model = teacherDao.Save(model);
            
        }
    }
}
