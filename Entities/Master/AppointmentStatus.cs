 using System;
using System.Collections.Generic;

namespace EndocPM.WebAPI
{
    public partial class AppointmentStatus
    {
        public int AppointmentStatusID { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string ColorCode { get; set; }
        public bool Deleted { get; set; }
        public  DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }      
    }
}
