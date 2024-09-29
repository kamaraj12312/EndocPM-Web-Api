using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EndocPM.WebAPI
{
    public partial class UserOTPDetails
    {
        [Key]
        public int ID { get; set; }
        public string UserEmail { get; set; }
        public Nullable<int> OTP { get; set; }
        public string UserContact { get; set; }
    }
}
