using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EndocPM.WebAPI
{
    public partial class PostalCode
    {
        [Key]
        public int PostalCodeID { get; set; }
        public string ZIP { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string County { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}