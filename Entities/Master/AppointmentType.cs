using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndocPM.WebAPI
{
    public class AppointmentType
    {
        public int AppointmentTypeId { get; set; }
        public string AppointmentTypeCode { get; set; }
        public string AppointmentTypeDescription { get; set; }
        public Nullable<int> OrderNo { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
