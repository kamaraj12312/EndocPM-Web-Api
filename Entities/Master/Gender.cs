using System;

namespace EndocPM.WebAPI
{
    public class Gender
    {
        public int GenderID { get; set; }
        public string GenderCode { get; set; }  
        public string GenderDescription { get; set;}
        public bool Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
