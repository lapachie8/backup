using QSI.Persistence.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Repository.Models
{
    public class TeacherModel : AuditedEntity<int>
    {
        public virtual string name { get; set; }
        public virtual string birthDate { get; set; }
        public virtual string address { get; set; }
        public virtual string lastAcad { get; set; }
        public virtual bool isDeleted { get; set; }

        public override bool Equals(object obj)
        {
            var model = obj as TeacherModel;
            return model != null &&
                   name == model.name &&
                   birthDate == model.birthDate &&
                   address == model.address &&
                   lastAcad == model.lastAcad &&
                   isDeleted == model.isDeleted;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine( name, birthDate, address, lastAcad, isDeleted);
        }
    }
}
