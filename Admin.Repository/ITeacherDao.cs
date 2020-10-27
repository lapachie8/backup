using QSI.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Repository
{
    public interface ITeacherDao : BaseDao<Repository.Models.TeacherModel, int>
    {
        Repository.Models.TeacherModel GetTeacherByName(string name);
    }
}
