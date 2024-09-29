using System;

namespace EndocPM.WebAPI
{ 
    public  class EmdeonLab
    {
    public int EmdeonLabID { get; set; }
    public string EmdeonLabName { get; set; }
    public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string County { get; set; }
    public string ZIP { get; set; }
    public string Telephone { get; set; }
    public string AlternatePhone { get; set; }
    public string Fax { get; set; }
    public string Email { get; set; }
    public bool Deleted { get; set; }
    public System.DateTime CreatedDate { get; set; }
    public string CreatedBy { get; set; }
    public Nullable<System.DateTime> ModifiedDate { get; set; }
    public string ModifiedBy { get; set; }
    
    
    }
}
