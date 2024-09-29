using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndocPM.WebAPI
{
    public class SubSpeciality
    {
        public int SubSpecialityID { get; set; }
        public int CategoryID { get; set; }
        public int SpecialityID { get; set; }
        public string SpecialityCode { get; set; }
        public string SubSpecialityCode { get; set; }
        public string SubSpecialityDescription { get; set; }
        public Nullable<int> GroupID { get; set; }
        public bool Deleted { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public virtual Category Category { get; set; }
        public virtual Speciality Speciality { get; set; }
    }
}
