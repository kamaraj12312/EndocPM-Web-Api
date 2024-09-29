using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace EndocPM.WebAPI
{
    public partial class UserDataModel
    {
        #region entity proeprties

        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Title { get; set; }
        public int NPIID { get; set; }
        public string SSNID { get; set; }
        public string NameLast { get; set; }
        public string NameFirst { get; set; }
        public string NameMiddle { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Sex { get; set; }
        public string Credential { get; set; }
        public string NamePrefix { get; set; }
        public string NameSuffix { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string County { get; set; }
        public string ZIP { get; set; }
        public string Country { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
        public string AlternatePhone { get; set; }
        public string Email { get; set; }
        public Nullable<int> EmailConfirmed { get; set; }
        public int UserTypeID { get; set; }
        public string PhoneNumber { get; set; }
        public Nullable<int> PhoneNumberConfirmed { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

 

        #endregion

        #region custom properties

        public string Tenantnames { get; set; }
        public List<clsViewFile> files { get; set; }
        public List<string[]> fileCollect { get; set; }
        public List<int> TenantIdArray { get; set; }
        #endregion
    }
}