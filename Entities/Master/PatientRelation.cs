using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EndocPM.WebAPI
{
    public partial class PatientRelation
    {
        [Key]
        public int PatientRelationID { get; set; }
        public string RelationCode { get; set; }
        public string EmdeonRelationCode { get; set; }
        public string RelationDescription { get; set; }
        public string HIPAARelationCode { get; set; }
        public Nullable<int> RelationOrder { get; set; }
        public string ImmunizationRegistryRelationCode { get; set; }
        public bool ViewInPatientFamily { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
