using QSI.ORM.NHibernate.Mapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Repository.NHibernate.Mappers
{
    public class StudentMapper : BaseAuditedEntityMapper<Repository.Models.StudentModel, int>
    {
        public StudentMapper() : base()
        {
            Table("student");

            Id(x => x.Id).GeneratedBy.Native();
            Map(x => x.studentId).Not.Nullable();
            Map(x => x.nisn).Not.Nullable();
            Map(x => x.name).Not.Nullable();
            Map(x => x.birthDate).Not.Nullable();
            Map(x => x.religion).Not.Nullable();
            Map(x => x.address).Not.Nullable();
            Map(x => x.majors).Not.Nullable();
            Map(x => x.gender).Not.Nullable();
            Map(x => x.fatherName).Not.Nullable();
            Map(x => x.motherName).Not.Nullable();
            HasMany(x => x.mapels).KeyColumn("student_id").ForeignKeyConstraintName("student_id");
        }

    }
}
