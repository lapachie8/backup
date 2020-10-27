using System;
using System.Collections.Generic;
using System.Text;
using Admin.Common.Commands;
using Admin.Common.Dtos;
using Admin.Repository;
using Admin.Repository.Models;
using AutoMapper;
using Castle.Components.DictionaryAdapter;
using QSI.Common.Web;
using QSI.Persistence.Query;
using QSI.Persistence.Query.Statement.Operation;

namespace Admin.Service.Impls
{
    public class StudentService : IStudentService
    {
        private readonly IStudentDao studentDao;
        private readonly IMapper mapper;
        private readonly ConditionFactory conditionFactory;

        public StudentService(IStudentDao studenDao, IMapper mapper, ConditionFactory conditionFactory)
        {
            this.studentDao = studenDao;
            this.mapper = mapper;
            this.conditionFactory = conditionFactory;
        }

        public void DeleteStudent(int id)
        {
            var student = studentDao.Get(id);
            studentDao.Delete(student.Id);
        }

        public StudentDto GetStudentById(int id)
        {
            var student = studentDao.Get(id);
            StudentDto dto = mapper.Map<StudentDto>(student);

            return dto;
        }

        public StudentDto GetStudentByName(string name)
        {
            var student = studentDao.GetStudentByName(name);
            StudentDto dto = mapper.Map<StudentDto>(student);
            return dto;
        }

        public int RegisterNewStudent(AddStudentCommand command)
        {
            StudentModel model = mapper.Map<StudentModel>(command);
            model = studentDao.Save(model);

            return model.Id;
        }

        public void UpdateStudentData(int id, AddStudentCommand command)
        {
            var student = studentDao.Get(id);
            studentDao.Delete(student.Id);

            StudentModel model = mapper.Map<StudentModel>(command);
            model = studentDao.Save(model);
        }
    }
}
