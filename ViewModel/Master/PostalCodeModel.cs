using System;

namespace EndocPM.WebAPI
{
    public class PostalCodeModel
    {
        #region Model Properties
        public int PostalCodeID { get; set; }
        public string ZIP { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string County { get; set; }
        public bool Deleted { get; set; }
        public  DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public string Country { get; set; }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string SortBy { get; set; }
        public string SortOrder { get; set; }
        #endregion
        #region Custom Properties
        public string PostalCodeTitle { get; set; }
        public string IsSearch { get; set; }
        #endregion

    }
}
