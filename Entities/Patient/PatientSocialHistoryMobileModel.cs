using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EndocPM.WebAPI
{
    public class PatientSocialHistoryMobileModel
    {
        public int PatientTobaccoAlcoholHistoryID { get; set; }
        public string RecordedDate { get; set; }
        public string CigarettesPerDay { get; set; }
        public string CigarettesPerYear { get; set; }
        public string ConsumptionMLPerDay { get; set; }
        public string ConsumptionMLPerYear { get; set; }
        public string Notes { get; set; }
        public string SmokingStatusDescription { get; set; }
        public string DrinkingStatusDescription { get; set; }
    }
}