using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndocPM.WebAPI
{
    public partial class PatientAppointmentHistory
    {
        public int PatientAppointmentHistoryID { get; set; }
        public int PatientAppointmentID { get; set; }
        public string AppointmentStatusCode { get; set; }
        public string Comments { get; set; }
        public Nullable<DateTime> ChangedDate { get; set; }
        public string ChangedBy { get; set; }  
    }
}
