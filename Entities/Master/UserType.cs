using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EndocPM.WebAPI
{
    public partial class UserType
    {
        [Key]
        public int UserTypeId { get; set; }
        public string UserTypeCode { get; set; }
        public string UserTypeDescription { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}