using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EndocPM.WebAPI
{
    public partial class UserTenantSetup
    {
        [Key]
        public int UserTenantID { get; set; }
        public int UserID { get; set; }
        public string TenantIDs { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
