﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EndocPM.WebAPI
{
    public class ImmunizationModel
    {
        public ImmunizationModel()
        {

            this.PatientImmunizations = new List<PatientImmunizationModel>();
        }
        #region Model Properties
        public int ImmunizationID { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string LongDescription { get; set; }
        public string VaccineStatus { get; set; }
        public Nullable<int> VaccineStatusID { get; set; }
        public Nullable<DateTime> LastUpdatedDate { get; set; }
        public string Notes { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool IsNewVaccine { get; set; }
        public string VaccineFundingProgram { get; set; }
        public Nullable<DateTime> PublishedDate { get; set; }
        public Nullable<DateTime> PresentedDate { get; set; }
        #endregion
        #region ICollections
        public virtual ICollection<PatientImmunizationModel> PatientImmunizations { get; set; }
        #endregion
        #region Custom Properties
        public string ImmunizationTitle { get; set; }
        public string SearchDescription { get; set; }
        public string SearchCode { get; set; }
        public string SearchVaccineStatus { get; set; }
        public string IsSearch { get; set; }
        #endregion
    }
}