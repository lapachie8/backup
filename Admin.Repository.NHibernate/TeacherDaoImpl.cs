using Admin.Repository.Models;
using NHibernate.Criterion;
using QSI.ORM.NHibernate.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Repository.NHibernate
{
    public class TeacherDaoImpl : BaseDaoNHibernate<Repository.Models.TeacherModel, int>, ITeacherDao
    {
        public TeacherModel GetTeacherByName(string name)
        {
            return (TeacherModel)Session.CreateCriteria<TeacherModel>()
                .Add(Restrictions.Eq("Name", name))
                .UniqueResult();
        }
    }
}
