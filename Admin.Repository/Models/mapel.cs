using QSI.Persistence.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Repository.Models
{
    public class mapel : AuditedEntity<int>
    {
        public virtual int studentId { get; set; }
        public virtual decimal pai { get; set; }
        public virtual decimal pkn { get; set; }
        public virtual decimal mtk { get; set; }
        public virtual decimal ipa { get; set; }
        public virtual decimal ips { get; set; }
        public virtual decimal bindo { get; set; }
        public virtual decimal binggris { get; set; }
        public virtual StudentModel Model { get; set; }

        public override bool Equals(object obj)
        {
            var mapel = obj as mapel;
            return mapel != null &&
                   studentId == mapel.studentId &&
                   pai == mapel.pai &&
                   pkn == mapel.pkn &&
                   mtk == mapel.mtk &&
                   ipa == mapel.ipa &&
                   ips == mapel.ips &&
                   bindo == mapel.bindo &&
                   binggris == mapel.binggris &&
                   EqualityComparer<StudentModel>.Default.Equals(Model, mapel.Model);
        }

        public override int GetHashCode()
        {
            var hash = new HashCode();
            hash.Add(studentId);
            hash.Add(pai);
            hash.Add(pkn);
            hash.Add(mtk);
            hash.Add(ipa);
            hash.Add(ips);
            hash.Add(bindo);
            hash.Add(binggris);
            hash.Add(Model);
            return hash.ToHashCode();
        }
    }
}
