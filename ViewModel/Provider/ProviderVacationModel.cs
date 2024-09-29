using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EndocPM.WebAPI
{
    public class ProviderVacationModel
    {
        public ProviderVacationModel()
        {
            this.IsValid= true;
        }

        #region Model Properties


        public int ProviderVacationID { get; set; }
        public int ProviderID { get; set; }
        public string Reason { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool Deleted { get; set; }
        public  DateTime CreatedDate { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public Nullable<DateTime> StartDate { get; set; }
        public Nullable<DateTime> EndDate { get; set; }

        #endregion


        #region reference Properties
        public virtual ProviderModel Provider { get; set; }

        #endregion

        #region Custom Properties

        public string ProviderVacationTitle { get; set; }

        public string StartDateText { get; set; }

        public string EndDateText { get; set; }

        public bool IsValid { get; set; }
        public bool IsValidConfirm { get; set; }
        public string IsSearch { get; set; }

        #endregion

        #region Search Properties
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string SortBy { get; set; }
        public string SortOrder { get; set; }
        public Nullable<DateTime> SearchEffectiveDate { get; set; }
        public Nullable<DateTime> SearchTerminationDate { get; set; }

        #endregion
    }
}