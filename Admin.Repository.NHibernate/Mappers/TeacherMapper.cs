using QSI.ORM.NHibernate.Mapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Repository.NHibernate.Mappers
{
    public class TeacherMapper : BaseAuditedEntityMapper<Repository.Models.TeacherModel, int>
    {
        public TeacherMapper () : base()
        {
            Table("teacher");

            Id(x => x.Id).GeneratedBy.Native();
            Map(x => x.name).Not.Nullable();
            Map(x => x.birthDate).Not.Nullable();
            Map(x => x.address).Not.Nullable();
            Map(x => x.lastAcad).Not.Nullable();
            Map(x => x.isDeleted).Not.Nullable();
        }
    }
}
