using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndocPM.WebAPI
{
    public class Category
    {
        public Category()
        {
            this.Specialities = new List<Speciality>();
            this.SubSpecialities = new List<SubSpeciality>();
        }

        public int CategoryID { get; set; }
        public string CategoryDescription { get; set; }
        public Nullable<int> GroupID { get; set; }
        public bool Deleted { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public virtual ICollection<Speciality> Specialities { get; set; }
        public virtual ICollection<SubSpeciality> SubSpecialities { get; set; }
    }
}
