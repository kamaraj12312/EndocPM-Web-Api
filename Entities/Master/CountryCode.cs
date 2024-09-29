using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EndocPM.WebAPI
{
    public partial class CountryCode
    {
        [Key]
        public int CountryCodeID { get; set; }
        public string Code { get; set; }
        public string CountryName { get; set; }
        public string SequenceCode { get; set; }
        public Nullable<int> CountryOrder { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy{ get; set; }
        public Nullable<DateTime> ModifiedDate{ get; set; }
        public string ModifiedBy{ get; set; }
    }
}