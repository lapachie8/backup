using QSI.Persistence.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Teacher.Nilai.Repository.Models;

namespace Admin.Repository.Models
{
    public class StudentModel : AuditedEntity<int>
    {
        public virtual int studentId { get; set; }
        public virtual int nisn { get; set; }
        public virtual string name { get; set; }
        public virtual string birthDate { get; set; }
        public virtual string religion { get; set; }
        public virtual string address { get; set; }
        public virtual string majors { get; set; }
        public virtual string gender { get; set; }
        public virtual string fatherName { get; set; }
        public virtual string motherName { get; set; }
        public virtual IList<mapel> mapels { get; set; }

        public override bool Equals(object obj)
        {
            var model = obj as StudentModel;
            return model != null &&
                   studentId == model.studentId &&
                   nisn == model.nisn &&
                   name == model.name &&
                   birthDate == model.birthDate &&
                   religion == model.religion &&
                   address == model.address &&
                   majors == model.majors &&
                   gender == model.gender &&
                   fatherName == model.fatherName &&
                   motherName == model.motherName &&
                   EqualityComparer<IList<mapel>>.Default.Equals(mapels, model.mapels);
        }

        public override int GetHashCode()
        {
            var hash = new HashCode();
            hash.Add(studentId);
            hash.Add(nisn);
            hash.Add(name);
            hash.Add(birthDate);
            hash.Add(religion);
            hash.Add(address);
            hash.Add(majors);
            hash.Add(gender);
            hash.Add(fatherName);
            hash.Add(motherName);
            hash.Add(mapels);
            return hash.ToHashCode();
        }
    }
}
