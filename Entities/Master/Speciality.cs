using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndocPM.WebAPI
{
    public class Speciality
    {
        public Speciality()
        {
            //this.ProviderSpecialities = new List<ProviderSpeciality>();
            //this.ReferralProviderSpecialities = new List<ReferralProviderSpeciality>();
            //this.SubSpecialities = new List<SubSpeciality>();
        }

        public int SpecialityID { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public string SpecialityCode { get; set; }
        public string SpecialityDescription { get; set; }
        public Nullable<int> GroupID { get; set; }
        public bool Deleted { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public virtual Category Category { get; set; }
        //public virtual ICollection<ProviderSpeciality> ProviderSpecialities { get; set; }
        //public virtual ICollection<ReferralProviderSpeciality> ReferralProviderSpecialities { get; set; }
        //public virtual ICollection<SubSpeciality> SubSpecialities { get; set; }
        //public virtual ICollection<FacilitySpecialty> FacilitySpecialties { get; set; }
    }
}
