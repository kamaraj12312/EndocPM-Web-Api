using System;

namespace EndocPM.WebAPI
{
    public class ConsultationType
    {
      public int ConsultationTypeID { get; set; }
      public string ConsultationTypeCode { get; set; }
      public string ConsultationTypeDescription { get; set; }
      public bool  Deleted { get; set; }
      public DateTime  CreatedDate { get; set; }
      public string  CreatedBy { get; set; }
      public DateTime  ModifiedDate { get; set; }
      public string  ModifiedBy { get; set; }
    }
}
