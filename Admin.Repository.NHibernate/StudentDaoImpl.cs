using Admin.Repository.Models;
using NHibernate.Criterion;
using QSI.ORM.NHibernate.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Repository.NHibernate
{
    public class StudentDaoImpl : BaseDaoNHibernate<Repository.Models.StudentModel, int>, IStudentDao
    {
        public StudentModel GetStudentByName(string name)
        {
            return (StudentModel)Session.CreateCriteria<StudentModel>()
                .Add(Restrictions.Eq("Name", name))
                .UniqueResult();
        }
    }
}
