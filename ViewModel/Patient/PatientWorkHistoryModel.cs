using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EndocPM.WebAPI
{
    public class PatientWorkHistoryModel
    {
        #region Model Properties
        public int PatientWorkHistoryID { get; set; }
        public int PatientID { get; set; }

        public DateTime RecordedDate { get; set; }
        public string EmployerName { get; set; }
        public string ContactPerson { get; set; }
        public string Telephone { get; set; }
        public string AlternatePhone { get; set; }
        public Nullable<DateTime> WorkDateFrom { get; set; }
        public Nullable<DateTime> WorkDateTo { get; set; }
        public bool Deleted { get; set; }
        public  DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<int> PatientVisitID { get; set; }
        public string Notes { get; set; }


        #endregion

        #region Reference Properties

        #region Patient
        public virtual PatientModel Patient { get; set; }

        #endregion

        #region Pager
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string SortBy { get; set; }
        public string SortOrder { get; set; }

        #endregion

        #region Address
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string County { get; set; }
        public string ZIP { get; set; }
        public string Country { get; set; }

        #endregion

        #endregion

        #region Custom Properties
        public string PatientWorkHistoryTitle { get; set; }
        public string CountryName { get; set; }
        public string SearchEmployerName { get; set; }
        public Nullable<DateTime> FromDate { get; set; }
        public Nullable<DateTime> ToDate { get; set; }
        public string IsSearch { get; set; }
        public string PatientTransactionDateString { get; set; }
        public Nullable<DateTime> PatientTransactionDate { get; set; }
        public string VisitTime { get; set; }
        #endregion
    }
}