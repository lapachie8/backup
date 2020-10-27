using QSI.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Repository
{
    public interface IStudentDao : BaseDao<Repository.Models.StudentModel, int>
    {
        Repository.Models.StudentModel GetStudentByName(string name);
    }
}
