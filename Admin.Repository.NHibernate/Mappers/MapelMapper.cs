using QSI.ORM.NHibernate.Mapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Repository.NHibernate.Mappers
{
    public class MapelMapper : BaseAuditedEntityMapper<Repository.Models.mapel, int>
    {
        public MapelMapper() : base()
        {
            Table("mapel");
            Id(x => x.Id).GeneratedBy.Native();
            Map(x => x.studentId).Not.Nullable();
            Map(x => x.pai).Not.Nullable().Default("0");
            Map(x => x.ipa).Not.Nullable().Default("0");
            Map(x => x.ips).Not.Nullable().Default("0");
            Map(x => x.mtk).Not.Nullable().Default("0");
            Map(x => x.pkn).Not.Nullable().Default("0");
            Map(x => x.bindo).Not.Nullable().Default("0");
            Map(x => x.binggris).Not.Nullable().Default("0");
            References(x => x.Model).Column("student_id").ForeignKey("student_id").LazyLoad().Not.Nullable();
        }
    }
}
