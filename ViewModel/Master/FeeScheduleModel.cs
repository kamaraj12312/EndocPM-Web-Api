using System.Collections.Generic;
using System;

namespace EndocPM.WebAPI
{
    public class FeeScheduleModel
    {
       

        #region Model Properties
        public int FeeScheduleID { get; set; }
        public string FeeScheduleNO { get; set; }
        public string CodeQualifier { get; set; }
        public string FeeScheduleStatus { get; set; }
        public Nullable<DateTime> EffectiveDate { get; set; }
        public Nullable<DateTime> TerminationDate { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        #endregion

        #region Reference Properties
     //   public virtual ICollection<FeeScheduleChargeModel> FeeScheduleCharges { get; set; }

        #region Pager
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string SortBy { get; set; }
        public string SortOrder { get; set; }

        #endregion

        #endregion
    }
}
