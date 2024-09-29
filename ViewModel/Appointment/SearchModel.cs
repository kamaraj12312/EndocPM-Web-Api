using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndocPM.WebAPI
{
    public class SearchModel
    {
        public Nullable<DateTime> Currentdate { get; set; }
        public string PatientName { get; set; }
        public string AppointmentStatusCode { get; set; }
        public string Category { get; set; }
        public int PatientId { get; set; }
        public int ProviderId { get; set; }
        public int FacilityId { get; set; }
        public string NameLast { get; set; }
        public string NameFirst { get; set; }
        public string NameMiddle { get; set; }

        public string viewMode { get; set; }    

        public string date { get; set; }

        public DateTime Fromdate { get; set; }

        public DateTime Todate { get; set; }
    }
}
