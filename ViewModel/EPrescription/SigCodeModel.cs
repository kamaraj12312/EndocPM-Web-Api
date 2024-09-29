using System;

namespace EndocPM.WebAPI
{
    public class SigCodeModel
    {
        #region Model Properties
        public int SigCodeID { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool Deleted { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        #endregion
        #region Custom Properties
        public string SigDescription { get; set; }
        #endregion

    }
}
